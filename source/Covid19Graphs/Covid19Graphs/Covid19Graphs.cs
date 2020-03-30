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
        List<Data> normalizedData;

        int pointSize = 9;



        public Covid19Graphs() {
            InitializeComponent();
        }


        private async void Covid19Graphs_Load(object sender, EventArgs e) {

            //sets up the api helper class
            ApiHelper.InitializeClient();

            //sets up the list of data point arrays
            allData = new List<Data>();

            await LoadData();

            graph.Invalidate();
        }

        private async Task LoadData() {

            DailyCases[] pulledCases;

            //pulls the uk data
            pulledCases = await CountryData.PullConfirmedData("united-kingdom");
            allData.Add(new Data("United Kingdom", pulledCases, Color.Red));

            //pulls the italy data
            pulledCases = await CountryData.PullConfirmedData("italy");
            allData.Add(new Data("Italy", pulledCases, Color.Purple));

            //pulls the UK data
            pulledCases = await CountryData.PullConfirmedData("US");
            allData.Add(new Data("US", pulledCases, Color.Green));

            //pulls the UK data
            pulledCases = await CountryData.PullConfirmedData("spain");
            allData.Add(new Data("Spain", pulledCases, Color.Blue));

        }

        private void graph_Paint(object sender, PaintEventArgs e) {

            //finds out how much to separate the points by
            float xPointSeparation = (float)graph.Width / (float)Data.longestArray;
            float yPointSeparation = (float)graph.Height / (float)Data.biggestCase;

            int xNormalizer;

            //loops through each of the datas
            for (int i = 0; i < allData.Count; i++) {

                SolidBrush b = new SolidBrush(allData[i].graphColor);

                xNormalizer = Data.longestArray - allData[i].listOfDailyCases.Length;

                for (int j = 0; j < allData[i].listOfDailyCases.Length; j++) {

                    Point point = new Point((int)((xNormalizer + j) * xPointSeparation), graph.Height - (int)(allData[i].listOfDailyCases[j].Cases * yPointSeparation));


                    e.Graphics.FillEllipse(
                        b,
                        point.X,
                        point.Y,
                        pointSize,
                        pointSize);

                }
            }
        }

        private void Covid19Graphs_Resize(object sender, EventArgs e) {
            graph.Invalidate();
        }

        void NormalizingData(int cutoffPoint) {

            
        }

        private void normalise_btn_Click(object sender, EventArgs e) {
            
            NormalisedData n = new NormalisedData(allData, this);

            n.Show();
            Hide();
        }
    }
}
