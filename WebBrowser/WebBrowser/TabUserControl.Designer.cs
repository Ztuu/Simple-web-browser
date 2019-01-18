namespace UserControlLibrary
{
    partial class TabUserControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.urlBar = new System.Windows.Forms.TextBox();
            this.forwardButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteFavButton = new System.Windows.Forms.Button();
            this.setHomeButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.favouritesBox = new System.Windows.Forms.ComboBox();
            this.favouriteButton = new System.Windows.Forms.Button();
            this.htmlOut = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.groupBox1.Controls.Add(this.backButton);
            this.groupBox1.Controls.Add(this.refreshButton);
            this.groupBox1.Controls.Add(this.goButton);
            this.groupBox1.Controls.Add(this.urlBar);
            this.groupBox1.Controls.Add(this.forwardButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1001, 62);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(6, 20);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(712, 20);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(630, 20);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 3;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // urlBar
            // 
            this.urlBar.Location = new System.Drawing.Point(170, 22);
            this.urlBar.Name = "urlBar";
            this.urlBar.Size = new System.Drawing.Size(453, 22);
            this.urlBar.TabIndex = 2;
            this.urlBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.urlBar_KeyDown);
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(88, 20);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(75, 23);
            this.forwardButton.TabIndex = 1;
            this.forwardButton.Text = "Forward";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.Location = new System.Drawing.Point(655, 10);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(75, 23);
            this.historyButton.TabIndex = 6;
            this.historyButton.Text = "History";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.deleteFavButton);
            this.groupBox2.Controls.Add(this.historyButton);
            this.groupBox2.Controls.Add(this.setHomeButton);
            this.groupBox2.Controls.Add(this.homeButton);
            this.groupBox2.Controls.Add(this.favouritesBox);
            this.groupBox2.Controls.Add(this.favouriteButton);
            this.groupBox2.Location = new System.Drawing.Point(3, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1001, 37);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // deleteFavButton
            // 
            this.deleteFavButton.Location = new System.Drawing.Point(289, 10);
            this.deleteFavButton.Name = "deleteFavButton";
            this.deleteFavButton.Size = new System.Drawing.Size(144, 23);
            this.deleteFavButton.TabIndex = 7;
            this.deleteFavButton.Text = "Delete Favourites";
            this.deleteFavButton.UseVisualStyleBackColor = true;
            this.deleteFavButton.Click += new System.EventHandler(this.deleteFavButton_Click);
            // 
            // setHomeButton
            // 
            this.setHomeButton.Location = new System.Drawing.Point(539, 10);
            this.setHomeButton.Name = "setHomeButton";
            this.setHomeButton.Size = new System.Drawing.Size(110, 23);
            this.setHomeButton.TabIndex = 3;
            this.setHomeButton.Text = "Set Home";
            this.setHomeButton.UseVisualStyleBackColor = true;
            this.setHomeButton.Click += new System.EventHandler(this.setHomeButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.homeButton.Location = new System.Drawing.Point(458, 10);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(75, 23);
            this.homeButton.TabIndex = 2;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // favouritesBox
            // 
            this.favouritesBox.FormattingEnabled = true;
            this.favouritesBox.Location = new System.Drawing.Point(104, 9);
            this.favouritesBox.Name = "favouritesBox";
            this.favouritesBox.Size = new System.Drawing.Size(179, 24);
            this.favouritesBox.TabIndex = 1;
            this.favouritesBox.SelectedIndexChanged += new System.EventHandler(this.favouritesBox_SelectedIndexChanged);
            // 
            // favouriteButton
            // 
            this.favouriteButton.Location = new System.Drawing.Point(6, 10);
            this.favouriteButton.Name = "favouriteButton";
            this.favouriteButton.Size = new System.Drawing.Size(92, 23);
            this.favouriteButton.TabIndex = 0;
            this.favouriteButton.Text = "Favourite";
            this.favouriteButton.UseVisualStyleBackColor = true;
            this.favouriteButton.Click += new System.EventHandler(this.favouriteButton_Click);
            // 
            // htmlOut
            // 
            this.htmlOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlOut.Location = new System.Drawing.Point(3, 115);
            this.htmlOut.Multiline = true;
            this.htmlOut.Name = "htmlOut";
            this.htmlOut.Size = new System.Drawing.Size(1001, 456);
            this.htmlOut.TabIndex = 3;
            // 
            // TabUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.htmlOut);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TabUserControl";
            this.Size = new System.Drawing.Size(1010, 574);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabUserControl_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.TextBox urlBar;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button favouriteButton;
        private System.Windows.Forms.ComboBox favouritesBox;
        private System.Windows.Forms.Button setHomeButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.TextBox htmlOut;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.Button deleteFavButton;
    }
}
