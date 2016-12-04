#define Release
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using System.Threading;

namespace Book_Downloader
{
    public partial class MainForm : Form
    {
        private const string _address = "http://gen.lib.rus.ec/search.php?&req={0}&phrase=1&view=simple&column=def&sort=def&sortmode=ASC&page={1}";
        public MainForm()
        {
            InitializeComponent();
            HTMLOutput.ScrollBars = ScrollBars.Both;
            ElementsDataView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name" });
            ElementsDataView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Address" });
            ElementsDataView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Language" });
            ElementsDataView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Extension" });
            FilterButton.Enabled = false;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            FindButton.Enabled = false;
            FilterButton.Enabled = false;
            ElementsDataView.Enabled = false;
            ElementsDataView.Rows.Clear();
            ElementsDataView.Refresh();

            new Thread(() =>
            {

                string code;
                using (WebClient client = new WebClient())
                {
                    code = client.DownloadString(string.Format(_address, NameTextBox.Text, PageTextBox.Text == "" ? "1" : PageTextBox.Text));
                }
                HTMLOutput.Invoke(new MethodInvoker(() => HTMLOutput.Text = string.Format(_address + "\n", NameTextBox.Text, PageTextBox.Text == "" ? "1" : PageTextBox.Text)));
                HTMLOutput.Invoke(new MethodInvoker(() => HTMLOutput.AppendText(code)));

                string[] names = code
                            .Split('\n')
                            .Where(element => element.Contains("<td width="))
                            .Select(element => element.Split('>')[2])
                            .Select(element => element.Split('<')[0])
                            .ToArray();

                string[] namesAndExtensions = code
                    .Split('\n')
                    .Where(element => element.Contains("<td nowrap"))
                    .Where((element, index) => index % 2 == 1)
                    .Select(element => element.Split('<', '>')[2])
                    .ToArray();

                string[] addresses = code
                    .Split('\n')
                    .Where(element => element.Contains("http://libgen.io/ads.php?md5="))
                    .Select(element => element.Split('\'')[1])
                    .ToArray();

                HTMLOutput.Invoke(new MethodInvoker(() => HTMLOutput.AppendText(namesAndExtensions.Length + " " + names.Length + " " + addresses.Length)));

                for (int i = 0; i < addresses.Length; i++)
                {
                    try
                    {
                        ElementsDataView.Invoke(new MethodInvoker(() => ElementsDataView.Rows.Add(names[i], addresses[i])));
                    }
                    catch (IndexOutOfRangeException ior)
                    {
                        throw new IndexOutOfRangeException(ior.Message + " " + i + " " + addresses.Length + " " + names.Length);
                    }
                }
                for (int j = 0, i = 0; j <= 24; j++, i += 2)
                {
                    ElementsDataView[2, j] = new DataGridViewTextBoxCell { Value = namesAndExtensions[i] };
                    ElementsDataView[3, j] = new DataGridViewTextBoxCell { Value = namesAndExtensions[i + 1] };
                }

                ElementsDataView.Invoke(new MethodInvoker(() => ElementsDataView.AutoResizeColumns()));
                ElementsDataView.Invoke(new MethodInvoker(() => ElementsDataView.AutoResizeRows()));
                FilterButton.Invoke(new MethodInvoker(() => FilterButton.Enabled = true));
            }).Start();

            FindButton.Enabled = true;
            ElementsDataView.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ElementsDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                using (WebClient client = new WebClient())
                {
                    ElementsDataView.Enabled = false;
                    string code = client.DownloadString((string)ElementsDataView[e.ColumnIndex, e.RowIndex].Value);
                    HTMLOutput.Text = code;
                    string key = code
                        .Split('\n')
                        .Where(line => line.Contains("DOWNLOAD"))
                        .First()
                        .Split('>')[1]
                        .Split('=')[3];
                    HTMLOutput.Text = key.Remove(key.Length - 1);

                    ElementsDataView.Enabled = true;
                }
            }
        }
    }
}