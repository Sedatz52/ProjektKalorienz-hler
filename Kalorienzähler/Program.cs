using Kalorienzähler.Daten;
using System;

namespace Kalorienzähler
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new KalorienzählerContext())
            {
                // Füge Produkte hinzu
                var dolma = new Model.Produkt { Name = "Dolma", Kalorien = 150, Gramm = 100 };
                var sarma = new Model.Produkt { Name = "Sarma", Kalorien = 180, Gramm = 100 };
                var lahmacun = new Model.Produkt { Name = "Lahmacun", Kalorien = 300, Gramm = 100 };
                var iclikofte = new Model.Produkt { Name = "Içli Köfte", Kalorien = 250, Gramm = 100 };

                db.Produkte.AddRange(dolma, sarma, lahmacun, iclikofte);
                db.SaveChanges();

                // Füge einen Verbrauch hinzu
                var verbrauch = new Model.Verbrauch { Zeitpunkt = DateTime.Now, Menge = 200 };
                db.Verbrauche.Add(verbrauch);
                db.SaveChanges();
            }
        }
    }

