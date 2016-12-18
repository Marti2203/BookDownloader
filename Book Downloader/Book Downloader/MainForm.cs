#define Release
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.IO;

namespace Book_Downloader
{
    public partial class MainFormController : Form
    {
        private const string _address = "http://gen.lib.rus.ec/search.php?&req={0}&phrase=1&view=simple&column=def&sort=def&sortmode=ASC&page={1}";

        private ILogger Logger { get; set; } = new BaseLogger();

        #region Information Booleans

        private bool IsDownloading { get; set; } = false;

        private bool HasFiltred { get; set; } = false;

        private bool NotifyOnDone { get; set; } = true;

        private bool HasNextPage { get; set; }

        #endregion

        public string CurrentPage { get; set; }

        public string SearchText { get; set; }

        public MainFormController()
        {
            InitializeComponent();
            OutputTextBox.ScrollBars = ScrollBars.Both;

            #region Create Columns
            ElementsDataView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", ReadOnly = true });
            ElementsDataView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Address", ReadOnly = true });
            ElementsDataView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Language", ReadOnly = true });
            ElementsDataView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Extension", ReadOnly = true });
            #endregion

            FilterButton.Enabled = false;
        }

        #region Click Methods

        private void FindButton_Click(object sender, EventArgs e)
        {
            LockButtonsAndView();
            LockInputFields();
            ElementsDataView.Rows.Clear();
            ElementsDataView.Refresh();
            HasFiltred = false;

            new Thread(() => CreatePage(SearchBox.Text, PageNumberBox.Text)).Start();

        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (HasFiltred) return;
            LockButtonsAndView();
            OutputTextBox.Clear();
            new Thread(() =>
            {
                Filter();

                Invoke(new MethodInvoker(() => UnlockButtonsAndView()));
            }).Start();

        }

        private void ElementsDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && !IsDownloading)
            {
                LockButtonsAndView();
                OutputTextBox.Clear();

                string fileName = CreateFileName(
                    (string)ElementsDataView[e.ColumnIndex - 1, e.RowIndex].Value
                    , (string)ElementsDataView[e.ColumnIndex + 2, e.RowIndex].Value);
                new Thread(() =>
                PrepareForDownload((string)ElementsDataView[e.ColumnIndex, e.RowIndex].Value, fileName)).Start();
            }
        }

        private void ChainDownloadButton_Click(object sender, EventArgs e)
        {
            CurrentPage = PageNumberBox.Text;
            SearchText = SearchBox.Text;
        }

        private void NotifyBox_CheckedChanged(object sender, EventArgs e)
            => NotifyOnDone = !NotifyOnDone;

        #endregion

        private void SetViewLanguageAndExtension(string[] languageAndExtension)
        {
            for (int j = 0, i = 0; j < languageAndExtension.Length / 2; j++, i += 2)
            {
                ElementsDataView[2, j] = new DataGridViewTextBoxCell { Value = languageAndExtension[i] };
                ElementsDataView[3, j] = new DataGridViewTextBoxCell { Value = languageAndExtension[i + 1] };
            }
        }

        private void SetViewNamesAndAddresses(string[] bookNames, string[] downloadAddresses)
        {
            for (int i = 0; i < downloadAddresses.Length; i++)
            {
                try
                {
                    if (bookNames[i] == string.Empty)
                    {
                        Logger.Signal(Severity.Medium, "Empty string", downloadAddresses[i]);
                    }
                    ElementsDataView
                    .Invoke(new MethodInvoker(()
                    => ElementsDataView.Rows
                        .Add(Encoding
                            .UTF8
                            .GetString(Encoding
                                .Default
                                .GetBytes(bookNames[i])).ToLower(), downloadAddresses[i])));
                }
                catch (IndexOutOfRangeException ior)
                {
                    throw new IndexOutOfRangeException(ior.Message + " " + i + " " + downloadAddresses.Length + " " + bookNames.Length);
                }
            }
        }

        private void CreatePage(string searchInput, string pageInput)
        {
            string hyperText;
            using (WebClient client = new WebClient())
            {
                hyperText = client.DownloadString(string.Format(_address, searchInput, pageInput == "" ? "1" : pageInput));
            }

            Invoke(new MethodInvoker(() => UnlockInputFields()));

            string[] lines = hyperText.Split('\n');

            string[] bookNames = CreateBookNames(lines);
            string[] languageAndExtension = CreateLanguageAndExtensions(lines);
            string[] downloadAddresses = CreateDownloadAddresses(lines);

            HasNextPage = CheckForNextPage(lines.Last());

            SetViewNamesAndAddresses(bookNames, downloadAddresses);
            SetViewLanguageAndExtension(languageAndExtension);

            Invoke(new MethodInvoker(() =>
            {
                ElementsDataView.AutoResizeColumns();
                ElementsDataView.AutoResizeRows();
                UnlockButtonsAndView();
            }));
        }

        private string CreateDownloadAddress(string address, string key)
            => string.Format("{0}&key={1}", address.Replace("ads.php","get.php"), key.Remove(key.Length - 1));

        private string CreateFileName(string name, string extension)
            => ((name) + "." + (extension)).Replace(':', '_');

        private void PrepareForDownload(string downloadAddress, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                string hyperText = null;
                TryGetWebPage:
                try
                {
                    hyperText = client.DownloadString(downloadAddress);
                }
                catch (WebException ex)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        OutputTextBox.AppendText("Timed out");
                        OutputTextBox.AppendText(ex.StackTrace);
                        OutputTextBox.AppendText(ex.InnerException?.StackTrace);
                    }));
                    goto TryGetWebPage;
                }

                Download(CreateDownloadAddress(downloadAddress, DownloadKey(hyperText)), fileName);
            }
        }

        private void Download(string downloadAddress, string fileName)
        {
            if (File.Exists(Environment.GetEnvironmentVariable("BookDownloader", EnvironmentVariableTarget.User) + fileName))
            {
                OutputTextBox.Text = "File Exists";
                return;
            }
            using (DownloadSession client =
                new DownloadSession(new Uri(downloadAddress), fileName))
            {
                IsDownloading = true;

                client.DownloadProgressChanged += DownloadProgressChanged;
                client.DownloadFileCompleted += DownloadCompleted;
            }
        }

        private void Filter()
        {
            Dictionary<string, int> books = new Dictionary<string, int>();

            for (int i = 0; i < ElementsDataView.Rows.Count;i++)
            {
                if (ElementsDataView[2, i].Value == null) continue;
                if (!ElementsDataView[2, i].Value.Equals("English"))
                {
                    Invoke(new MethodInvoker(() => { ElementsDataView.Rows.Remove(ElementsDataView.Rows[i]); }));
                    i--;
                }
            }

            
        }

        #region Lock/Unlock
        private void LockButtonsAndView()
        {
            ElementsDataView.Enabled = false;
            FilterButton.Enabled = false;
            FindButton.Enabled = false;
            NotifyBox.Enabled = false;
        }

        private void UnlockButtonsAndView()
        {
            ElementsDataView.Enabled = true;
            FilterButton.Enabled = true;
            FindButton.Enabled = true;
            NotifyBox.Enabled = true;
        }

        private void LockInputFields()
        {
            SearchBox.Enabled = false;
            PageNumberBox.Enabled = false;
        }

        private void UnlockInputFields()
        {
            SearchBox.Enabled = true;
            PageNumberBox.Enabled = true;
        }
        #endregion

    }
}