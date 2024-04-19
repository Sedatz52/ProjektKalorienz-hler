using Kalorienzähler.Daten;
using System;
using System.Linq;

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
                var menemen = new Model.Produkt { Name = "Menemen", Kalorien = 400, Gramm = 100 };
                var künefe = new Model.Produkt { Name = "Künefe", Kalorien = 600, Gramm = 100 };

                db.Produkte.AddRange(dolma, sarma, lahmacun, menemen, künefe);
                db.SaveChanges();

                // Frage den Benutzer nach dem gegessenen Produkt
                Console.WriteLine("Welches Produkt haben Sie gegessen?");
                string produktName = Console.ReadLine();

                // Suche nach dem eingegebenen Produkt
                var produkt = db.Produkte.FirstOrDefault(p => p.Name.ToLower() == produktName.ToLower());

                if (produkt != null)
                {
                    Console.WriteLine("Wie viele Gramm haben Sie gegessen?");
                    int mengeGramm;
                    while (!int.TryParse(Console.ReadLine(), out mengeGramm))
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine ganze Zahl ein:");
                    }

                    // Berechne die gegessenen Kalorien
                    double kalorienGegessen = produkt.Kalorien * ((double)mengeGramm / produkt.Gramm);
                    Console.WriteLine($"Sie haben {kalorienGegessen:F2} Kalorien gegessen.");

                    // Speichern Sie den Verbrauch in der Datenbank
                    var verbrauch = new Model.Verbrauch { Zeitpunkt = DateTime.Now, Menge = mengeGramm };
                    db.Verbrauche.Add(verbrauch);
                    db.SaveChanges();

                    DateTime heute = DateTime.Today;
                    // Überblick über das Essen heute
                    var verbraucheHeute = db.Verbrauche
                        .Where(v => v.Zeitpunkt.Date == heute)
                        .OrderBy(v => v.Zeitpunkt);

                    double gesamtKalorienHeute = 0;

                    Console.WriteLine("Überblick über das Essen heute:");
                    foreach (var verbrauchHeute in verbraucheHeute)
                    {
                        // Holen Sie das zugehörige Produkt aus der Datenbank
                        var produktVonVerbrauch = db.Produkte.FirstOrDefault(p => p.Id == verbrauchHeute.Id);

                        // Zeigen Sie den Überblick über das Essen mit Produktinformationen an
                        Console.WriteLine($"{verbrauchHeute.Zeitpunkt.ToShortTimeString()} - {produktVonVerbrauch.Name} ({verbrauchHeute.Menge} Gramm)");

                        // Berechnen Sie die Kalorien für dieses Produkt
                        double kalorienFürProdukt = produktVonVerbrauch.Kalorien * ((double)verbrauchHeute.Menge / produktVonVerbrauch.Gramm);
                        Console.WriteLine($"    Kalorien: {kalorienFürProdukt:F2}");

                        gesamtKalorienHeute += kalorienFürProdukt;
                    }

                    // Gesamtkalorien für heute anzeigen
                    Console.WriteLine($"Gesamtkalorien heute: {gesamtKalorienHeute:F2}");
                }

                }
            }
        }
    }







