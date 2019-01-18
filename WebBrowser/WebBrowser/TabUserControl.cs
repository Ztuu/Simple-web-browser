using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Text.RegularExpressions;
using WebBrowser;
using System.Threading;
using System.Diagnostics.Contracts;

namespace UserControlLibrary
{
    public partial class TabUserControl : UserControl
    {

        private string currentUrl; //Will store which page this tab is currently on
        private static string homeUrl; //Stores the user's homepage in memory.
        private List<String> localHistory; //The history of web pages this tab has accessed
        private int localHistoryPosition = -1; //Initialise to -1 as when home page is accessed will go to 0
        public static List<KeyValuePair<string, string>> GlobalHistory { get; private set; } //Web history for all tabs
        public static Dictionary<string, string> Favourites { get; private set; } //User's favourites

        //Compile some regular expressions we will use multiple times so they are only compiled once
        private Regex regexHttp = new Regex(@"http://", RegexOptions.IgnoreCase & RegexOptions.Compiled);
        private Regex regexHttps = new Regex(@"https://", RegexOptions.IgnoreCase & RegexOptions.Compiled);
        private Regex titleRegex = new Regex(@"<title.*?>\s*(.+?)\s*</title>", RegexOptions.Compiled);

        //File storage names can only be changed by developer, not at runtime
        private static readonly string historyFileName = "history.csv"; //The file the history is stored in
        private static readonly string savedPagesFileName = "saved_pages.csv"; //The file the favourites and home page are stored in

        private TabPage thisTabPage; //Store a reference to the tab page this control is shown on
        private static TextBox logBox; //Textbox on the parent browser used for logging information to user

        private SPWebBrowser browser; //The browser this tab is part of

        //static reference to all current tabs. Can be used to loop through and apply operation to all tabs
        public static List<TabUserControl> AllTabs { get; private set; }

        private delegate int ChangePage(int num); //TODO: Implement this

        /// <summary>
        /// Constructor that opens tab to home page
        /// </summary>
        /// <param name="newTabPage">The tab page object this control will be on</param>
        /// <param name="browserLogBox">The browser's text box for logging information to user</param>
        /// <param name="browser">The browser containing this tab</param>
        public TabUserControl(TabPage newTabPage, TextBox browserLogBox, SPWebBrowser browser)
        {
            InitializeComponent();

            this.thisTabPage = newTabPage;
            this.browser = browser;

            localHistory = new List<String>();

            if (Favourites == null)
            {
                Favourites = new Dictionary<string, string>();
                LoadFavourites();
            }
            else
            {
                RefreshFavouritesBox(); //If the favourites are already in menu just refresh the display box to show them
            }
            
            homeUrl = getHomeURL();
            currentUrl = homeUrl; //This is set here incase first request fails. Avoids currentUrl being null
            goHome();

            //If this is the first tab assign the log box
            if(logBox == null)
            {
                logBox = browserLogBox;
            }

            //If this is the first tab to be created it will need to load history, others wont
            if(GlobalHistory == null)
            {
                LoadHistory();
            }

            if (AllTabs == null)
            {
                AllTabs = new List<TabUserControl>();
            }
            AllTabs.Add(this);
        }

        //
        /// <summary>
        /// Alternate constructor that opens a new tab to a specified webpage instead of the homepage
        /// </summary>
        /// <param name="newTabPage">The tab page object this control will be on</param>
        /// <param name="browserLogBox">The browser's text box for logging information to user</param>
        /// <param name="browser">The browser containing this tab</param>
        /// <param name="url">The url to open this new tab to</param>
        public TabUserControl(TabPage newTabPage, TextBox browserLogBox, SPWebBrowser browser, string url)
        {
            InitializeComponent();
            this.thisTabPage = newTabPage;
            logBox = browserLogBox;
            this.browser = browser;

            localHistory = new List<String>();

            if (Favourites == null)
            {
                Favourites = new Dictionary<string, string>();
                LoadFavourites();
            }
            else
            {
                RefreshFavouritesBox(); //If the favourites are already in menu just refresh the display box to show them
            }

            homeUrl = getHomeURL();
            currentUrl = homeUrl; //This is set here incase first request fails. Avoids currentUrl being null
            GetRequest(url);

            //If this is the first tab assign the log box
            if (logBox == null)
            {
                logBox = browserLogBox;
            }

            //If this is the first tab to be created it will need to load history, others wont
            if (GlobalHistory == null)
            {
                LoadHistory();
            }

            if(AllTabs == null)
            {
                AllTabs = new List<TabUserControl>();
            }
            AllTabs.Add(this);
        }

