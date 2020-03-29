using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Covid19Graphs {

    public class Data {

        public static int longestArray = -1;
        public static int biggestCase = -1;

        public string country { get; set; }
        public DailyCases[] listOfDailyCases { get; set; }
        public Color graphColor { get; set; }

        public Data(string _country, DailyCases[] _cases, Color _color) {
            country = _country;
            listOfDailyCases = _cases;
            graphColor = _color;

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
