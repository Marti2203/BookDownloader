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

                new Thread(() =>PrepareForDownload((string)ElementsDataView[e.ColumnIndex, e.RowIndex].Value)).Start();
            }
        }

        private void ChainDownloadButton_Click(object sender, EventArgs e)
        {
            CurrentPage = PageNumberBox.Text;
            SearchText = SearchBox.Text;
#warning not done
        }

        private void NotifyBox_CheckedChanged(object sender, EventArgs e)
            => NotifyOnDone = !NotifyOnDone;
    }
}
