namespace UserControlLibrary
{
    partial class FavouriteNameBox
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
            this.favouriteName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // favouriteName
            // 
            this.favouriteName.Location = new System.Drawing.Point(47, 56);
            this.favouriteName.Name = "favouriteName";
            this.favouriteName.Size = new System.Drawing.Size(136, 22);
            this.favouriteName.TabIndex = 0;
            this.favouriteName.TextChanged += new System.EventHandler(this.favouriteName_TextChanged);
            this.favouriteName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.favouriteName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter a name for this favourite";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(54, 84);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(119, 23);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // FavouriteNameBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.favouriteName);
            this.Name = "FavouriteNameBox";
            this.Size = new System.Drawing.Size(240, 132);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox favouriteName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitButton;
    }
}
