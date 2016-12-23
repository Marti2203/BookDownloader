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
        private const string _address = "http://gen.lib.rus.ec/search.php?&req={0}&phrase=1&view=simple&column=def&sort=def&sortmode=ASC&page={1}&res={2}";

        private readonly ILogger _logger;

        private readonly IPrecedenceCreator _precedence;

        #region Information Booleans

        private bool IsDownloading { get; set; } = false;

        private bool HasFiltred { get; set; } = false;

        private bool NotifyOnDone { get; set; } = true;

        private bool HasNextPage { get; set; } = false;

        #endregion

        public string CurrentPage { get; set; }

        public string SearchText { get; set; }

        public MainFormController(IPrecedenceCreator precedence,ILogger logger)
        {
            InitializeComponent();
            OutputTextBox.ScrollBars = ScrollBars.Both;
            _logger = logger;
            _precedence = precedence;

            #region Create Columns
            Grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", ReadOnly = true });
            Grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Address", ReadOnly = true, Visible = false });
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
                        _logger.Signal(Severity.Medium, "Empty string", downloadAddresses[i]);
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

        public void CreatePage(string searchText, string pageNumber)
        {
            string hyperText;
            using (WebClient client = new WebClient())
            {
                hyperText = client.DownloadString(string
                    .Format(_address, searchText, pageNumber, SelectedBookCount));
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

        private string SelectedBookCount
            => RadioPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text.Split(' ')[0];
        
        private string CreateDownloadAddress(string address, string key)
            => string.Format("{0}&key={1}", address.Replace("ads.php", "get.php"), key.Remove(key.Length - 1));

        private dynamic CreateDownloadInfomration(string page)
        {
            if (page == null) throw new ArgumentNullException("Page Link cannot be null");
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
                        OutputTextBox.AppendText("Timed out\n");
                        OutputTextBox.AppendText(ex.StackTrace);
                        OutputTextBox.AppendText(ex?.InnerException?.StackTrace);
                    }));
                    goto TryGetWebPage;
                }

                return new
                {
                    DownloadAddress = CreateDownloadAddress(page, DownloadKey(hyperText)),
                    FileName = GetFileName(hyperText)
                };
            }
        }

        public void BeginChainDownloading()
        {
            Invoke(new MethodInvoker(() => { LockButtons(); LockInputFields(); Grid.Enabled = false; }));
            CurrentPage = PageNumberBox.Text;
            SearchText = SearchBox.Text;
            bool currentHasNextPage;
            do
            {
                if (!HasFiltred)
                    Filter();

                foreach (DataGridViewRow row in Grid.Rows)
                {
                    if (row.Cells[0].Value == null) continue;
                    dynamic downloadInfo = CreateDownloadInfomration(row.Cells[1].Value as string);
                    if (File.Exists(Environment.GetEnvironmentVariable("BookDownloader", EnvironmentVariableTarget.User) + downloadInfo.FileName))
                    {
                        OutputTextBox.Text = $"File {downloadInfo.FileName} Exists";
                        continue;
                    }
                    using (WebClient client = new WebClient())
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            OutputTextBox.AppendText($"Starting Download of {downloadInfo.FileName}\n");
                        }));
                        try
                        {
                            client.DownloadFile(downloadInfo.DownloadAddress, downloadInfo.FileName);
                        }
                        catch (WebException we)
                        {
                            Invoke(new MethodInvoker(() =>
                            {
                                ErrorTextBox.Clear();
                                ErrorTextBox.AppendText($"For File {downloadInfo.FileName}\n");
                                ErrorTextBox.AppendText($"{we.Message}\n");
                                ErrorTextBox.AppendText($"{we.StackTrace}\n");
                                ErrorTextBox.AppendText($"{we?.InnerException?.Message}\n");
                                ErrorTextBox.AppendText($"{we.InnerException?.StackTrace}\n");
                                OutputTextBox.AppendText($"Download For {downloadInfo.FileName} failed.\n");
                            }));
                            goto EndOfFor;
                        }
                    }
                    Invoke(new MethodInvoker(() =>
                    {
                        OutputTextBox.AppendText($"Finished Downloading {downloadInfo.FileName}\n");
                    }));
                    EndOfFor:

                    ;
                }
                currentHasNextPage = HasNextPage;
                CreatePage(SearchText, CurrentPage = (int.Parse(CurrentPage) + 1).ToString());
                HasFiltred = false;
            } while (currentHasNextPage);
            Invoke(new MethodInvoker(() => { UnlockButtons(); UnlockInputFields(); Grid.Enabled = true; }));
        }

        public void Download(string page)
        {
            if (page == null) throw new ArgumentNullException("Page Link cannot be null");
            if (!Uri.TryCreate(page, UriKind.Absolute, out Uri result)) throw new ArgumentException("Page link is invalid");
            dynamic downloadInfo = CreateDownloadInfomration(page);
            Download(downloadInfo.DownloadAddress, downloadInfo.FileName);
        }

        private void Download(string fileLink, string fileName)
        {
            if (File.Exists(Environment.GetEnvironmentVariable("BookDownloader", EnvironmentVariableTarget.User) + fileName))
            {
                OutputTextBox.Text = $"File {fileName} Exists";
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

        public void Filter()
        {
            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (GetLanguageFromDataGrid(i) != null && GetLanguageFromDataGrid(i) != "English")
                {
                    Invoke(new MethodInvoker(() => { Grid.Rows.Remove(Grid.Rows[i]); }));
                    i--;
                }
            }

            Dictionary<string, Tuple<DataGridViewRow, int>> books = new Dictionary<string, Tuple<DataGridViewRow, int>>();

            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (GetNameFromGrid(i) == null) continue;
                int precedenceValue = _precedence[GetExtensionFromDataGrid(i)]; 
                string name = GetNameFromGrid(i);

                if (!books.ContainsKey(name))
                {
                    books.Add(name, new Tuple<DataGridViewRow, int>(Grid.Rows[i], precedenceValue));
                }
                else if (precedenceValue > books[name].Item2)
                {
                    books[name] = new Tuple<DataGridViewRow, int>(Grid.Rows[i], precedenceValue);
                }

            }

            DataGridViewRow[] uniqueRows = books.Values.Select(element => element.Item1).ToArray();

            Invoke(new MethodInvoker(() => Grid.Rows.Clear()));
            foreach (DataGridViewRow element in uniqueRows)
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