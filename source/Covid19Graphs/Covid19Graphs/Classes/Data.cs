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

        public CountryObj CountryData { get; set; }
        public CasesObj[] DailyCasesData { get; set; }
        public Color GraphColor { get; set; }

        public Data(CountryObj _country, CasesObj[] _cases, Color _color) {
            CountryData = _country;
            DailyCasesData = _cases;
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

        public static void FindBiggestValues(List<Data> allData) {

            longestArray = -1;
            biggestCase = -1;

            foreach (Data d in allData) {

                //checks if the new array is longers than the current longest array
                if (d.DailyCasesData.Length > longestArray)

                    //updates what the longest array is
                    longestArray = d.DailyCasesData.Length;

                //checks if the number of cases in the final day is bigger than the current biggest number of cases
                if (d.DailyCasesData[d.DailyCasesData.Length - 1].Cases > biggestCase)

                    //updates what the biggest number of cases is
                    biggestCase = d.DailyCasesData[d.DailyCasesData.Length - 1].Cases;
            }

        }
    }
}
