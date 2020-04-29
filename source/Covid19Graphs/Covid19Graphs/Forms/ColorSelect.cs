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
    public partial class ColorSelect : Form {


        /// <summary>
        /// The value chosen by the user
        /// </summary>
        static public Color Chosen { get; set; }

        public ColorSelect() {
            InitializeComponent();

            if (Chosen == null)

                Chosen = Color.Black;

        }

        private void select_btn_Click(object sender, EventArgs e) {
            Close();
        }

        private void orange_btn_Click(object sender, EventArgs e) {
            Chosen = orange_btn.ForeColor;
        }

        private void yellow_btn_Click(object sender, EventArgs e) {
            Chosen = yellow_btn.ForeColor;
        }
    }
}
