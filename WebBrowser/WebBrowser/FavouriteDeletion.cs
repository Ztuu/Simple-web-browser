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
    public partial class FavouriteDeletion : UserControl
    {

        private Form thisWindow;

        /// <summary>
        /// Constructs a new control for allowing deletion of user favourites
        /// </summary>
        /// <param name="newWindow">The window this control is contained in</param>
        public FavouriteDeletion(Form newWindow)
        {
            InitializeComponent();
            thisWindow = newWindow;

            FillListBox();
        }

        private void favouriteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Removes the selected items the user has chosen from the favourites list when they click the delete button
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> removeList = new List<string>();
            foreach(int ind in favouriteListBox.CheckedIndices)
            {
                removeList.Add(favouriteListBox.Items[ind].ToString());
            }

            TabUserControl.RemoveFavourites(removeList);
            thisWindow.Close();
        }

        /// <summary>
        /// Initially populates the display with the user's favourites
        /// </summary>
        private void FillListBox()
        {
            foreach(KeyValuePair<string,string> fav in TabUserControl.Favourites)
            {
                favouriteListBox.Items.Add(fav.Key);
            }
        }
    }
}
