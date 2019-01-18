namespace UserControlLibrary
{
    partial class FavouriteDeletion
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
            this.favouriteListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // favouriteListBox
            // 
            this.favouriteListBox.FormattingEnabled = true;
            this.favouriteListBox.Location = new System.Drawing.Point(23, 39);
            this.favouriteListBox.Name = "favouriteListBox";
            this.favouriteListBox.ScrollAlwaysVisible = true;
            this.favouriteListBox.Size = new System.Drawing.Size(261, 293);
            this.favouriteListBox.TabIndex = 1;
            this.favouriteListBox.SelectedIndexChanged += new System.EventHandler(this.favouriteListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select favourites to delete";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(209, 338);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // FavouriteDeletion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.favouriteListBox);
            this.Name = "FavouriteDeletion";
            this.Size = new System.Drawing.Size(310, 384);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox favouriteListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteButton;
    }
}
