using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobelConsole.Models
{
    class Adat
    {
        //év;típus;keresztnév;vezetéknév
        public int Id { get; set; }
        public int Ev { get; set; }
        public Fajta Tipus { get; set; }
        public string KeresztNev { get; set; }

        public string VezetekNev { get; set; }

        public Adat(int ev, Fajta tipus, string keresztNev, string vezetekNev)
        {
            Ev = ev;
            Tipus = tipus;
            KeresztNev = keresztNev;
            VezetekNev = vezetekNev;
        }

        public Adat()
        {
        }
        public override string ToString()
        {
            return Ev +"; "+Tipus+"; "+KeresztNev+"; "+VezetekNev;
        }
    }
}
