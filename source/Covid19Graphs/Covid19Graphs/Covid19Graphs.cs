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

        }

        private void graph_Paint(object sender, PaintEventArgs e) {

            //finds out how much to separate the points by
            float XpointSeparation = (float)graph.Width / (float)Data.longestArray;
            float YpointSeparation = (float)graph.Height / (float)Data.biggestCase;


            //loops through each of the datas
            for (int i = 0; i < allData.Count; i++) {

                SolidBrush b = new SolidBrush(allData[i].graphColor);

                for (int j = 0; j < allData[i].listOfDailyCases.Length; j++) {

                    Point point = new Point((int)(j * XpointSeparation), graph.Height - (int)(allData[i].listOfDailyCases[j].Cases * YpointSeparation));


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
    }
}
