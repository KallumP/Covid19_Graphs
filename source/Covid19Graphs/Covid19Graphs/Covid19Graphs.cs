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
        public Covid19Graphs() {
            InitializeComponent();

            //sets up the api helper class
            ApiHelper.InitializeClient();
        }



        private async Task LoadData() {

            Data confirmed = await CountryData.PullConfirmedData("united-kingdom");


        }

        private async void Covid19Graphs_Load(object sender, EventArgs e) {
            await LoadData();
        }
    }
}
