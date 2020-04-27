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
    public partial class CountrySelect : Form {

        Covid19Graphs mainWindow;

        List<CountryObj> countries;

        public CountrySelect(Covid19Graphs main, List<CountryObj> _countries) {
            InitializeComponent();

            mainWindow = main;
            countries = _countries;
        }

        private void CountrySelect_Load(object sender, EventArgs e) {
            ShowAllCountries();
        }

        /// <summary>
        /// Shows all the countries in the form of checkboxes
        /// </summary>
        void ShowAllCountries() {

            int verticalSpacing = 25;

            foreach (CountryObj c in countries) {

                CheckBox selected = new CheckBox();

                selected.Text = c.Country;

                if (Selected(c))
                    selected.Checked = true;
                else
                    selected.Checked = false;

                selected.Location = new Point(10, allCountries_pnl.Controls.Count * verticalSpacing);

                selected.CheckedChanged += CheckChange;

                allCountries_pnl.Controls.Add(selected);
            }
        }

        /// <summary>
        /// Checks if a country is selected in the main window
        /// </summary>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        bool Selected(CountryObj toCheck) {

            //loops through each of the data from the main window
            foreach (Data d in mainWindow.allData)

                //checks if the current data's country is the same as the one being checked against
                if (d.CountryData.Country == toCheck.Country)

                    //returns that this country is selected
                    return true;

            //returns that the country was not found
            return false;
        }

        /// <summary>
        /// Event for a checkbox status changing
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        void CheckChange(Object source, EventArgs e) {

            //turns the source back into a checkbox object
            CheckBox c = source as CheckBox;

            //gets the country object from the name of the clicked checkbox
            CountryObj country = ReturnCountryObj(c.Text, countries);

            //selects or deselectes based on the check status of the checkbox
            if (c.Checked)
                Select(country);

            else
                DeSelect(country);
        }

        /// <summary>
        /// Returns the country object with the name of the input string
        /// </summary>
        /// <param name="countryName">The name of the country to return</param>
        /// <returns></returns>
        public static CountryObj ReturnCountryObj(string countryName, List<CountryObj> searchLiist) {

            //loops through each country
            foreach (CountryObj c in searchLiist)

                //checks if the country being checked is the same as the input
                if (countryName == c.Country)

                    //returns the country being checked
                    return c;

            //returns null for nothing found
            return null;
        }

        /// <summary>
        /// Selects the country in the main window
        /// </summary>
        /// <param name="toPullData"></param>
        async void Select(CountryObj toPullData) {

            //checks to see if this is the first country
            if (mainWindow.countryNames_txt.Count == 0)

                //puts the first label under the normalise button
                await mainWindow.PullData(toPullData, Color.Red, new Point(mainWindow.normalise_btn.Location.X, mainWindow.normalise_btn.Location.Y + 30));

            else

                //puts the new label under the previous label
                await mainWindow.PullData(toPullData, Color.Red, mainWindow.countryNames_txt[mainWindow.countryNames_txt.Count - 1].Location);
        }

        void DeSelect(CountryObj toRemove) {

            mainWindow.RemoveCountryData(toRemove);
        }

        private void back_btn_Click(object sender, EventArgs e) {
            Close();
        }

    }
}
