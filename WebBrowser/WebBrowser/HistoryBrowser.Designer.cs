namespace UserControlLibrary
{
    partial class HistoryBrowser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.History = new System.Windows.Forms.ListBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.pageNumLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // History
            // 
            this.History.FormattingEnabled = true;
            this.History.ItemHeight = 16;
            this.History.Location = new System.Drawing.Point(17, 14);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(339, 516);
            this.History.TabIndex = 0;
            this.History.SelectedIndexChanged += new System.EventHandler(this.historyDisplay_SelectedIndexChanged);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(264, 536);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(92, 23);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Next Page";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(17, 536);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(115, 23);
            this.previousButton.TabIndex = 2;
            this.previousButton.Text = "Previous Page";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // pageNumLabel
            // 
            this.pageNumLabel.AutoSize = true;
            this.pageNumLabel.Location = new System.Drawing.Point(163, 539);
            this.pageNumLabel.Name = "pageNumLabel";
            this.pageNumLabel.Size = new System.Drawing.Size(54, 17);
            this.pageNumLabel.TabIndex = 3;
            this.pageNumLabel.Text = "Page X";
            // 
            // HistoryBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageNumLabel);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.History);
            this.Name = "HistoryBrowser";
            this.Size = new System.Drawing.Size(388, 578);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox History;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Label pageNumLabel;
    }
}
