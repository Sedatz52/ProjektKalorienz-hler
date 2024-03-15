using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalorienzähler.Model
{
    internal class Verbrauch
    {
        public int Id { get; set; }
        public DateTime Zeitpunkt { get; set; }
        public int Menge { get; set; }

    }

}
