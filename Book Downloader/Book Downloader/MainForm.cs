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
using static Book_Downloader.WebPageScraper;
using System.Drawing;

namespace Book_Downloader
{
    public partial class MainFormController : Form
    {
        private const string _address = "http://gen.lib.rus.ec/search.php?&req={0}&phrase=1&view=simple&column=def&sort=def&sortmode=ASC&page={1}&res={2}";

        private readonly ILogger _logger;

        private readonly IPrecedenceCreator _precedence;
        
        private DownloadSession CurrentSession { get; set; }

        private Thread ChainDownloadThread { get; set; }

        private string CurrentPage { get; set; }

        private string SearchText { get; set; }

        #region Information Booleans

        private bool IsDownloading { get; set; } = false;

        private bool HasFiltred { get; set; } = false;

        private bool HasNextPage { get; set; } = false;

        #endregion

        public MainFormController(IPrecedenceCreator precedence, ILogger logger)
        {
            InitializeComponent();

            _logger = logger;
            _precedence = precedence;

            #region Create Columns
            Grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", ReadOnly = true });
            Grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Filter Name", ReadOnly = true, Visible = false});
            Grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Address", ReadOnly = true, Visible = false });
            Grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Language", ReadOnly = true });
            Grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Extension", ReadOnly = true });
            #endregion

            SetBackground();

            FilterButton.Enabled = false;
            StopAsyncButton.Enabled = false;
            ChainDownloadButton.Enabled = false;
            StopChainDownloadButton.Enabled = false;
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            new Thread(() => SetBackground()).Start();
            base.OnResizeEnd(e);
        }

