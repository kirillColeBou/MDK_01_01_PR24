﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModules
{
    public class Type_of_troops
    {
        public int Id_type_of_troops { get; set; }
        public string Name_type_of_troops { get; set; }
        public string Description { get; set; }
        public int Companies { get; set; }
        public int Count_serviceman { get; set; }
        public DateTime Date_foundation { get; set; }
    }
}
