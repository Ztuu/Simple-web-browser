namespace WebBrowser
{
    partial class SPWebBrowser
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
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.webTabs = new System.Windows.Forms.TabControl();
            this.addTabButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.logLabel = new System.Windows.Forms.Label();
            this.closeTabButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webTabs
            // 
            this.webTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webTabs.Location = new System.Drawing.Point(8, 6);
            this.webTabs.Name = "webTabs";
            this.webTabs.SelectedIndex = 0;
            this.webTabs.Size = new System.Drawing.Size(1060, 510);
            this.webTabs.TabIndex = 8;
            // 
            // addTabButton
            // 
            this.addTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addTabButton.Location = new System.Drawing.Point(951, 50);
            this.addTabButton.Name = "addTabButton";
            this.addTabButton.Size = new System.Drawing.Size(95, 38);
            this.addTabButton.TabIndex = 9;
            this.addTabButton.Text = "New Tab";
            this.addTabButton.UseVisualStyleBackColor = true;
            this.addTabButton.Click += new System.EventHandler(this.addTabButton_Click);
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(54, 522);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(1014, 22);
            this.logBox.TabIndex = 10;
            // 
            // logLabel
            // 
            this.logLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(12, 524);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(36, 17);
            this.logLabel.TabIndex = 11;
            this.logLabel.Text = "Log:";
            // 
            // closeTabButton
            // 
            this.closeTabButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeTabButton.Location = new System.Drawing.Point(856, 49);
            this.closeTabButton.Name = "closeTabButton";
            this.closeTabButton.Size = new System.Drawing.Size(86, 40);
            this.closeTabButton.TabIndex = 12;
            this.closeTabButton.Text = "Close Tab";
            this.closeTabButton.UseVisualStyleBackColor = true;
            this.closeTabButton.Click += new System.EventHandler(this.closeTabButton_Click);
            // 
            // SPWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1073, 556);
            this.Controls.Add(this.closeTabButton);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.addTabButton);
            this.Controls.Add(this.webTabs);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "SPWebBrowser";
            this.Text = "Web Browser Title";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SPWebBrowser_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.TabControl webTabs;
        private System.Windows.Forms.Button addTabButton;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Button closeTabButton;
    }
}