        /// <summary>
        /// Move back in history when user clicks back button, if possible.
        /// </summary>
        private void backButton_Click(object sender, EventArgs e)
        {
            MoveInHistory(Decrement);
        }

        /// <summary>
        /// Move forward in history when user click forward button, if possible
        /// </summary>
        private void forwardButton_Click(object sender, EventArgs e)
        {
            MoveInHistory(Increment);
        }

        /// <summary>
        /// Moves through the local history of this tab, sending a new http request to the new url
        /// </summary>
        /// <param name="moveFunc">A delegate function to operate on the current page number and change it to a new page number</param>
        private void MoveInHistory(ChangePage moveFunc)
        {
            //Make sure the position in history is always valid
            Contract.Ensures(localHistoryPosition > -1);
            Contract.Ensures(localHistoryPosition < localHistory.Count());

            int newHistoryPosition = moveFunc(localHistoryPosition);
            if(newHistoryPosition > -1 && newHistoryPosition < localHistory.Count())
            {
                localHistoryPosition = newHistoryPosition;
                GetRequest(localHistory[localHistoryPosition], false);
            }
        }

        //One liner functions for incrementing and decrementing.
        private int Increment(int x) { return ++x; } //value must be changed before returning
        private int Decrement(int x) { return --x; } //value must be changed before returning

        /// <summary>
        /// Send request for current url in textbow when user clicks go button
        /// </summary>
        private void searchButton_Click(object sender, EventArgs e)
        {
            string url = urlBar.Text;
            GetRequest(url);
        }

