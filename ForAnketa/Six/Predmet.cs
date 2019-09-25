using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six
{
    class Predmet
    {
        public string name { get; set; }
        public double weigth { get; set; }
        public double price { get; set; }
        public Predmet(string Name, double Weight, double Prise)
        {
            name = Name;
            weigth = Weight;
            price = Prise;
        }
    }
}
