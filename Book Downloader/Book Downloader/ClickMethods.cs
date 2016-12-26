using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_Downloader
{
    public partial class MainFormController
    {
        private void FindButton_Click(object sender, EventArgs e)
        {
            LockButtons();
            LockInputFields();
            Grid.Rows.Clear();
            Grid.Refresh();

            new Thread(() =>
            {
                CreatePage(SearchBox.Text, PageNumberBox.Text);
                Invoke(new MethodInvoker(() =>
                {
                    Grid.AutoResizeColumns();
                    Grid.AutoResizeRows();
                    UnlockButtons();
                    UnlockInputFields();
                }));

            }).Start();

        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (HasFiltred) return;

            LockButtons();
            OutputTextBox.Clear();
            new Thread(() =>
            {
                Filter();

                Invoke(new MethodInvoker(() => UnlockButtons()));

            }).Start();

        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && !IsDownloading)
            {
                LockButtons();
                OutputTextBox.Clear();
                StopAsyncButton.Enabled = true;

                new Thread(() => Download((string)Grid["Address", e.RowIndex].Value)).Start();
            }
        }

        private void ChainDownloadButton_Click(object sender, EventArgs e)
        {
            LockButtons();
            LockInputFields();
            Grid.Enabled = false;
            StopChainDownloadButton.Enabled = true;

            ChainDownloadThread = new Thread(() =>
            {
                BeginChainDownloading();

                Invoke(new MethodInvoker(() => 
                {
                    UnlockButtons();
                    Grid.Enabled = true;
                    UnlockInputFields();
                    StopChainDownloadButton.Enabled = false;
                }));
                
            });
            ChainDownloadThread.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
#warning Need to add Stop Async Session
            if (CurrentSession != null)
            {
                CurrentSession.CancelAsync();
            }
        }

        private void StopChainDownloadButton_Click(object sender, EventArgs e)
        {
            ChainDownloadThread.Abort();
            OutputTextBox.Text = $"Chain downloading for {SearchText} Stopped at page {CurrentPage}";
        }
    }
}
