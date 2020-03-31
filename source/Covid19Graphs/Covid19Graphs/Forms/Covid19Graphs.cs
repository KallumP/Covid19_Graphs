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

        List<Data> allData;

        int pointSize = 10;

        public List<TextBox> countryNames_txt { get; set; }

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
            ApiHelper.InitializeClient();

            //sets up the list of data point arrays
            allData = new List<Data>();

            countryNames_txt = new List<TextBox>();

            await LoadData();

            graph.Invalidate();
        }

        /// <summary>
        /// Loads up the starting datas for the program
        /// </summary>
        /// <returns></returns>
        private async Task LoadData() {

            await PullData("united-kingdom", "United Kingdom", Color.Red, new Point(normalise_btn.Location.X, normalise_btn.Location.Y + 30));
            await PullData("italy", "Italy", Color.Purple, countryNames_txt[countryNames_txt.Count - 1].Location);
            await PullData("US", "America", Color.Green, countryNames_txt[countryNames_txt.Count - 1].Location);
            await PullData("sri-lanka", "Sri Lanka", Color.Blue, countryNames_txt[countryNames_txt.Count - 1].Location);
        
        }

        /// <summary>
        /// Pulls data about the entered country
        /// </summary>
        /// <param name="slug">The slug (country-identifier) for the wanted country</param>
        /// <param name="_countryName">The name of the country</param>
        /// <param name="graphColor">The color of the countries graph points</param>
        /// <param name="lastTxtLoc">The point to base the next textbox location on</param>
        /// <returns></returns>
        async Task PullData(string slug, string _countryName, Color graphColor, Point lastTxtLoc) {

            DailyCases[] pulledCases;
            TextBox t = new TextBox();

            //pulls the entered country data
            pulledCases = await CountryData.PullConfirmedData(slug);

            //adds the newly pulled data into the list of all datas
            allData.Add(new Data(_countryName, pulledCases, graphColor));

            //creates a new text box with the country name and color
            t.Location = new Point(lastTxtLoc.X, lastTxtLoc.Y + 30);
            t.Text = _countryName;
            t.ForeColor = graphColor;

            //adds the new text box
            countryNames_txt.Add(t);
        }

        /// <summary>
        /// Graph paint event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graph_Paint(object sender, PaintEventArgs e) {

            //the amount to pusht the graph up by
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
    }
}
