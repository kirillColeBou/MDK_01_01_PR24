using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModules
{
    public class Parts
    {
        public int Id_part { get; set; }
        public int Locations { get; set; }
        public int Type_of_troops { get; set; }
        public int Weapons { get; set; }
        public int Companies { get; set; }
        public string Count_companies { get; set; }
        public string Count_technique { get; set; }
        public string Count_weapons { get; set; }
        public DateTime Date_of_foundation { get; set; }
    }
}