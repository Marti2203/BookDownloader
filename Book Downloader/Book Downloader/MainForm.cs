#define Release
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Collections.Generic;

namespace Book_Downloader
{
    public partial class MainFormController : Form
    {
        private const string _address = "http://gen.lib.rus.ec/search.php?&req={0}&phrase=1&view=simple&column=def&sort=def&sortmode=ASC&page={1}";

        private ILogger Logger { get; set; } = new BaseLogger();

        Dictionary<object, string> downloadingFileNames = new Dictionary<object, string>();

        private bool IsDownloading { get; set; }
        private bool NotifyOnDone { get; set; } = true;

        private int count = 0;
        private int startingPage = 0;

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

            new Thread(() => Page(SearchNameTextBox.Text, PageTextBox.Text)).Start();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            LockButtonsAndView();
            OutputTextBox.Clear();
            new Thread(() =>
            {
                Filter();
                Filter();

                Invoke(new MethodInvoker(() => UnlockButtonsAndView()));
            }).Start();

        }

        private void ElementsDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && !IsDownloading)
            {
                LockButtonsAndView();
                new Thread(() => PrepareForDownload(e)).Start();
            }
        }

        private void NotifyBox_CheckedChanged(object sender, EventArgs e) => NotifyOnDone = !NotifyOnDone;

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

        private void PrepareForDownload(DataGridViewCellEventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                string hyperText = null;
                TryGetWebPage:
                try
                {
                    hyperText = client.DownloadString((string)ElementsDataView[e.ColumnIndex, e.RowIndex].Value);
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

                Invoke(new MethodInvoker(() => OutputTextBox.Text = "Received HTML"));

                //Invoke(new MethodInvoker(() => OutputTextBox.Text = hyperText));

                string downloadAddress = DownloadAddress(
                    ((string)ElementsDataView[e.ColumnIndex, e.RowIndex].Value).Replace("ads", "get")
                    , DownloadKey(hyperText));
                string fileName = FileName
                    ((string)ElementsDataView[e.ColumnIndex - 1, e.RowIndex].Value,
                     (string)ElementsDataView[e.ColumnIndex + 2, e.RowIndex].Value);

                //Invoke(new MethodInvoker(() => OutputTextBox.Text = downloadAddress));

                Invoke(new MethodInvoker(() => Download(downloadAddress, fileName)));
            }
        }

        #region String Creators

        private void Page(string searchInput, string pageInput)
        {
            string hyperText;
            using (WebClient client = new WebClient())
            {
                hyperText = client.DownloadString(string.Format(_address, searchInput, pageInput == "" ? "1" : pageInput));
            }

            Invoke(new MethodInvoker(() => UnlockInputFields()));

            string[] bookNames = BookNames(hyperText);

            string[] languageAndExtension = LanguageAndExtensions(hyperText);

            string[] downloadAddresses = DownloadAddresses(hyperText);

            count = downloadAddresses.Length;

            //Invoke(new MethodInvoker(() =>
            //{
            //    OutputTextBox.Text = string.Format(_address + "\n", searchInput, pageInput == "" ? "1" : pageInput);
            //    OutputTextBox.AppendText(hyperText);
            //    OutputTextBox.AppendText(languageAndExtension.Length + " " + bookNames.Length + " " + downloadAddresses.Length);
            //}));

            SetViewNamesAndAddresses(bookNames, downloadAddresses);
            SetViewLanguageAndExtension(languageAndExtension);

            Invoke(new MethodInvoker(() =>
            {
                ElementsDataView.AutoResizeColumns();
                ElementsDataView.AutoResizeRows();
                UnlockButtonsAndView();
            }));
        }

        private string DownloadAddress(string address, string key)
        {
            return string.Format("{0}&key={1}", address, key.Remove(key.Length - 1));
        }

        private string FileName(string name, string extension) => ((name) + "." + (extension)).Replace(':', '_');

        #endregion

        private void Download(string downloadAddress, string fileName)
        {
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
            for (int i = 0; i < ElementsDataView.Rows.Count; i++)
            {
                if (ElementsDataView[2, i].Value == null) continue;
                if (!ElementsDataView[2, i].Value.Equals("English"))
                    Invoke(new MethodInvoker(() => { ElementsDataView.Rows.Remove(ElementsDataView.Rows[i]); }));
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
            SearchNameTextBox.Enabled = false;
            PageTextBox.Enabled = false;
        }

        private void UnlockInputFields()
        {
            SearchNameTextBox.Enabled = true;
            PageTextBox.Enabled = true;
        }
        #endregion 
    }
}