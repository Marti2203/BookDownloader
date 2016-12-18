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
            this.NameLabel = new System.Windows.Forms.Label();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.ElementsDataView = new System.Windows.Forms.DataGridView();
            this.FindButton = new System.Windows.Forms.Button();
            this.PageLabel = new System.Windows.Forms.Label();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.FilterButton = new System.Windows.Forms.Button();
            this.NotifyBox = new System.Windows.Forms.CheckBox();
            this.ChainDownloadButton = new System.Windows.Forms.Button();
            this.PageNumberBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ElementsDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageNumberBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F);
            this.NameLabel.Location = new System.Drawing.Point(9, 38);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(41, 15);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name";
            this.NameLabel.UseMnemonic = false;
            // 
            // SearchBox
            // 
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchBox.Location = new System.Drawing.Point(53, 38);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(113, 20);
            this.SearchBox.TabIndex = 2;
            // 
            // ElementsDataView
            // 
            this.ElementsDataView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ElementsDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElementsDataView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ElementsDataView.Location = new System.Drawing.Point(12, 87);
            this.ElementsDataView.Name = "ElementsDataView";
            this.ElementsDataView.Size = new System.Drawing.Size(1117, 486);
            this.ElementsDataView.TabIndex = 3;
            this.ElementsDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ElementsDataView_CellContentClick);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(277, 38);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(72, 46);
            this.FindButton.TabIndex = 4;
            this.FindButton.Text = "Find Book&s";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // PageLabel
            // 
            this.PageLabel.AutoSize = true;
            this.PageLabel.Location = new System.Drawing.Point(9, 64);
            this.PageLabel.Name = "PageLabel";
            this.PageLabel.Size = new System.Drawing.Size(32, 13);
            this.PageLabel.TabIndex = 6;
            this.PageLabel.Text = "Page";
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Location = new System.Drawing.Point(518, 38);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(389, 46);
            this.OutputTextBox.TabIndex = 7;
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(355, 38);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(78, 46);
            this.FilterButton.TabIndex = 8;
            this.FilterButton.Text = "Filter &Results";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // NotifyBox
            // 
            this.NotifyBox.AutoSize = true;
            this.NotifyBox.Checked = true;
            this.NotifyBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NotifyBox.Location = new System.Drawing.Point(172, 51);
            this.NotifyBox.Name = "NotifyBox";
            this.NotifyBox.Size = new System.Drawing.Size(99, 17);
            this.NotifyBox.TabIndex = 9;
            this.NotifyBox.Text = "Notify On Done";
            this.NotifyBox.UseVisualStyleBackColor = true;
            this.NotifyBox.CheckedChanged += new System.EventHandler(this.NotifyBox_CheckedChanged);
            // 
            // ChainDownloadButton
            // 
            this.ChainDownloadButton.Location = new System.Drawing.Point(439, 38);
            this.ChainDownloadButton.Name = "ChainDownloadButton";
            this.ChainDownloadButton.Size = new System.Drawing.Size(73, 46);
            this.ChainDownloadButton.TabIndex = 10;
            this.ChainDownloadButton.Text = "Begin Chain &Download";
            this.ChainDownloadButton.UseVisualStyleBackColor = true;
            this.ChainDownloadButton.Click += new System.EventHandler(this.ChainDownloadButton_Click);
            // 
            // PageNumberBox
            // 
            this.PageNumberBox.Location = new System.Drawing.Point(53, 62);
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
            this.PageNumberBox.Size = new System.Drawing.Size(113, 20);
            this.PageNumberBox.TabIndex = 11;
            this.PageNumberBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MainFormController
            // 
            this.AcceptButton = this.FindButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 578);
            this.Controls.Add(this.PageNumberBox);
            this.Controls.Add(this.ChainDownloadButton);
            this.Controls.Add(this.NotifyBox);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.PageLabel);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.ElementsDataView);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.NameLabel);
            this.Name = "MainFormController";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.ElementsDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageNumberBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.DataGridView ElementsDataView;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Label PageLabel;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.CheckBox NotifyBox;
        private System.Windows.Forms.Button ChainDownloadButton;
        private System.Windows.Forms.NumericUpDown PageNumberBox;
    }
}

