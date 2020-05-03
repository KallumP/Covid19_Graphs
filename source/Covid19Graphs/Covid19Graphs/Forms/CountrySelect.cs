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
        int verticalSpacing = 25;

        Covid19Graphs mainWindow;

        List<CountryObj> countries;

        Color graphColor;

        /// <summary>
        /// Counstructor
        /// </summary>
        /// <param name="main"></param>
        /// <param name="_countries"></param>
        public CountrySelect(Covid19Graphs main, List<CountryObj> _countries) {
            InitializeComponent();

            mainWindow = main;
            countries = _countries;
        }

        /// <summary>
        /// Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountrySelect_Load(object sender, EventArgs e) {
            ShowAllCountries();
            SetupColorPick();
        }

        /// <summary>
        /// Shows all the countries in the form of checkboxes
        /// </summary>
        void ShowAllCountries() {

            //loops through each country
            foreach (CountryObj c in countries)

                //loads the country
                LoadCountryAsCheckBox(c);
        }

        /// <summary>
        /// Shows all countries of a given input
        /// </summary>
        /// <param name="toShow"></param>
        void ShowAllCountries(string toShow) {

            //removes all the checkboxes
            allCountries_pnl.Controls.Clear();

            //loops through each country
            foreach (CountryObj c in countries)

                //checks if the current country is the same as the input
                if (c.Country == toShow)

                    //loads the country
                    LoadCountryAsCheckBox(c);
        }

        /// <summary>
        /// Turns the input country into a checkbox
        /// </summary>
        /// <param name="country">The country to convert</param>
        void LoadCountryAsCheckBox(CountryObj country) {

            //a checkbox to work with
            CheckBox c = new CheckBox();

            //sets the checkbox's text to the country name of the input
            c.Text = country.Country;
            c.MaximumSize = new Size(allCountries_pnl.Width, 50);
            c.FlatStyle = FlatStyle.Flat;

            //checks if the country was already being shown in the main window
            if (Selected(country)) {

                //sets the check status to ticked
                c.Checked = true;

                //loops through each dataset in the main window
                foreach (Data d in mainWindow.allData) {

                    //checks if the data's country is the same as the input country
                    if (d.CountryData.Country == country.Country) {

                        //sets the checkbox font color to be the same as the graph color
                        c.ForeColor = d.GraphColor;

                        //stops searching
                        break;
                    }
                }

            } else {

                //sets the checkbox to unticked
                c.Checked = false;

                //sets the default color to black;
                c.ForeColor = Color.Black;
            }

            //sets the location of the checkbox under the last one
            c.Location = new Point(10, allCountries_pnl.Controls.Count * verticalSpacing);

            //sets up what method to call on click
            c.CheckedChanged += CheckChange;

            //adds the checkbox to the panel
            allCountries_pnl.Controls.Add(c);
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
            if (c.Checked) {

                Select(country, graphColor);

                c.ForeColor = graphColor;

            } else {
                
                DeSelect(country);

                c.ForeColor = Color.Black;
            }

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
        async void Select(CountryObj toPullData, Color graphColor) {

            //checks to see if this is the first country
            if (mainWindow.countryNames_txt.Count == 0)

                //puts the first label under the normalise button
                await mainWindow.PullData(toPullData, graphColor, new Point(mainWindow.normalise_btn.Location.X, mainWindow.normalise_btn.Location.Y + 30));

            else

                //puts the new label under the previous label
                await mainWindow.PullData(toPullData, graphColor, mainWindow.countryNames_txt[mainWindow.countryNames_txt.Count - 1].Location);
        }

        /// <summary>
        /// Tells the main window to remove a country's data
        /// </summary>
        /// <param name="toRemove">The country whos data to remove</param>
        void DeSelect(CountryObj toRemove) {

            mainWindow.RemoveCountryData(toRemove);
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void back_btn_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// Text change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBox_txt_TextChanged(object sender, EventArgs e) {

            //searches the new text
            ShowAllCountries(searchBox_txt.Text);
        }

        /// <summary>
        /// Sets up the buttons used to pick the graph color
        /// </summary>
        void SetupColorPick() {

            int verticalSpacing = 64;

            int height = 13 - 64;

            AddButton(new Size(58, 58), Color.Red, new Point(433, height += verticalSpacing));
            AddButton(new Size(58, 58), Color.Orange, new Point(433, height += verticalSpacing));
            AddButton(new Size(58, 58), Color.Yellow, new Point(433, height += verticalSpacing));
            AddButton(new Size(58, 58), Color.Lime, new Point(433, height += verticalSpacing));
            AddButton(new Size(58, 58), Color.Aqua, new Point(433, height += verticalSpacing));
            AddButton(new Size(58, 58), Color.Blue, new Point(433, height += verticalSpacing));
            AddButton(new Size(58, 58), Color.Fuchsia, new Point(433, height += verticalSpacing));

        }

        void AddButton(Size size, Color color, Point location) {
            Button b;

            b = new Button();
            b.ForeColor = Color.Black;
            b.Size = size;

            b.BackColor = color;
            b.Location = location;

            b.FlatStyle = FlatStyle.Flat;

            b.Click += ColorButtonClick;

            Controls.Add(b);
        }

        private void ColorButtonClick(object sender, EventArgs e) {

            //turns the source back into a button
            Button c = sender as Button;

            graphColor = c.BackColor;

        }
    }
}
