namespace UserControlLibrary
{
    partial class FavouritesBar
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
            this.favouriteButton = new System.Windows.Forms.Button();
            this.favouritesGroupBox = new System.Windows.Forms.GroupBox();
            this.homeButton = new System.Windows.Forms.Button();
            this.favouritesList = new System.Windows.Forms.ComboBox();
            this.setHomeButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.favouritesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // favouriteButton
            // 
            this.favouriteButton.Location = new System.Drawing.Point(6, 21);
            this.favouriteButton.Name = "favouriteButton";
            this.favouriteButton.Size = new System.Drawing.Size(133, 23);
            this.favouriteButton.TabIndex = 0;
            this.favouriteButton.Text = "Add Favourite";
            this.favouriteButton.UseVisualStyleBackColor = true;
            this.favouriteButton.Click += new System.EventHandler(this.favouriteButton_Click);
            // 
            // favouritesGroupBox
            // 
            this.favouritesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.favouritesGroupBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.favouritesGroupBox.Controls.Add(this.historyButton);
            this.favouritesGroupBox.Controls.Add(this.homeButton);
            this.favouritesGroupBox.Controls.Add(this.favouritesList);
            this.favouritesGroupBox.Controls.Add(this.setHomeButton);
            this.favouritesGroupBox.Controls.Add(this.favouriteButton);
            this.favouritesGroupBox.Location = new System.Drawing.Point(0, 0);
            this.favouritesGroupBox.Name = "favouritesGroupBox";
            this.favouritesGroupBox.Size = new System.Drawing.Size(833, 57);
            this.favouritesGroupBox.TabIndex = 1;
            this.favouritesGroupBox.TabStop = false;
            this.favouritesGroupBox.Text = "favouritesBar";
            // 
            // homeButton
            // 
            this.homeButton.Location = new System.Drawing.Point(582, 18);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(109, 23);
            this.homeButton.TabIndex = 3;
            this.homeButton.Text = "Go Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // favouritesList
            // 
            this.favouritesList.FormattingEnabled = true;
            this.favouritesList.Location = new System.Drawing.Point(146, 18);
            this.favouritesList.Name = "favouritesList";
            this.favouritesList.Size = new System.Drawing.Size(299, 24);
            this.favouritesList.TabIndex = 2;
            this.favouritesList.SelectedIndexChanged += new System.EventHandler(this.favouritesList_SelectedIndexChanged);
            // 
            // setHomeButton
            // 
            this.setHomeButton.Location = new System.Drawing.Point(451, 18);
            this.setHomeButton.Name = "setHomeButton";
            this.setHomeButton.Size = new System.Drawing.Size(125, 23);
            this.setHomeButton.TabIndex = 1;
            this.setHomeButton.Text = "Set Homepage";
            this.setHomeButton.UseVisualStyleBackColor = true;
            this.setHomeButton.Click += new System.EventHandler(this.setHomeButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.Location = new System.Drawing.Point(698, 17);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(105, 23);
            this.historyButton.TabIndex = 4;
            this.historyButton.Text = "History";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // FavouritesBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.favouritesGroupBox);
            this.Name = "FavouritesBar";
            this.Size = new System.Drawing.Size(836, 60);
            this.favouritesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button favouriteButton;
        private System.Windows.Forms.GroupBox favouritesGroupBox;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.ComboBox favouritesList;
        private System.Windows.Forms.Button setHomeButton;
        private System.Windows.Forms.Button historyButton;
    }
}
