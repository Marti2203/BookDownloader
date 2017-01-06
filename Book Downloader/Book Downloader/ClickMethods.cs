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
            Grid.Visible = true;

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

                SetDownloadLocationIfWanted();

                new Thread(() => Download(Grid["Address", e.RowIndex].Value as string, Grid["Extension", e.RowIndex].Value as string)).Start();
            }
        }

        private void SetDownloadLocationIfWanted()
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.Yes)
                DownloadLocation = folderBrowserDialog1.SelectedPath;
        }

        private void ChainDownloadButton_Click(object sender, EventArgs e)
        {
            LockButtons();
            LockInputFields();
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
            if (CurrentSession != null)
            {
                CurrentSession.CancelAsync();
            }
        }

        private void StopChainDownloadButton_Click(object sender, EventArgs e)
        {
            ChainDownloadThread.Abort();
            OutputTextBox.Text = $"Chain downloading for {SearchText} Stopped at page {CurrentPage}";
            Invoke(new MethodInvoker(() => { UnlockButtons(); UnlockInputFields(); }));
        }


        private void HideButton_Click(object sender, EventArgs e)
        {
            Grid.Visible = false;
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            Grid.Visible = true;
        }
    }
}
