﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalorienzähler.Model
{
    internal class Produkt
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Kalorien { get; set; } 
        public int Gramm { get; set; }
    }
}
