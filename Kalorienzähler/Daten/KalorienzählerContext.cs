using Kalorienzähler.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalorienzähler.Daten
{
  
    // GSOPizzaContext Klasse erbt von DbContext, einem Teil des Entity Frameworks
    internal class KalorienzählerContext : DbContext
    {
        // DbSet-Eigenschaften repräsentieren Tabellen in der Datenbank
        // Jede Eigenschaft ist stark typisiert mit einer Modellklasse
        public DbSet<Produkt> Produkte { get; set; } = null!;
        public DbSet<Verbrauch> Verbrauche { get; set; } = null!;
       
        

        // OnModelCreating-Methode wird verwendet, um das Modell und die Beziehungen mittels Fluent API zu konfigurieren
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definieren von Primärschlüsseln für jede Entität
            modelBuilder.Entity<Verbrauch>().HasKey (k => k.Id);
            
            modelBuilder.Entity<Produkt>().HasKey(p => p.Id);
           
            // Immer die Basis-Methode aufrufen, um das Basisverhalten einzuschließen
            base.OnModelCreating(modelBuilder);
        }

        // OnConfiguring-Methode wird verwendet, um die Datenbankverbindung und andere Konfigurationen einzustellen
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Überprüfen, ob der optionsBuilder bereits konfiguriert ist, wenn nicht, konfigurieren
            if (!optionsBuilder.IsConfigured)
            {
                // Konfigurieren der Verwendung der SQLite-Datenbank mit dem angegebenen Verbindungsstring
                optionsBuilder.UseSqlite(@"Data Source=C:\Users\Sedat.z2\source\repos\ProjektKalorienz-hler\Kalorienzähler\Kalorien.db");
            }

            // Immer die Basis-Methode aufrufen, um das Basisverhalten einzuschließen
            base.OnConfiguring(optionsBuilder);
        }
    }
}
