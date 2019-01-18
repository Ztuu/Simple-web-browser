using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser; //Reference to our web browser name space

namespace UserControlLibrary
{
    public partial class HistoryBrowser : UserControl
    {
        private int pageNum;
        private List<KeyValuePair<string, string>> userHistory;
        private SPWebBrowser webBrowser;
        private Form thisWindow;
        private int resultsPerPage = 20;


        private delegate int ChangePage(int num);

        /// <summary>
        /// Constructor to initialise history viewing window.
        /// </summary>
        /// <param name="historyIn">List containing all items in the user's history</param>
        /// <param name="browser">The top level browser this control is related to</param>
        /// <param name="newWindow">The window this control is open in</param>
        public HistoryBrowser(List<KeyValuePair<string,string>> historyIn, SPWebBrowser browser, Form newWindow)
        {
            InitializeComponent();
            pageNum = -1; //Initialise to -1 as will start by moving onto page one (zero indexed)
            userHistory = historyIn;
            webBrowser = browser;
            thisWindow = newWindow;
            UpdateDisplay(AddOne);

        }

        /// <summary>
        /// If the user clicks an entry in the history opens a new tab to that page and closes this history
        /// </summary>
        private void historyDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = History.SelectedItem.ToString().Split(' ')[0];
            webBrowser.AddTab(url);
            thisWindow.Close();
        }

        /// <summary>
        /// Moves to next page when user clicks next button
        /// </summary>
        private void nextButton_Click(object sender, EventArgs e)
        {
           UpdateDisplay(AddOne);
        }

        /// <summary>
        /// Moves to previous page when user clicks back button
        /// </summary>
        private void previousButton_Click(object sender, EventArgs e)
        {
            UpdateDisplay(TakeOne);
        }

        /// <summary>
        /// Updates the list of history items to show those on a new page
        /// </summary>
        /// <param name="pageModifier">Delegate to determine what page is being moved to</param>
        private void UpdateDisplay(ChangePage pageModifier)
        {
            History.Items.Clear();
            int historyLength = userHistory.Count();
            int newPageNum = pageModifier(pageNum);

            if(newPageNum >-1 && newPageNum * resultsPerPage < historyLength) //Only change page if the requested number is valid
            {
                pageNum = newPageNum;
            }
            pageNumLabel.Text = "Page " + (pageNum + 1); //Add one as page num is zero indexed

            int startIndex = pageNum * resultsPerPage;
            int pageEntries = historyLength - startIndex;

            if(pageEntries > resultsPerPage) { pageEntries = resultsPerPage; }

            for (int i = startIndex; i < startIndex+pageEntries; i++)
            {
                History.Items.Add(userHistory[i].Key + " " + userHistory[i].Value + "\n"); //TODO: Use string.format
            }
        }

        //One liner functions for incrementing and decrementing
        private int AddOne(int x) { return ++x; } //value must be changed before returning
        private int TakeOne(int x) { return --x; } //value must be changed before returning
    }
}
