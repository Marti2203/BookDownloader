namespace Book_Downloader
{
    partial class MainFormController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormController));
            this.Grid = new System.Windows.Forms.DataGridView();
            this.FindButton = new System.Windows.Forms.Button();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.FilterButton = new System.Windows.Forms.Button();
            this.NotifyBox = new System.Windows.Forms.CheckBox();
            this.ChainDownloadButton = new System.Windows.Forms.Button();
            this.PageNumberBox = new System.Windows.Forms.NumericUpDown();
            this.ErrorTextBox = new System.Windows.Forms.TextBox();
            this.LargeAmountButton = new System.Windows.Forms.RadioButton();
            this.MediumAmountButton = new System.Windows.Forms.RadioButton();
            this.SmallAmountButton = new System.Windows.Forms.RadioButton();
            this.LargeAmountLabel = new Book_Downloader.CustomLabel();
            this.StopAsyncButton = new System.Windows.Forms.Button();
            this.StopChainDownloadButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new Book_Downloader.CustomLabel();
            this.PageLabel = new Book_Downloader.CustomLabel();
            this.ErrorLabel = new Book_Downloader.CustomLabel();
            this.StatusLabel = new Book_Downloader.CustomLabel();
            this.NotifyLabel = new Book_Downloader.CustomLabel();
            this.SmallAmountLabel = new Book_Downloader.CustomLabel();
            this.MediumAmountLabel = new Book_Downloader.CustomLabel();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.ErrorPanel = new System.Windows.Forms.Panel();
            this.MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ShowButton = new System.Windows.Forms.Button();
            this.HideButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.DownloadLocationButton = new System.Windows.Forms.Button();
            this.ButtonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.RadioPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.RadioButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageNumberBox)).BeginInit();
            this.StatusPanel.SuspendLayout();
            this.ErrorPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.RadioButtonLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Grid.Location = new System.Drawing.Point(200, 100);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.Grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Grid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid.Size = new System.Drawing.Size(872, 385);
            this.Grid.TabIndex = 3;
            this.Grid.Visible = false;
            this.Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellContentClick);
            // 
            // FindButton
            // 
            this.FindButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FindButton.Location = new System.Drawing.Point(3, 3);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(431, 42);
            this.FindButton.TabIndex = 4;
            this.FindButton.Text = "Find Book&s";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextBox.Location = new System.Drawing.Point(0, 16);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputTextBox.Size = new System.Drawing.Size(200, 562);
            this.OutputTextBox.TabIndex = 7;
            // 
            // FilterButton
            // 
            this.FilterButton.AutoSize = true;
            this.FilterButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FilterButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterButton.Location = new System.Drawing.Point(3, 3);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(90, 27);
            this.FilterButton.TabIndex = 8;
            this.FilterButton.Text = "Filter &Results";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // NotifyBox
            // 
            this.NotifyBox.AutoSize = true;
            this.NotifyBox.BackColor = System.Drawing.Color.Transparent;
            this.NotifyBox.Checked = true;
            this.NotifyBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NotifyBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotifyBox.Location = new System.Drawing.Point(107, 3);
            this.NotifyBox.Name = "NotifyBox";
            this.NotifyBox.Size = new System.Drawing.Size(15, 23);
            this.NotifyBox.TabIndex = 9;
            this.NotifyBox.UseVisualStyleBackColor = false;
            this.NotifyBox.CheckedChanged += new System.EventHandler(this.NotifyBox_CheckedChanged);
            // 
            // ChainDownloadButton
            // 
            this.ChainDownloadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChainDownloadButton.Location = new System.Drawing.Point(3, 51);
            this.ChainDownloadButton.Name = "ChainDownloadButton";
            this.ChainDownloadButton.Size = new System.Drawing.Size(431, 36);
            this.ChainDownloadButton.TabIndex = 10;
            this.ChainDownloadButton.Text = "Begin Chain &Download";
            this.ChainDownloadButton.UseVisualStyleBackColor = true;
            this.ChainDownloadButton.Click += new System.EventHandler(this.ChainDownloadButton_Click);
            // 
            // PageNumberBox
            // 
            this.PageNumberBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageNumberBox.Location = new System.Drawing.Point(295, 35);
            this.PageNumberBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PageNumberBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PageNumberBox.Name = "PageNumberBox";
            this.PageNumberBox.Size = new System.Drawing.Size(286, 20);
            this.PageNumberBox.TabIndex = 11;
            this.PageNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ErrorTextBox.Location = new System.Drawing.Point(0, 16);
            this.ErrorTextBox.Multiline = true;
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.ReadOnly = true;
            this.ErrorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ErrorTextBox.Size = new System.Drawing.Size(200, 562);
            this.ErrorTextBox.TabIndex = 12;
            // 
            // LargeAmountButton
            // 
            this.LargeAmountButton.AutoSize = true;
            this.LargeAmountButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LargeAmountButton.Location = new System.Drawing.Point(80, 3);
            this.LargeAmountButton.Name = "LargeAmountButton";
            this.LargeAmountButton.Size = new System.Drawing.Size(14, 13);
            this.LargeAmountButton.TabIndex = 16;
            this.LargeAmountButton.UseVisualStyleBackColor = true;
            // 
            // MediumAmountButton
            // 
            this.MediumAmountButton.AutoSize = true;
            this.MediumAmountButton.Checked = true;
            this.MediumAmountButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediumAmountButton.Location = new System.Drawing.Point(73, 3);
            this.MediumAmountButton.Name = "MediumAmountButton";
            this.MediumAmountButton.Size = new System.Drawing.Size(14, 13);
            this.MediumAmountButton.TabIndex = 17;
            this.MediumAmountButton.TabStop = true;
            this.MediumAmountButton.UseVisualStyleBackColor = true;
            // 
            // SmallAmountButton
            // 
            this.SmallAmountButton.AutoSize = true;
            this.SmallAmountButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SmallAmountButton.Location = new System.Drawing.Point(73, 3);
            this.SmallAmountButton.Name = "SmallAmountButton";
            this.SmallAmountButton.Size = new System.Drawing.Size(14, 13);
            this.SmallAmountButton.TabIndex = 18;
            this.SmallAmountButton.UseVisualStyleBackColor = true;
            // 
            // LargeAmountLabel
            // 
            this.LargeAmountLabel.AutoSize = true;
            this.LargeAmountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LargeAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LargeAmountLabel.ForeColor = System.Drawing.Color.White;
            this.LargeAmountLabel.Location = new System.Drawing.Point(3, 0);
            this.LargeAmountLabel.Name = "LargeAmountLabel";
            this.LargeAmountLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.LargeAmountLabel.OutlineWidth = 2F;
            this.LargeAmountLabel.Size = new System.Drawing.Size(71, 19);
            this.LargeAmountLabel.TabIndex = 21;
            this.LargeAmountLabel.Text = "100 Books";
            // 
            // StopAsyncButton
            // 
            this.StopAsyncButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopAsyncButton.Location = new System.Drawing.Point(440, 3);
            this.StopAsyncButton.Name = "StopAsyncButton";
            this.StopAsyncButton.Size = new System.Drawing.Size(435, 42);
            this.StopAsyncButton.TabIndex = 22;
            this.StopAsyncButton.Text = "Stop Downloading";
            this.StopAsyncButton.UseVisualStyleBackColor = true;
            this.StopAsyncButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StopChainDownloadButton
            // 
            this.StopChainDownloadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopChainDownloadButton.Location = new System.Drawing.Point(440, 51);
            this.StopChainDownloadButton.Name = "StopChainDownloadButton";
            this.StopChainDownloadButton.Size = new System.Drawing.Size(435, 36);
            this.StopChainDownloadButton.TabIndex = 23;
            this.StopChainDownloadButton.Text = "Stop Chain Downloading";
            this.StopChainDownloadButton.UseVisualStyleBackColor = true;
            this.StopChainDownloadButton.Click += new System.EventHandler(this.StopChainDownloadButton_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchBox.Location = new System.Drawing.Point(3, 35);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(286, 20);
            this.SearchBox.TabIndex = 2;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(3, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.NameLabel.OutlineWidth = 2F;
            this.NameLabel.Size = new System.Drawing.Size(286, 32);
            this.NameLabel.TabIndex = 24;
            this.NameLabel.Text = "Name";
            // 
            // PageLabel
            // 
            this.PageLabel.AutoSize = true;
            this.PageLabel.BackColor = System.Drawing.Color.Transparent;
            this.PageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PageLabel.ForeColor = System.Drawing.Color.White;
            this.PageLabel.Location = new System.Drawing.Point(295, 0);
            this.PageLabel.Name = "PageLabel";
            this.PageLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.PageLabel.OutlineWidth = 2F;
            this.PageLabel.Size = new System.Drawing.Size(286, 32);
            this.PageLabel.TabIndex = 25;
            this.PageLabel.Text = "Page";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.BackColor = System.Drawing.Color.Transparent;
            this.ErrorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.White;
            this.ErrorLabel.Location = new System.Drawing.Point(0, 0);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.ErrorLabel.OutlineWidth = 2F;
            this.ErrorLabel.Size = new System.Drawing.Size(44, 16);
            this.ErrorLabel.TabIndex = 26;
            this.ErrorLabel.Text = "Errors";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(0, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.StatusLabel.OutlineWidth = 2F;
            this.StatusLabel.Size = new System.Drawing.Size(109, 16);
            this.StatusLabel.TabIndex = 27;
            this.StatusLabel.Text = "Download Status";
            // 
            // NotifyLabel
            // 
            this.NotifyLabel.AutoSize = true;
            this.NotifyLabel.BackColor = System.Drawing.Color.Transparent;
            this.NotifyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotifyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NotifyLabel.ForeColor = System.Drawing.Color.White;
            this.NotifyLabel.Location = new System.Drawing.Point(3, 0);
            this.NotifyLabel.Name = "NotifyLabel";
            this.NotifyLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.NotifyLabel.OutlineWidth = 2F;
            this.NotifyLabel.Size = new System.Drawing.Size(98, 29);
            this.NotifyLabel.TabIndex = 28;
            this.NotifyLabel.Text = "Notify On Done";
            // 
            // SmallAmountLabel
            // 
            this.SmallAmountLabel.AutoSize = true;
            this.SmallAmountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SmallAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SmallAmountLabel.ForeColor = System.Drawing.Color.White;
            this.SmallAmountLabel.Location = new System.Drawing.Point(3, 0);
            this.SmallAmountLabel.Name = "SmallAmountLabel";
            this.SmallAmountLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.SmallAmountLabel.OutlineWidth = 2F;
            this.SmallAmountLabel.Size = new System.Drawing.Size(64, 19);
            this.SmallAmountLabel.TabIndex = 19;
            this.SmallAmountLabel.Text = "25 Books";
            // 
            // MediumAmountLabel
            // 
            this.MediumAmountLabel.AutoSize = true;
            this.MediumAmountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediumAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MediumAmountLabel.ForeColor = System.Drawing.Color.White;
            this.MediumAmountLabel.Location = new System.Drawing.Point(3, 0);
            this.MediumAmountLabel.Name = "MediumAmountLabel";
            this.MediumAmountLabel.OutlineForeColor = System.Drawing.Color.Black;
            this.MediumAmountLabel.OutlineWidth = 2F;
            this.MediumAmountLabel.Size = new System.Drawing.Size(64, 19);
            this.MediumAmountLabel.TabIndex = 20;
            this.MediumAmountLabel.Text = "50 Books";
            // 
            // StatusPanel
            // 
            this.StatusPanel.BackColor = System.Drawing.Color.Transparent;
            this.StatusPanel.Controls.Add(this.OutputTextBox);
            this.StatusPanel.Controls.Add(this.StatusLabel);
            this.StatusPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatusPanel.Location = new System.Drawing.Point(1078, 0);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(200, 578);
            this.StatusPanel.TabIndex = 29;
            // 
            // ErrorPanel
            // 
            this.ErrorPanel.BackColor = System.Drawing.Color.Transparent;
            this.ErrorPanel.Controls.Add(this.ErrorTextBox);
            this.ErrorPanel.Controls.Add(this.ErrorLabel);
            this.ErrorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ErrorPanel.Location = new System.Drawing.Point(0, 0);
            this.ErrorPanel.Name = "ErrorPanel";
            this.ErrorPanel.Size = new System.Drawing.Size(200, 578);
            this.ErrorPanel.TabIndex = 30;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.ColumnCount = 3;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.MainPanel.Controls.Add(this.tableLayoutPanel2, 2, 1);
            this.MainPanel.Controls.Add(this.flowLayoutPanel4, 2, 0);
            this.MainPanel.Controls.Add(this.PageNumberBox, 1, 1);
            this.MainPanel.Controls.Add(this.NameLabel, 0, 0);
            this.MainPanel.Controls.Add(this.SearchBox, 0, 1);
            this.MainPanel.Controls.Add(this.PageLabel, 1, 0);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainPanel.Location = new System.Drawing.Point(200, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 2;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.66667F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.33333F));
            this.MainPanel.Size = new System.Drawing.Size(878, 75);
            this.MainPanel.TabIndex = 35;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.ShowButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.FilterButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.HideButton, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(587, 35);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(288, 33);
            this.tableLayoutPanel2.TabIndex = 47;
            // 
            // ShowButton
            // 
            this.ShowButton.AutoSize = true;
            this.ShowButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShowButton.Location = new System.Drawing.Point(99, 3);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(90, 27);
            this.ShowButton.TabIndex = 45;
            this.ShowButton.Text = "Show Grid";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // HideButton
            // 
            this.HideButton.AutoSize = true;
            this.HideButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HideButton.Location = new System.Drawing.Point(195, 3);
            this.HideButton.Name = "HideButton";
            this.HideButton.Size = new System.Drawing.Size(90, 27);
            this.HideButton.TabIndex = 41;
            this.HideButton.Text = "Hide Grid";
            this.HideButton.UseVisualStyleBackColor = true;
            this.HideButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.NotifyLabel);
            this.flowLayoutPanel4.Controls.Add(this.NotifyBox);
            this.flowLayoutPanel4.Controls.Add(this.DownloadLocationButton);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(587, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(288, 26);
            this.flowLayoutPanel4.TabIndex = 44;
            // 
            // DownloadLocationButton
            // 
            this.DownloadLocationButton.AutoSize = true;
            this.DownloadLocationButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownloadLocationButton.Location = new System.Drawing.Point(128, 3);
            this.DownloadLocationButton.Name = "DownloadLocationButton";
            this.DownloadLocationButton.Size = new System.Drawing.Size(128, 23);
            this.DownloadLocationButton.TabIndex = 45;
            this.DownloadLocationButton.Text = "Set Download Location";
            this.DownloadLocationButton.UseVisualStyleBackColor = true;
            this.DownloadLocationButton.Click += new System.EventHandler(this.DownloadLocationButton_Click);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.ButtonPanel.ColumnCount = 2;
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.8155F));
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.1845F));
            this.ButtonPanel.Controls.Add(this.FindButton, 0, 0);
            this.ButtonPanel.Controls.Add(this.StopAsyncButton, 1, 0);
            this.ButtonPanel.Controls.Add(this.ChainDownloadButton, 0, 1);
            this.ButtonPanel.Controls.Add(this.StopChainDownloadButton, 1, 1);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(200, 488);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.RowCount = 2;
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54F));
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.ButtonPanel.Size = new System.Drawing.Size(878, 90);
            this.ButtonPanel.TabIndex = 36;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.SmallAmountLabel);
            this.flowLayoutPanel1.Controls.Add(this.SmallAmountButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(90, 19);
            this.flowLayoutPanel1.TabIndex = 38;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.MediumAmountLabel);
            this.flowLayoutPanel2.Controls.Add(this.MediumAmountButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(295, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(90, 19);
            this.flowLayoutPanel2.TabIndex = 39;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.LargeAmountLabel);
            this.flowLayoutPanel3.Controls.Add(this.LargeAmountButton);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(587, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(286, 19);
            this.flowLayoutPanel3.TabIndex = 40;
            // 
            // RadioPanel
            // 
            this.RadioPanel.AutoSize = true;
            this.RadioPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RadioPanel.Location = new System.Drawing.Point(200, 75);
            this.RadioPanel.Name = "RadioPanel";
            this.RadioPanel.Size = new System.Drawing.Size(878, 0);
            this.RadioPanel.TabIndex = 42;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 546F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(200, 75);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(878, 0);
            this.tableLayoutPanel3.TabIndex = 43;
            // 
            // RadioButtonLayout
            // 
            this.RadioButtonLayout.AutoSize = true;
            this.RadioButtonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RadioButtonLayout.BackColor = System.Drawing.Color.Transparent;
            this.RadioButtonLayout.ColumnCount = 4;
            this.RadioButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RadioButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RadioButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RadioButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.RadioButtonLayout.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.RadioButtonLayout.Controls.Add(this.flowLayoutPanel3, 2, 0);
            this.RadioButtonLayout.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.RadioButtonLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.RadioButtonLayout.Location = new System.Drawing.Point(200, 75);
            this.RadioButtonLayout.Name = "RadioButtonLayout";
            this.RadioButtonLayout.RowCount = 1;
            this.RadioButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RadioButtonLayout.Size = new System.Drawing.Size(878, 25);
            this.RadioButtonLayout.TabIndex = 44;
            // 
            // MainFormController
            // 
            this.AcceptButton = this.FindButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1278, 578);
            this.Controls.Add(this.RadioButtonLayout);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.RadioPanel);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ErrorPanel);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.Grid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainFormController";
            this.Text = "Book Downloader";
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageNumberBox)).EndInit();
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.ErrorPanel.ResumeLayout(false);
            this.ErrorPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.RadioButtonLayout.ResumeLayout(false);
            this.RadioButtonLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.CheckBox NotifyBox;
        private System.Windows.Forms.Button ChainDownloadButton;
        private System.Windows.Forms.NumericUpDown PageNumberBox;
        private System.Windows.Forms.TextBox ErrorTextBox;
        private System.Windows.Forms.RadioButton LargeAmountButton;
        private System.Windows.Forms.RadioButton MediumAmountButton;
        private System.Windows.Forms.RadioButton SmallAmountButton;
        private System.Windows.Forms.Button StopAsyncButton;
        private System.Windows.Forms.Button StopChainDownloadButton;
        private System.Windows.Forms.TextBox SearchBox;
        private CustomLabel NameLabel;
        private CustomLabel PageLabel;
        private CustomLabel ErrorLabel;
        private CustomLabel StatusLabel;
        private CustomLabel NotifyLabel;
        private CustomLabel SmallAmountLabel;
        private CustomLabel LargeAmountLabel;
        private CustomLabel MediumAmountLabel;
        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.Panel ErrorPanel;
        private System.Windows.Forms.TableLayoutPanel MainPanel;
        private System.Windows.Forms.TableLayoutPanel ButtonPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel RadioPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel RadioButtonLayout;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button HideButton;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button DownloadLocationButton;
    }
}

