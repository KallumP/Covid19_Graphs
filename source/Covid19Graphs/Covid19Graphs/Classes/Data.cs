using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Covid19Graphs {

    /// <summary>
    /// Holds information about a countries data
    /// </summary>
    public class Data {

        public static int longestArray = -1;
        public static int biggestCase = -1;

        public CountryObj CountryObj { get; set; }
        public CasesObj[] listOfDailyCases { get; set; }
        public Color GraphColor { get; set; }

        public Data(CountryObj _country, CasesObj[] _cases, Color _color) {
            CountryObj = _country;
            listOfDailyCases = _cases;
            GraphColor = _color;

            //checks if the new array is longers than the current longest array
            if (_cases.Length > longestArray)

                //updates what the longest array is
                longestArray = _cases.Length;

            //checks if the number of cases in the final day is bigger than the current biggest number of cases
            if (_cases[_cases.Length - 1].Cases > biggestCase)

                //updates what the biggest number of cases is
                biggestCase = _cases[_cases.Length - 1].Cases;
        }
    }
}
