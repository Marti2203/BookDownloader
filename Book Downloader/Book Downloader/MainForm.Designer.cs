﻿namespace Book_Downloader
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
            this.Grid = new System.Windows.Forms.DataGridView();
            this.FindButton = new System.Windows.Forms.Button();
            this.PageLabel = new System.Windows.Forms.Label();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.FilterButton = new System.Windows.Forms.Button();
            this.NotifyBox = new System.Windows.Forms.CheckBox();
            this.ChainDownloadButton = new System.Windows.Forms.Button();
            this.PageNumberBox = new System.Windows.Forms.NumericUpDown();
            this.ErrorTextBox = new System.Windows.Forms.TextBox();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.LargeAmountButton = new System.Windows.Forms.RadioButton();
            this.MediumAmountButton = new System.Windows.Forms.RadioButton();
            this.SmallAmountButton = new System.Windows.Forms.RadioButton();
            this.RadioPanel = new System.Windows.Forms.Panel();
            this.StopAsyncButton = new System.Windows.Forms.Button();
            this.StopChainDownloadButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageNumberBox)).BeginInit();
            this.RadioPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Grid.Location = new System.Drawing.Point(12, 101);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.Grid.Size = new System.Drawing.Size(785, 473);
            this.Grid.TabIndex = 3;
            this.Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellContentClick);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(185, 63);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(84, 32);
            this.FindButton.TabIndex = 4;
            this.FindButton.Text = "Find Book&s";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // PageLabel
            // 
            this.PageLabel.AutoSize = true;
            this.PageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F);
            this.PageLabel.Location = new System.Drawing.Point(24, 73);
            this.PageLabel.Name = "PageLabel";
            this.PageLabel.Size = new System.Drawing.Size(36, 15);
            this.PageLabel.TabIndex = 6;
            this.PageLabel.Text = "Page";
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputTextBox.Location = new System.Drawing.Point(803, 103);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputTextBox.Size = new System.Drawing.Size(463, 192);
            this.OutputTextBox.TabIndex = 7;
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(275, 63);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(106, 32);
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
            this.NotifyBox.Location = new System.Drawing.Point(431, 37);
            this.NotifyBox.Name = "NotifyBox";
            this.NotifyBox.Size = new System.Drawing.Size(99, 17);
            this.NotifyBox.TabIndex = 9;
            this.NotifyBox.Text = "Notify On Done";
            this.NotifyBox.UseVisualStyleBackColor = true;
            // 
            // ChainDownloadButton
            // 
            this.ChainDownloadButton.Location = new System.Drawing.Point(387, 63);
            this.ChainDownloadButton.Name = "ChainDownloadButton";
            this.ChainDownloadButton.Size = new System.Drawing.Size(143, 32);
            this.ChainDownloadButton.TabIndex = 10;
            this.ChainDownloadButton.Text = "Begin Chain &Download";
            this.ChainDownloadButton.UseVisualStyleBackColor = true;
            this.ChainDownloadButton.Click += new System.EventHandler(this.ChainDownloadButton_Click);
            // 
            // PageNumberBox
            // 
            this.PageNumberBox.Location = new System.Drawing.Point(66, 71);
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
            // ErrorTextBox
            // 
            this.ErrorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorTextBox.Location = new System.Drawing.Point(803, 321);
            this.ErrorTextBox.Multiline = true;
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.ReadOnly = true;
            this.ErrorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ErrorTextBox.Size = new System.Drawing.Size(463, 252);
            this.ErrorTextBox.TabIndex = 12;
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(804, 87);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(74, 13);
            this.OutputLabel.TabIndex = 13;
            this.OutputLabel.Text = "Current Status";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(807, 302);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(34, 13);
            this.ErrorLabel.TabIndex = 14;
            this.ErrorLabel.Text = "Errors";
            // 
            // LargeAmountButton
            // 
            this.LargeAmountButton.AutoSize = true;
            this.LargeAmountButton.Location = new System.Drawing.Point(157, 9);
            this.LargeAmountButton.Name = "LargeAmountButton";
            this.LargeAmountButton.Size = new System.Drawing.Size(76, 17);
            this.LargeAmountButton.TabIndex = 16;
            this.LargeAmountButton.Text = "100 Books";
            this.LargeAmountButton.UseVisualStyleBackColor = true;
            // 
            // MediumAmountButton
            // 
            this.MediumAmountButton.AutoSize = true;
            this.MediumAmountButton.Checked = true;
            this.MediumAmountButton.Location = new System.Drawing.Point(78, 9);
            this.MediumAmountButton.Name = "MediumAmountButton";
            this.MediumAmountButton.Size = new System.Drawing.Size(70, 17);
            this.MediumAmountButton.TabIndex = 17;
            this.MediumAmountButton.TabStop = true;
            this.MediumAmountButton.Text = "50 Books";
            this.MediumAmountButton.UseVisualStyleBackColor = true;
            // 
            // SmallAmountButton
            // 
            this.SmallAmountButton.AutoSize = true;
            this.SmallAmountButton.Location = new System.Drawing.Point(3, 9);
            this.SmallAmountButton.Name = "SmallAmountButton";
            this.SmallAmountButton.Size = new System.Drawing.Size(70, 17);
            this.SmallAmountButton.TabIndex = 18;
            this.SmallAmountButton.Text = "25 Books";
            this.SmallAmountButton.UseVisualStyleBackColor = true;
            // 
            // RadioPanel
            // 
            this.RadioPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RadioPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RadioPanel.Controls.Add(this.SmallAmountButton);
            this.RadioPanel.Controls.Add(this.MediumAmountButton);
            this.RadioPanel.Controls.Add(this.LargeAmountButton);
            this.RadioPanel.Location = new System.Drawing.Point(185, 28);
            this.RadioPanel.Name = "RadioPanel";
            this.RadioPanel.Size = new System.Drawing.Size(240, 31);
            this.RadioPanel.TabIndex = 19;
            // 
            // StopAsyncButton
            // 
            this.StopAsyncButton.Location = new System.Drawing.Point(611, 63);
            this.StopAsyncButton.Name = "StopAsyncButton";
            this.StopAsyncButton.Size = new System.Drawing.Size(135, 32);
            this.StopAsyncButton.TabIndex = 22;
            this.StopAsyncButton.Text = "Stop Downloading";
            this.StopAsyncButton.UseVisualStyleBackColor = true;
            this.StopAsyncButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StopChainDownloadButton
            // 
            this.StopChainDownloadButton.Location = new System.Drawing.Point(611, 28);
            this.StopChainDownloadButton.Name = "StopChainDownloadButton";
            this.StopChainDownloadButton.Size = new System.Drawing.Size(135, 31);
            this.StopChainDownloadButton.TabIndex = 23;
            this.StopChainDownloadButton.Text = "Stop Chain Downloading";
            this.StopChainDownloadButton.UseVisualStyleBackColor = true;
            this.StopChainDownloadButton.Click += new System.EventHandler(this.StopChainDownloadButton_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchBox.Location = new System.Drawing.Point(66, 39);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(113, 20);
            this.SearchBox.TabIndex = 2;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F);
            this.NameLabel.Location = new System.Drawing.Point(19, 41);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(41, 15);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name";
            this.NameLabel.UseMnemonic = false;
            // 
            // MainFormController
            // 
            this.AcceptButton = this.FindButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 578);
            this.Controls.Add(this.PageNumberBox);
            this.Controls.Add(this.PageLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.StopChainDownloadButton);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.StopAsyncButton);
            this.Controls.Add(this.NotifyBox);
            this.Controls.Add(this.RadioPanel);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.ErrorTextBox);
            this.Controls.Add(this.ChainDownloadButton);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.Grid);
            this.Name = "MainFormController";
            this.Text = "Book Downloader";
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageNumberBox)).EndInit();
            this.RadioPanel.ResumeLayout(false);
            this.RadioPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Label PageLabel;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.CheckBox NotifyBox;
        private System.Windows.Forms.Button ChainDownloadButton;
        private System.Windows.Forms.NumericUpDown PageNumberBox;
        private System.Windows.Forms.TextBox ErrorTextBox;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.RadioButton LargeAmountButton;
        private System.Windows.Forms.RadioButton MediumAmountButton;
        private System.Windows.Forms.RadioButton SmallAmountButton;
        private System.Windows.Forms.Panel RadioPanel;
        private System.Windows.Forms.Button StopAsyncButton;
        private System.Windows.Forms.Button StopChainDownloadButton;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label NameLabel;
    }
}

