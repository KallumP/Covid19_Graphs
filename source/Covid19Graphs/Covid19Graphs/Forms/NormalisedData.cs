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

        int pointSize = 10;

        int longestArray = -1;

        public NormalisedData(List<Data> _normalised, Control.ControlCollection countryTitleControls, Covid19Graphs _mainWindow) {

            InitializeComponent();

            normalisedData = new List<Data>(_normalised);

            mainWindow = _mainWindow;

            LoadData(100);

            //adds the list of country title labels into the panel
            foreach (Control c in countryTitleControls) 

                countryTitles_pnl.Controls.Add(c);
            
            graph.Invalidate();
        }


        void LoadData(int cutoffPoint) {

            //loops through the list of datas
            for (int i = 0; i < normalisedData.Count; i++) {

                int newArrayLength = -1;
                int nextStart = -1;

                //loops through the data's cases by day
                for (int j = 0; j < normalisedData[i].DailyCasesData.Length; j++) {

                    //checks if the case number is smaller than the cutoff point
                    if (normalisedData[i].DailyCasesData[j].Cases < cutoffPoint) {

                        //does nothing
                        continue;

                    } else {

                        //saves how big the new array should be
                        newArrayLength = normalisedData[i].DailyCasesData.Length - j;

                        nextStart = j;

                        //stops looping
                        break;
                    }
                }

                //checks to see if there were any data above the cutoff point
                if (nextStart != -1) {

                    //updates the longest array variable
                    if (newArrayLength > longestArray)
                        longestArray = newArrayLength;

                    //creates a new array to hold the normalised data
                    CasesObj[] normalisedCases = new CasesObj[newArrayLength];

                    int normalisedIncrementor = 0;

                    //loops through all the data that is bigger than the cutoff point
                    for (int j = nextStart; j < normalisedData[i].DailyCasesData.Length; j++) {

                        normalisedCases[normalisedIncrementor] = normalisedData[i].DailyCasesData[j];

                        normalisedIncrementor++;
                    }

                    //updates the list of cases with the normalised one
                    normalisedData[i].DailyCasesData = normalisedCases;
                }
            }
        }


        private void back_btn_Click(object sender, EventArgs e) {
            mainWindow.Show();
            Close();
        }

        private void graph_Paint(object sender, PaintEventArgs e) {

            int graphPush = 20;

            //finds out how much to separate the points by
            float xPointSeparation = (float)graph.Width / (float)longestArray;
            float yPointSeparation = ((float)graph.Height - graphPush) / (float)Data.biggestCase;

            //loops through each of the datas
            for (int i = 0; i < normalisedData.Count; i++) {

                SolidBrush b = new SolidBrush(normalisedData[i].GraphColor);

                for (int j = 0; j < normalisedData[i].DailyCasesData.Length; j++) {

                    Point point = new Point((int)(j * xPointSeparation), graph.Height - (int)(normalisedData[i].DailyCasesData[j].Cases * yPointSeparation));

                    e.Graphics.FillEllipse(
                        b,
                        point.X,
                        point.Y - graphPush,
                        Settings.graphNodeSize,
                        Settings.graphNodeSize);
                }
            }
        }

        private void NormalisedData_Resize(object sender, EventArgs e) {
            graph.Invalidate();
        }
    }
}
