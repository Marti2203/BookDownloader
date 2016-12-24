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

            new Thread(() => CreatePage(SearchBox.Text, PageNumberBox.Text)).Start();

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

                new Thread(() => Download((string)Grid["Address", e.RowIndex].Value)).Start();
            }
        }

        private void ChainDownloadButton_Click(object sender, EventArgs e)
            => new Thread(() => { BeginChainDownloading(); }).Start();

        private void NotifyBox_CheckedChanged(object sender, EventArgs e)
            => NotifyOnDone = !NotifyOnDone;
    }
}
