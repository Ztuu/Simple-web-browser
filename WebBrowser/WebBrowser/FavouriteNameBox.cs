using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlLibrary
{
    public partial class FavouriteNameBox : UserControl
    {

        private string url;
        private Form parentWindow;

        /// <summary>
        /// Constructs a new control for allowing the user to save a favourite
        /// </summary>
        /// <param name="url">The address of the favourite</param>
        /// <param name="favNameWindow">The window this control is open in</param>
        public FavouriteNameBox(string url, Form favNameWindow)
        {
            InitializeComponent();
            this.url = url;
            this.parentWindow = favNameWindow;
        }

        private void favouriteName_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Try and save the favourite when the user clicks submit
        /// </summary>
        private void submitButton_Click(object sender, EventArgs e)
        {
            NameFavourite();
        }

        /// <summary>
        /// Try and save the favourite when the user presses enter inside the name text box
        /// </summary>
        private void favouriteName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NameFavourite();
            }
        }

        /// <summary>
        /// Attempts to save the favourite with the user inputted name.
        /// Does not work with empty name, name containing commas or duplicate name.
        /// </summary>
        private void NameFavourite()
        {
            String name = favouriteName.Text;
            if (!name.Equals("") && !name.Contains(",")) //Favourite name can't store comma because it is stored in a csv
            {
                TabUserControl.AddFavourite(name, url);
                parentWindow.Close();

            }
        }
    }
}