        /// <summary>
        /// Send request for current url in textbow when user hits enter
        /// </summary>
        private void urlBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string url = urlBar.Text;
                GetRequest(url);
            }
        }

        /// <summary>
        /// Refresh current page when user clicks refresh button
        /// </summary>
        private void refreshButton_Click(object sender, EventArgs e)
        {
            htmlOut.Text = ""; //Clear the text so that the user can see the page is being refreshed
            GetRequest(currentUrl, false); //Don't want refreshing to add page to history again
        }

        /// <summary>
        /// Open favourite dialog for current page when user clicks favourite button
        /// </summary>
        private void favouriteButton_Click(object sender, EventArgs e)
        {
            FavouriteCurrentPage();
        }

        /// <summary>
        /// Attempt at opening favourites with keyboard shortcut.
        /// Only works if this object is the focus object.
        /// </summary>
        private void TabUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Modifiers == Keys.Control)
            {
                FavouriteCurrentPage();
            }
        }

        /// <summary>
        /// Opens a new window allowing the user to associate a name with the current page and save it as a favourite
        /// </summary>
        private void FavouriteCurrentPage()
        {
            Form favWindow = new Form();
            favWindow.Size = new Size(200, 132);
            favWindow.FormBorderStyle = FormBorderStyle.FixedSingle;
            favWindow.MaximizeBox = false;

            favWindow.Controls.Add(new FavouriteNameBox(currentUrl, favWindow));
            favWindow.Show();
        }

        /// <summary>
        /// Return to home page when user clicks home button
        /// </summary>
        private void homeButton_Click(object sender, EventArgs e)
        {
            goHome();
        }

        /// <summary>
        /// Sets the current page as the homepage when user clicks set home button
        /// </summary>
        private void setHomeButton_Click(object sender, EventArgs e)
        {
            homeUrl = currentUrl; //Updates the home url in memory

            //Updates the saved home URL
            if (File.Exists(savedPagesFileName))
            {
                string[] currentData = File.ReadAllLines(savedPagesFileName);
                using (StreamWriter sw = new StreamWriter(savedPagesFileName))
                {
                    sw.WriteLine("h," + homeUrl); //Save homepage

                    foreach (string line in currentData)
                    {
                        String[] parts = line.Split(',');
                        if (parts.Length > 1 && !parts[0].Equals("h")) //Write all other saved pages back to file except homepage
                        {
                            sw.WriteLine(line);
                        }
                    }

                }
            }
            else
            {
                //No file of saved pages exists so we create one and write the homepage with an identifier for retrieving it
                using (StreamWriter sw = new StreamWriter(savedPagesFileName))
                {
                    sw.WriteLine("h," + currentUrl); //Save homepage
                }
            }
        }

        /// <summary>
        /// Sends an http request to a given url
        /// </summary>
        /// <param name="url">The url to send a request to</param>
        /// <param name="addToHistory">Declares whether this url should be added to the history or not</param>
        private async void GetRequest(string url, bool addToHistory = true)
        {
            if(!regexHttp.IsMatch(url) && !regexHttps.IsMatch(url))
            {
                url = "http://" + url;
            }

            urlBar.Text = url;

            //Multiple using blocks for disposable objects
            using (HttpClient client = new HttpClient())
            {
                try //Try statement in case request fails (e.g invalid format or no connection)
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        logBox.Text = "Http " + response.ToString().Substring(0, 15); //Displays the http response status code if a response is received

                        using (HttpContent content = response.Content)
                        {
                            string contentString = await content.ReadAsStringAsync(); //Retrieves the html as a string
                            htmlOut.Text = contentString; //Updates the display

                            Match titleMatch = titleRegex.Match(contentString); //Parse the title from the html using regular expressions
                            //Update this tabs title
                            if (titleMatch.Success) { thisTabPage.Text = titleMatch.Value.Substring(titleMatch.Value.IndexOf(">")+1, titleMatch.Value.LastIndexOf("<") - titleMatch.Value.IndexOf(">") - 1); }

                            currentUrl = url;

                            if (addToHistory)
                            {
                                AddToHistory(url);
                            }
                        }
                    }
                }
                catch (HttpRequestException hre)
                {
                    logBox.Text = "Could not send http request to: " + url;
                    htmlOut.Text = hre.Message;
                    thisTabPage.Text = "Error";
                }
                catch (Exception e)
                {
                    logBox.Text = "Generic catch reached: " + e.Message;
                    htmlOut.Text = e.Message;
                    thisTabPage.Text = "Error";
                }
            }
        }

        /// <summary>
        /// Loads the user's favourites from a file if there is one.
        /// </summary>
        private void LoadFavourites()
        {
            if (File.Exists(savedPagesFileName)) //Check if the file where home page is stored exists
            {
                using (StreamReader sr = new StreamReader(savedPagesFileName)) //Read through the file of saved pages
                {
                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] parts = line.Split(',');
                        if (parts.Length == 3 && parts[0].Equals("f")) //If a saved favourite
                        {
                            if (!Favourites.ContainsKey(parts[1]))
                            {
                                Favourites.Add(parts[1], parts[2]);
                            }
                        }
                    }
                    RefreshFavouritesBox();
                }
            }
        }

        /// <summary>
        /// Loads the user's history from file if there is one
        /// </summary>
        private void LoadHistory()
        {

            GlobalHistory = new List<KeyValuePair<string, string>>(); //Create an empty list for history to be stored in
            if (File.Exists(historyFileName)) //Check if the file where history is stored exists
            {
                using (StreamReader sr = new StreamReader(historyFileName)) //Read through the file of saved pages
                {
                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] parts = line.Split(',');
                        try
                        {
                            GlobalHistory.Add(new KeyValuePair<string, string>(parts[0], parts[1]));
                        }catch(IndexOutOfRangeException iore)
                        {
                            logBox.Text = "Cannot import history item; " + line;
                        }

                    }

                    RefreshFavouritesBox();
                }
            }
            //If file doesn't exist there is no history and list is left empty
        }

        /// <summary>
        /// Go to a favourite address when user clicks that favourite in list
        /// </summary>
        private void favouritesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String favouriteURL;
            if(Favourites.TryGetValue(favouritesBox.SelectedItem.ToString(), out favouriteURL)){
                GetRequest(favouriteURL);
            }
            favouritesBox.Text = ""; //Not working
        }

        /// <summary>
        /// Loads the user's homepage from file if there is one.
        /// If there is no file returns default home page.
        /// </summary>
        /// <returns>String containing the homepage url</returns>
        private string getHomeURL()
        {
            if (File.Exists(savedPagesFileName)) //Check if the file where home page is stored exists
            {
                using (StreamReader sr = new StreamReader(savedPagesFileName)) //Read through the file of saved pages
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] parts = line.Split(',');
                        if (parts.Length > 1 && parts[0].Equals("h")) //If a saved home page is found send an http request with it
                        {
                            return parts[1];
                        }
                    }
                }
            }
            //This statement is reached both if the file does not exist and if the file exists but contains no home page
            return "https://ztuu.itch.io"; //If the user has not set up a home page we provide them with out browsers default one
        }

        /// <summary>
        /// Changes this tabs current page to the home page.
        /// </summary>
        //Encapsulated this so can also call on startup as well as button click
        private void goHome()
        {
            GetRequest(homeUrl);
        }

        /// <summary>
        /// Adds a url to the user's saved favourites list.
        /// Will not work if name entered is a duplicate.
        /// </summary>
        /// <param name="name">The name to be associated with this favourite</param>
        /// <param name="url">THe url to be favourited</param>
        public static void AddFavourite(String name, String url)
        {
            if (!Favourites.ContainsKey(name))
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(savedPagesFileName))
                    {
                        sw.WriteLine("f," + name + "," + url);
                    }
                    logBox.Text = "Favourite added with name: " + name;
                    //Add favourite within program before writing to file. Ensures user doesn't see update in program but changes are not saved.
                    Favourites.Add(name, url);
                    foreach (TabUserControl tab in AllTabs)
                    {
                        tab.RefreshFavouritesBox();
                    }
                }
                catch (IOException ioe)
                {
                    logBox.Text = "Failed to add favourite, error saving data.";
                }
                catch (Exception e)
                {
                    logBox.Text = "Failed to add favourite, unknown error." + e.Message; ;
                }

            }
            else
            {
                logBox.Text = "You tried to add a favourite with a duplicate name. Favourite not added. Name: " + name;
            }
        }

        /// <summary>
        /// Removes one or more favourites from the user's current list.
        /// </summary>
        /// <param name="names">A list of the names of all favourites to remove</param>
        public static void RemoveFavourites(List<string> names)
        {
            if(names == null)
            {
                logBox.Text = "Error removing favourites.";
                return;
            }
            foreach(string name in names)
            {
                if (Favourites.ContainsKey(name))
                {
                    Favourites.Remove(name);
                }
            }
           
            foreach(TabUserControl tab in AllTabs)
            {
                tab.RefreshFavouritesBox();
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(savedPagesFileName))
                {
                    sw.WriteLine("h," + homeUrl); //Save homepage

                    foreach (KeyValuePair<string, string> favourite in Favourites)
                    {
                        sw.WriteLine("f," + favourite.Key + "," + favourite.Value);
                    }
                }
            }catch(IOException ioe)
            {
                logBox.Text = "Error removing favourites from saved data.";
            }
            catch(Exception e)
            {
                logBox.Text = "Unexpected error removing favourites." + e.Message;
            }
        }

        /// <summary>
        /// Adds a url to the user's history
        /// </summary>
        /// <param name="url">The url to be added to the user's history</param>
        private void AddToHistory(string url)
        {
            DateTime now = DateTime.Now;
            localHistory.Add(url);
            localHistoryPosition = localHistory.Count() - 1; //If we go to a new website we want the counter to be at the end of the list
            GlobalHistory.Add(new KeyValuePair<string, string>(url, now.ToString()));
            using (StreamWriter sw = File.AppendText(historyFileName))
            {
                sw.WriteLine(url + "," + now);
            }
            //TODO: Remove web pages ahead in history if we go to a page when not on the most recent
        }

        /// <summary>
        /// Updates the combo box containing the favourites so that it only displays the user's current favourites.
        /// Used on startup and after making changes to saved favourites
        /// </summary>
        private void RefreshFavouritesBox() {
            int boxCtr = 0;

            favouritesBox.Items.Clear(); //Clear all existing items from boxs before filling with current favourites
            foreach(KeyValuePair<string, string> blah in Favourites) {
                favouritesBox.Items.Insert(boxCtr++, blah.Key);
            }

        }

        /// <summary>
        /// Show history dialog when user clicks history button
        /// </summary>
        private void historyButton_Click(object sender, EventArgs e)
        {
            Form historyWindow = new Form();
            historyWindow.Size = new Size(300, 500);
            historyWindow.FormBorderStyle = FormBorderStyle.FixedSingle;
            historyWindow.MaximizeBox = false;
            historyWindow.Text = "History";

            historyWindow.Controls.Add(new HistoryBrowser(GlobalHistory, browser, historyWindow));
            historyWindow.Show();
        }

        /// <summary>
        /// Open delete favourite dialog when user clicks delete favourites button
        /// </summary>
        private void deleteFavButton_Click(object sender, EventArgs e)
        {
            Form deleteFavWindow = new Form();
            deleteFavWindow.Size = new Size(250, 350);
            deleteFavWindow.FormBorderStyle = FormBorderStyle.FixedSingle;
            deleteFavWindow.MaximizeBox = false;
            deleteFavWindow.Text = "Delete Favourites";

            deleteFavWindow.Controls.Add(new FavouriteDeletion(deleteFavWindow));
            deleteFavWindow.Show();
        }


    }
}
