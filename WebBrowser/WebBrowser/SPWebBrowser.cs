using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControlLibrary; //Gives access to our custom user controls 
using System.Diagnostics.Contracts; //Allows use of code contracts

namespace WebBrowser
{
    /// <summary>
    /// A basic web browser.
    /// </summary>
    public partial class SPWebBrowser : Form
    {
        /// <summary>
        /// Constructor to initialise the form when run. Creates a single tab .
        /// </summary>
        public SPWebBrowser()
        {
            InitializeComponent();
            this.Text = "SP Web Browser";

            AddTab();
        }

        /// <summary>
        /// The method triggered by an event when the add tab button is clicked by the user
        /// </summary>
        private void addTabButton_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        /// <summary>
        /// Creates a new tab and adds it to the browser. Tab opens on home page
        /// </summary>
        private void AddTab()
        {
            TabPage newtab = new TabPage();
            TabUserControl newControl = new TabUserControl(newtab, this.logBox, this);
            NewTab(newControl, newtab);
        }

        /// <summary>
        /// Creates a new tab which will open to a specified url and adds it to the browser.
        /// </summary>
        /// <param name="url">The url that the new tab should open to</param>
        public void AddTab(string url)
        {
            TabPage newtab = new TabPage();
            TabUserControl newControl = new TabUserControl(newtab, this.logBox, this, url);
            NewTab(newControl, newtab);
        }

        /// <summary>
        /// Places a user control onto a tab page then adds that tab to the window.
        /// Controls setup of the control on the tab page. When finished will activate the new tab.
        /// </summary>
        /// <param name="newTabControl">The user control to be placed on the tab</param>
        /// <param name="newTab">The new tab to be added to the browser</param>
        private void NewTab(TabUserControl newTabControl, TabPage newTab)
        {
            Contract.Requires(newTab != null);
            Contract.Requires(newTabControl != null);

            webTabs.TabPages.Add(newTab);
            newTab.Controls.Add(newTabControl);
            newTabControl.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom); //Ensures the control will resize with the window
            webTabs.SelectedTab = newTab;
        }

        /// <summary>
        /// Tries to close current tab.
        /// </summary>
        private void closeTabButton_Click(object sender, EventArgs e)
        {
            CloseTab();
        }

        /// <summary>
        /// Closes the currently open tab if there is one.
        /// </summary>
        private void CloseTab()
        {
            try
            {
                webTabs.SelectedTab.Dispose();
            }
            catch (NullReferenceException nre)
            {
                logBox.Text = "No tabs to close!";
            }
        }

        private void SPWebBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
            {
                AddTab();
            }else if(e.KeyCode == Keys.W && e.Modifiers == Keys.Control)
            {
                CloseTab();
            }
            else if (e.KeyCode == Keys.Q && e.Modifiers == Keys.Control)
            {
                Application.Exit();
            }
        }
    }
}
