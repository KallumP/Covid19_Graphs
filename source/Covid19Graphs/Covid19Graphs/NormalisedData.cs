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
    public partial class NormalisedData : Form {

        Covid19Graphs mainWindow;

        List<Data> normalisedData;

        int pointSize;

        public NormalisedData(List<Data> _nomralised, Covid19Graphs _mainWindow) {
            InitializeComponent();

            normalisedData = _nomralised;

            mainWindow = _mainWindow;

            LoadData( 400);
        }

        private async Task LoadData(int cutoffPoint) {

            //loops through the 
            for (int i = 0; i < normalisedData.Count; i++) {


                int newArrayLength;

                for (int j = 0; i < normalisedData[i].listOfDailyCases.Length; j++) {


                    if (normalisedData[i].listOfDailyCases[j].Cases < cutoffPoint) {

                        continue;

                    } else {

                        newArrayLength = normalisedData[i].listOfDailyCases.Length - j;

                        break;
                    }
                }
            }

        }

        private void graph_Paint(object sender, PaintEventArgs e) {

            //finds out how much to separate the points by
            float xPointSeparation = (float)graph.Width / (float)Data.longestArray;
            float yPointSeparation = (float)graph.Height / (float)Data.biggestCase;


            //loops through each of the datas
            for (int i = 0; i < normalisedData.Count; i++) {

                SolidBrush b = new SolidBrush(normalisedData[i].graphColor);

                for (int j = 0; j < normalisedData[i].listOfDailyCases.Length; j++) {

                    Point point = new Point((int)((j) * xPointSeparation), graph.Height - (int)(normalisedData[i].listOfDailyCases[j].Cases * yPointSeparation));


                    e.Graphics.FillEllipse(
                        b,
                        point.X,
                        point.Y,
                        pointSize,
                        pointSize);

                }
            }
        }

        private void back_btn_Click(object sender, EventArgs e) {


            mainWindow.Show();
            Close();
        }

    }
}
