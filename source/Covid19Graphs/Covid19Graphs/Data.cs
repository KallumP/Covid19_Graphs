using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Graphs {
    public abstract class Data {




    }


    public class Confirmed : Data {

        public string Country { get; set; }
        public string Date { get; set; }
        public int Cases { get; set; }

    }
}
