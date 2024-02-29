using Microsoft.EntityFrameworkCore;
using System.Linq; 

class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database()) // Per garantire che il database venga chiuso
        {

            var clienti2 = new List<Cliente>
            {
                new Cliente {Nome = "Mario", Cognome = "Rossi", Telefono="333333333"},
                new Cliente {Nome = "Luca", Cognome = "Verdi", Telefono="252463124"},
                new Cliente {Nome = "Daje", Cognome = "Namo", Telefono="787783124"}
            };

            System.Console.WriteLine("clienti");
            db.InserisciClienti(clienti2);
            db.StampaClienti();

            var prodotti = new List<Prodotto>
            {
                new Prodotto {Nome = "Prodotto 1", Prezzo = 10, ClienteId = 1},
                new Prodotto {Nome = "Prodotto 2", Prezzo = 20, ClienteId = 1},
                new Prodotto {Nome = "Prodotto 3", Prezzo = 30, ClienteId = 2},
                new Prodotto {Nome = "Prodotto 4", Prezzo = 40, ClienteId = 2},
                new Prodotto {Nome = "Prodotto 5", Prezzo = 50, ClienteId = 3},
                new Prodotto {Nome = "Prodotto 6", Prezzo = 60, ClienteId = 3},
            };
            System.Console.WriteLine("prodotti per clienti");
            db.InserisciProdotti(prodotti);
            db.StampProdotti();
        }
    }           
}

/* usiamo var invece che la sintassi regolare perchè il programma non sa in anticipo che tipo di dati riceverà*/


/*La costruzione using in C# viene utilizzata per garantire la corretta gestione delle risorse, 
in particolare delle risorse che devono essere liberate dopo l'utilizzo, come le connessioni al database.*/