using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobelConsole.Models
{
    public class Fajta
    {
        public int Id { get; set; }
        public string Tipus { get; set; }

        public Fajta(string tipus)
        {
            Tipus = tipus;
        }

        public Fajta()
        {
        }
    }
}
