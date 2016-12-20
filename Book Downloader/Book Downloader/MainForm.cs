#define Release
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Collections;

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

        private bool HasNextPage { get; set; } = false;

        #endregion
        
        public string CurrentPage { get; set; }

        public string SearchText { get; set; }

        public MainFormController()
        {
            InitializeComponent();
            OutputTextBox.ScrollBars = ScrollBars.Both;

            #region Create Columns
            Grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", ReadOnly = true });
            Grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Address", ReadOnly = true });
            Grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Language", ReadOnly = true });
            Grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Extension", ReadOnly = true });
            #endregion

            FilterButton.Enabled = false;
            ChainDownloadButton.Enabled = false;
        }

        private void SetViewLanguageAndExtension(string[] languageAndExtension)
        {
            for (int j = 0, i = 0; j < languageAndExtension.Length / 2; j++, i += 2)
            {
                Grid["Language", j] = new DataGridViewTextBoxCell { Value = languageAndExtension[i] };
                Grid["Extension", j] = new DataGridViewTextBoxCell { Value = languageAndExtension[i + 1] };
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
                    Grid
                    .Invoke(new MethodInvoker(()
                    => Grid.Rows
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
                Grid.AutoResizeColumns();
                Grid.AutoResizeRows();
                UnlockButtons();
            }));
        }

        private string CreateDownloadAddress(string address, string key)
            => string.Format("{0}&key={1}", address.Replace("ads.php", "get.php"), key.Remove(key.Length - 1));

        private void BeginChainDownloading()
        {
            CurrentPage = PageNumberBox.Text;
            SearchText = SearchBox.Text;

            if (!HasFiltred)
                Filter();

            foreach (DataGridViewRow row in Grid.Rows)
            {
//#error Need to add downloading
                //PrepareForSynchronousDownload(row.Cells[1].Value as string);
            }
            if (HasNextPage)
                CreatePage(SearchText, CurrentPage=(int.Parse(CurrentPage)+1).ToString());        
        }


        private void PrepareForDownload(string page)
        {
            using (WebClient client = new WebClient())
            {
                string hyperText = null;
                TryGetWebPage:
                try
                {
                    hyperText = client.DownloadString(page);
                }
                catch (WebException ex)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        OutputTextBox.AppendText("Timed out");
                        OutputTextBox.AppendText(ex.StackTrace);
                        OutputTextBox.AppendText(ex?.InnerException?.StackTrace);
                    }));
                    goto TryGetWebPage;
                }

                Download(CreateDownloadAddress(page, DownloadKey(hyperText)), GetFileName(hyperText));
            }
        }

        private void Download(string fileLink, string fileName)
        {
            if (File.Exists(Environment.GetEnvironmentVariable("BookDownloader", EnvironmentVariableTarget.User) + fileName))
            {
                OutputTextBox.Text = "File Exists";
                return;
            }
            using (DownloadSession client =
                new DownloadSession(new Uri(fileLink), fileName))
            {
                IsDownloading = true;

                client.DownloadProgressChanged += DownloadProgressChanged;
                client.DownloadFileCompleted += DownloadCompleted;
            }
        }

        private void Filter()
        {
            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (GetLanguageFromDataGrid(i) != null && GetLanguageFromDataGrid(i) != "English")
                {
                    Invoke(new MethodInvoker(() => { Grid.Rows.Remove(Grid.Rows[i]); }));
                    i--;
                }
            }

            Dictionary<string, Tuple<DataGridViewRow, BookPrecedence>> books = new Dictionary<string, Tuple<DataGridViewRow, BookPrecedence>>();

            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (GetNameFromGrid(i) == null) continue;
                BookPrecedence value = (BookPrecedence)Enum.Parse(typeof(BookPrecedence), Grid["Extension", i].Value as string);
                string name = GetNameFromGrid(i);

                if (!books.ContainsKey(name))
                {
                    books.Add(name, new Tuple<DataGridViewRow, BookPrecedence>(Grid.Rows[i], value));
                }
                else if (value > books[name].Item2)
                {
                    books[name] = new Tuple<DataGridViewRow, BookPrecedence>(Grid.Rows[i], value);
                }

            }

            DataGridViewRow[] uniqueElements = books.Values.Select(element => element.Item1).ToArray();

            Invoke(new MethodInvoker(() => Grid.Rows.Clear()));
            foreach(DataGridViewRow element in uniqueElements)
            {
                Invoke(new MethodInvoker(() => Grid.Rows.Add(element)));
            }

            HasFiltred = true;
        }

        private string GetNameFromGrid(int row) => Grid["Name", row].Value as string;
        private string GetLanguageFromDataGrid(int row) => Grid["Language", row].Value as string;
        private string GetExtensionFromDataGrid(int row) => Grid["Extension", row].Value as string;


        #region Lock/Unlock

        private void LockButtons()
        {
            FilterButton.Enabled = false;
            FindButton.Enabled = false;
            ChainDownloadButton.Enabled = false;
            NotifyBox.Enabled = false;
        }

        private void UnlockButtons()
        {
            FilterButton.Enabled = true;
            FindButton.Enabled = true;
            ChainDownloadButton.Enabled = true;
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