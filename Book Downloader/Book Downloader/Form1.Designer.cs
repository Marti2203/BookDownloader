namespace Book_Downloader
{
    partial class MainForm
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
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ElementsDataView = new System.Windows.Forms.DataGridView();
            this.FindButton = new System.Windows.Forms.Button();
            this.PageTextBox = new System.Windows.Forms.TextBox();
            this.PageLabel = new System.Windows.Forms.Label();
            this.HTMLOutput = new System.Windows.Forms.TextBox();
            this.FilterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ElementsDataView)).BeginInit();
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
            // NameTextBox
            // 
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.Location = new System.Drawing.Point(53, 38);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(113, 20);
            this.NameTextBox.TabIndex = 2;
            // 
            // ElementsDataView
            // 
            this.ElementsDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ElementsDataView.Location = new System.Drawing.Point(53, 87);
            this.ElementsDataView.Name = "ElementsDataView";
            this.ElementsDataView.Size = new System.Drawing.Size(681, 486);
            this.ElementsDataView.TabIndex = 3;
            this.ElementsDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ElementsDataView_CellContentClick);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(172, 48);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(72, 26);
            this.FindButton.TabIndex = 4;
            this.FindButton.Text = "Find Books";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // PageTextBox
            // 
            this.PageTextBox.Location = new System.Drawing.Point(53, 64);
            this.PageTextBox.Name = "PageTextBox";
            this.PageTextBox.Size = new System.Drawing.Size(113, 20);
            this.PageTextBox.TabIndex = 5;
            // 
            // PageLabel
            // 
            this.PageLabel.AutoSize = true;
            this.PageLabel.Location = new System.Drawing.Point(13, 64);
            this.PageLabel.Name = "PageLabel";
            this.PageLabel.Size = new System.Drawing.Size(32, 13);
            this.PageLabel.TabIndex = 6;
            this.PageLabel.Text = "Page";
            // 
            // HTMLOutput
            // 
            this.HTMLOutput.Location = new System.Drawing.Point(740, 87);
            this.HTMLOutput.Multiline = true;
            this.HTMLOutput.Name = "HTMLOutput";
            this.HTMLOutput.Size = new System.Drawing.Size(389, 486);
            this.HTMLOutput.TabIndex = 7;
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(277, 48);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(98, 29);
            this.FilterButton.TabIndex = 8;
            this.FilterButton.Text = "Filter Results";
            this.FilterButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 578);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.HTMLOutput);
            this.Controls.Add(this.PageLabel);
            this.Controls.Add(this.PageTextBox);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.ElementsDataView);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ElementsDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.DataGridView ElementsDataView;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.TextBox PageTextBox;
        private System.Windows.Forms.Label PageLabel;
        private System.Windows.Forms.TextBox HTMLOutput;
        private System.Windows.Forms.Button FilterButton;
    }
}

