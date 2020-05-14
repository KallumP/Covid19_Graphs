using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covid19Graphs {
    public partial class Covid19Graphs : Form {

        #region Variables & Properties
        /// <summary>
        /// All the available countries
        /// </summary>
        List<CountryObj> allCountries;

        /// <summary>
        /// All the country data
        /// </summary>
        public List<Data> allData { get; set; }

        /// <summary>
        /// All the labels showing the country names in the right color
        /// </summary>
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public Covid19Graphs() {
            InitializeComponent();
        }

        /// <summary>
        /// Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Covid19Graphs_Load(object sender, EventArgs e) {

            //sets up the api helper class
            DataPuller.InitializeClient();

            //sets up the lists
            allData = new List<Data>();
            allCountries = new List<CountryObj>();

            //makes the vertical scroll bar always visible
            countryTitle_pnl.VerticalScroll.Enabled = true;
            countryTitle_pnl.VerticalScroll.Visible = true;
            countryTitle_pnl.AutoScroll = true;

            //pulls all countrees
            await LoadAllCountries();

            //loads up the default data
            await LoadDefaultData();
        }

        /// <summary>
        /// Loads up the starting datas for the program
        /// </summary>
        /// <returns></returns>
        private async Task LoadDefaultData() {

            CountryObj toPull;

            toPull = CountrySelect.ReturnCountryObj("United Kingdom", allCountries);
            if (toPull != null)
                await PullData(toPull, Color.Red);


            toPull = CountrySelect.ReturnCountryObj("Italy", allCountries);
            if (toPull != null)
                await PullData(toPull, Color.Purple);


            toPull = CountrySelect.ReturnCountryObj("United States of America", allCountries);
            if (toPull != null)
                await PullData(toPull, Color.Green);


            toPull = CountrySelect.ReturnCountryObj("Sri Lanka", allCountries);
            if (toPull != null)
                await PullData(toPull, Color.Blue);
        }

        /// <summary>
        /// Pulls data about the entered country
        /// </summary>
        /// <param name="slug">The slug (country-identifier) for the wanted country</param>
        /// <param name="_countryName">The name of the country</param>
        /// <param name="graphColor">The color of the countries graph points</param>
        /// <param name="lastTxtLoc">The point to base the next textbox location on</param>
        /// <returns></returns>
        public async Task PullData(CountryObj countryObj, Color graphColor) {

            //the tobe location of the new 
            Point location = new Point(0, 0);

            //checks if this is not the first label
            if (countryTitle_pnl.Controls.Count != 0)

                //adds the label under the last label
                location.Y = countryTitle_pnl.Controls[countryTitle_pnl.Controls.Count - 1].Location.Y + countryTitle_pnl.Controls[countryTitle_pnl.Controls.Count - 1].Height + 30;

            CasesObj[] pulledCases;
            Label t = new Label();

            //pulls the entered country data
            pulledCases = await DataPuller.PullConfirmedData(countryObj.Slug);

            //checks to see if the pulled country data had any data
            if (pulledCases.Length > 0) {

                //adds the newly pulled data into the list of all datas
                allData.Add(new Data(countryObj, pulledCases, graphColor));

                //creates and sets up a new text box with the country name and color
                t.Location = location;
                t.Text = countryObj.Country;
                t.Font = new Font(t.Font.FontFamily, 12);
                t.ForeColor = graphColor;
                t.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                t.AutoSize = true;
                t.MaximumSize = new Size(normalise_btn.Width, 0);
                countryTitle_pnl.Controls.Add(t);

                //draws the graph
                graph.Invalidate();
            }
        }

        /// <summary>
        /// Removes a country object from the list of all data 
        /// </summary>
        /// <param name="toRemove"></param>
        public void RemoveCountryData(CountryObj toRemove) {

            //loops through all the data
            for (int i = allData.Count() - 1; i >= 0; i--) {

                //checks if the current country data is the one to remove
                if (allData[i].CountryData == toRemove) {

                    //loops through each of the textboxes
                    for (int j = 0; j < countryTitle_pnl.Controls.Count; j++) {

                        //checks if the text box's text was the same as the country to remove's name
                        if (countryTitle_pnl.Controls[j].Text == toRemove.Country) {

                            //removes the text box from the text box list and the controls list
                            Controls.Remove(countryTitle_pnl.Controls[j]);
                            countryTitle_pnl.Controls.Remove(countryTitle_pnl.Controls[j]);
                            RealignCountryLabels();
                        }
                    }

                    //removes the country data
                    allData.Remove(allData[i]);

                    //refinds the biggest values
                    Data.FindBiggestValues(allData);

                    //redraws the graph
                    graph.Invalidate();

                    //stops the search
                    break;
                }
            }
        }

        /// <summary>
        /// Graph paint event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graph_Paint(object sender, PaintEventArgs e) {

            //the amount to push the graph up by
            int graphPush = 20;

            //finds out how much to separate the points by
            float xPointSeparation = (float)graph.Width / (float)Data.longestArray;
            float yPointSeparation = ((float)graph.Height - graphPush) / (float)Data.biggestCase;

            int xNormalizer;

            //loops through each of the datas
            for (int i = 0; i < allData.Count; i++) {

                SolidBrush b = new SolidBrush(allData[i].GraphColor);

                xNormalizer = Data.longestArray - allData[i].DailyCasesData.Length;

                //loops through each of the cases
                for (int j = 0; j < allData[i].DailyCasesData.Length; j++) {

                    Point point = new Point((int)((xNormalizer + j) * xPointSeparation), graph.Height - (int)(allData[i].DailyCasesData[j].Cases * yPointSeparation));

                    //draws the point
                    e.Graphics.FillEllipse(
                        b,
                        point.X,
                        point.Y - graphPush,
                        Settings.graphNodeSize,
                        Settings.graphNodeSize);
                }
            }
        }

        /// <summary>
        /// Form resize event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Covid19Graphs_Resize(object sender, EventArgs e) {

            graph.Invalidate();
        }

        /// <summary>
        /// Opens up the normalized data form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void normalise_btn_Click(object sender, EventArgs e) {

            NormalisedData n = new NormalisedData(allData, countryTitle_pnl.Controls, this);

            n.Show();
            Hide();
        }

        /// <summary>
        /// Loads all the countries available to pull data for
        /// </summary>
        /// <returns></returns>
        private async Task LoadAllCountries() {

            //pulls all of the countries in an array structure
            CountryObj[] arrayOfCountries = await DataPuller.PullAllCountries();

            //loops through each country in the array
            foreach (CountryObj c in arrayOfCountries)

                //adds the country to the list of all countries
                allCountries.Add(c);
        }

        /// <summary>
        /// Event for openeing the country select form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countrySelect_btn_Click(object sender, EventArgs e) {
            CountrySelect win = new CountrySelect(this, allCountries);
            win.Show();
        }

        /// <summary>
        /// Removes gaps in the list of country labels
        /// </summary>
        void RealignCountryLabels() {

            //used to check if the label being checked is in the highest position
            int expectedHeight = 0;

            //loops through each label
            foreach (Label l in countryTitle_pnl.Controls) {

                //checks if the label is not in the right position
                if (l.Location.Y != expectedHeight)

                    //sets the location of the label to the correct position
                    l.Location = new Point(l.Location.X, expectedHeight);

                //updates the correct position to the next available space
                expectedHeight = l.Location.Y + l.Size.Height + 30;

            }

        }
    }
}