        private void SetBackground()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadDataAsync(new Uri($"https://unsplash.it/{Width}/{Height}/?random"));
                client.DownloadDataCompleted += Client_DownloadDataCompleted;
            }
        }

        private void SetView
            (string[] bookNames, string[] filterBookNames, string[] downloadAddresses, string[] languages, string[] extensions)
        {
            for (int i = 0; i < downloadAddresses.Length; i++)
            {
                try
                {
                    Invoke(new MethodInvoker(()
                        => Grid.Rows
                        .Add(bookNames[i], filterBookNames[i], downloadAddresses[i], languages[i], extensions[i])));
                }
                catch (IndexOutOfRangeException ior)
                {
                    throw new IndexOutOfRangeException($"{ior.Message} {i} {downloadAddresses.Length} {bookNames.Length}");
                }
            }
        }

        public void CreatePage(string searchText, string pageNumber)
        {
            string hyperText;
            using (WebClient client = new WebClient())
            {
                hyperText = client.DownloadString(string.Format(_address, searchText, pageNumber, SelectedBookCount));
                HasFiltred = false;
            }

            string[] lines = hyperText.Split('\n').Select(element => element.Trim()).Where(element => element != string.Empty).ToArray();

            string[] bookNames = CreateBookNames(lines);

            if (bookNames.Any(element => element == string.Empty)) _logger.Warning(Severity.Medium, "Empty String:", searchText);

            CreateLanguageAndExtensions(lines, out string[] languages,out string[] extensions);

            string[] downloadAddresses = CreateDownloadAddresses(lines);

            string[] filterBookNames = bookNames.Select(element => CreateFilterName(element)).ToArray();

            HasNextPage = CheckForNextPage(lines);

            SetView(bookNames, filterBookNames, downloadAddresses, languages, extensions);
        }

        private static string CreateFilterName(string bookName)
        {
            string filteredBookName = bookName.ToLower();
            new[] { ',', '\"', ':', '_', '-' }.ToList().ForEach(element => filteredBookName=filteredBookName.Replace(element, ' '));
            
            return filteredBookName;
        }
        private static string CreateDownloadAddress(string address, string key)
            => string.Format("{0}&key={1}", address.Replace("ads.php", "get.php"), key.Remove(key.Length - 1));

        private void CreateDownloadInformation(string page,out string downloadAddress,out string fileName,out bool needExtension)
        {
            if (page == null) throw new ArgumentNullException("Page Link cannot be null");
            using (WebClient client = new WebClient())
            {
                int counter = 0;
                string hyperText = null;
                TryGetWebPage:
                if (counter == 10)
                {
                    downloadAddress = null;
                    fileName = null;
                    needExtension = false;
                    return;
                }
                try
                {
                    Invoke(new MethodInvoker(() => ErrorTextBox.Clear()));
                    hyperText = client.DownloadString(page);
                }
                catch (WebException ex)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        ErrorTextBox.AppendText("Timed out, will retry in 3 secs\n");
                        ErrorTextBox.AppendText($"{ex.StackTrace}\n");
                        Thread.Sleep(3000);
                    }));
                    counter++;
                    goto TryGetWebPage;
                }

                downloadAddress = CreateDownloadAddress(page, DownloadKey(hyperText));
                fileName = GetFileName(hyperText,out needExtension);
                
            }
        }

        public void BeginChainDownloading()
        {
           CurrentPage = PageNumberBox.Text;
           SearchText = SearchBox.Text;
            bool currentHasNextPage;
            do
            {
                IsDownloading = true;
                if (!HasFiltred)
                    Filter();
                Invoke(new MethodInvoker(() =>
                {
                    OutputTextBox.AppendText($"Starting Page { CurrentPage }\n\n");
                }));
                foreach (DataGridViewRow row in Grid.Rows)
                {
                    if (row.Cells[0].Value == null) continue;
                    CreateDownloadInformation(row.Cells["Address"].Value as string,out string downloadAddress,out string fileName,out bool needExtension);
                    if (downloadAddress == null)
                    {
                        Invoke(new MethodInvoker(() => ErrorTextBox.Text = "Timed Out. Please try again later."));
                        return;
                    }
                    if (File.Exists(Environment.GetEnvironmentVariable("BookDownloader", EnvironmentVariableTarget.User) + fileName))
                    {
                        Invoke(new MethodInvoker(() => OutputTextBox.AppendText($"File {fileName} Exists\n\n")));
                        continue;
                    }
                    using (WebClient client = new WebClient())
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            OutputTextBox.AppendText($"Started Download of {fileName}\n\n");
                        }));
                        try
                        {
                            File.WriteAllBytes(
                                string.Format(@"\\?\{0}{1}{2}", 
                                    Environment.GetEnvironmentVariable("BookDownloader"), 
                                    fileName, 
                                    needExtension ? row.Cells["Extension"].Value : string.Empty)
                                , client.DownloadData(downloadAddress));
                        }
                        catch (WebException we)
                        {
                            Invoke(new MethodInvoker(() =>
                            {
                                ErrorTextBox.Clear();
                                _logger.Error(Severity.HUGE, "Failed Download!!"
                                    , downloadAddress, fileName);
                                ErrorTextBox.AppendText($"For File {fileName}\n");
                                ErrorTextBox.AppendText($"{we.Message}\n");
                                ErrorTextBox.AppendText($"{we.StackTrace}\n");
                                ErrorTextBox.AppendText($"{we?.InnerException?.Message}\n");
                                ErrorTextBox.AppendText($"{we.InnerException?.StackTrace}\n");
                                OutputTextBox.AppendText($"Download For {fileName} failed.\n\n");
                            }));
                            goto EndOfFor;
                        }
                    }
                    Invoke(new MethodInvoker(() =>
                    {
                        OutputTextBox.AppendText($"Successful Download of {fileName}\n");
                    }));
                    EndOfFor:

                    ;
                }
                currentHasNextPage = HasNextPage;
                CreatePage(SearchText, CurrentPage = (int.Parse(CurrentPage) + 1).ToString());
            } while (currentHasNextPage);
            IsDownloading = false;
            Invoke(new MethodInvoker(() =>
            {
                OutputTextBox.AppendText($"Finished Chain Downloading \n");
            }));
        }

        public void Download(string page,string extension="")
        {
            if (page == null) throw new ArgumentNullException("Page Link cannot be null");
            if (!Uri.TryCreate(page, UriKind.Absolute, out Uri result)) throw new ArgumentException("Page link is invalid");
            CreateDownloadInformation(page,out string downloadAddress,out string fileName,out bool needExtension);
            StartDownload(downloadAddress, fileName+extension);
        }

        private void StartDownload(string fileLink, string fileName)
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
                CurrentSession = client;
                Invoke(new MethodInvoker(()=>StopAsyncButton.Enabled = true));

                client.DownloadDataCompleted += DownloadDataCompleted;
                client.DownloadProgressChanged += DownloadProgressChanged;
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
                if (GetFilterNameFromGrid(i) == null) continue;
                int precedenceValue = _precedence[GetExtensionFromDataGrid(i)];
                string name = GetFilterNameFromGrid(i);

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

        private string SelectedBookCount
            => RadioPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text.Split(' ')[0];

        private string GetFilterNameFromGrid(int row) => Grid["Filter Name", row].Value as string;
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