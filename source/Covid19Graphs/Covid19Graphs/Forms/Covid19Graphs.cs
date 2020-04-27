﻿using System;
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

        /// <summary>
        /// All the available countries
        /// </summary>
        List<CountryObj> allCountries;

        /// <summary>
        /// All the country data
        /// </summary>
        List<Data> allData;

        int pointSize = 10;

        /// <summary>
        /// All the labels showing the country names in the right color
        /// </summary>
        public List<Label> countryNames_txt { get; set; }

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
            countryNames_txt = new List<Label>();

            //pulls all countrees
            await LoadAllCountries();

            //loads up the default data
            await LoadDefaultData();

            //draws the graph
            graph.Invalidate();
        }

        /// <summary>
        /// Loads up the starting datas for the program
        /// </summary>
        /// <returns></returns>
        private async Task LoadDefaultData() {

            //checks to see if there is atleast one country in the list
            if (allCountries.Count > 0)

                //pulls the first country in the list
                await PullData(allCountries[0], Color.Red, new Point(normalise_btn.Location.X, normalise_btn.Location.Y + 30));

            //await PullData("united-kingdom", "UK", Color.Red, new Point(normalise_btn.Location.X, normalise_btn.Location.Y + 30));
            //await PullData("italy", "Italy", Color.Purple, countryNames_txt[countryNames_txt.Count - 1].Location);
            //await PullData("US", "America", Color.Green, countryNames_txt[countryNames_txt.Count - 1].Location);
            //await PullData("sri-lanka", "Sri Lanka", Color.Blue, countryNames_txt[countryNames_txt.Count - 1].Location);
        }

        /// <summary>
        /// Pulls data about the entered country
        /// </summary>
        /// <param name="slug">The slug (country-identifier) for the wanted country</param>
        /// <param name="_countryName">The name of the country</param>
        /// <param name="graphColor">The color of the countries graph points</param>
        /// <param name="lastTxtLoc">The point to base the next textbox location on</param>
        /// <returns></returns>
        async Task PullData(CountryObj countryObj, Color graphColor, Point lastTxtLoc) {

            CasesObj[] pulledCases;
            Label t = new Label();

            //pulls the entered country data
            pulledCases = await DataPuller.PullConfirmedData(countryObj.Slug);

            //adds the newly pulled data into the list of all datas
            allData.Add(new Data(countryObj, pulledCases, graphColor));

            //creates a new text box with the country name and color
            t.Location = new Point(lastTxtLoc.X, lastTxtLoc.Y + 30);
            t.Text = countryObj.Country;
            t.Font = new Font(t.Font.FontFamily, 12);
            t.ForeColor = graphColor;
            t.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Controls.Add(t);

            //adds the new text box
            countryNames_txt.Add(t);
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

                xNormalizer = Data.longestArray - allData[i].listOfDailyCases.Length;

                //loops through each of the cases
                for (int j = 0; j < allData[i].listOfDailyCases.Length; j++) {

                    Point point = new Point((int)((xNormalizer + j) * xPointSeparation), graph.Height - (int)(allData[i].listOfDailyCases[j].Cases * yPointSeparation));

                    //draws the point
                    e.Graphics.FillEllipse(
                        b,
                        point.X,
                        point.Y - graphPush,
                        pointSize,
                        pointSize);
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

            NormalisedData n = new NormalisedData(allData, this);

            n.Show();
            Hide();
        }

        private async Task LoadAllCountries() {

            //pulls all of the countries in an array structure
            CountryObj[] arrayOfCountries = await DataPuller.PullAllCountries();

            //loops through each country in the array
            foreach (CountryObj c in arrayOfCountries)

                //adds the country to the list of all countries
                allCountries.Add(c);
        }
    }
}
