using Microsoft.EntityFrameworkCore;
using System.Linq; // Aggiunto per utilizzare ToList()
using System;
using Npgsql;

class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; }     //tabella database 'clienti'
    public DbSet<Prodotto> Prodotti { get; set; }   // tabella database 'prodotti'
    public DbSet<Ordine> Ordini { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Database=MyDatabase; Username=postgres; Password=dajenamo");
    }

    public void InserisciClienti(List<Cliente> clienti)     //metodo per inserire lista di clienti nel database
    {
        Clienti.AddRange(clienti);  //AddRange aggiunge tutti i clienti presenti nella lista clienti al set Clienti del database
        SaveChanges();
    }

    public void StampaClienti()
    {
        //Include è una funzione di caricamento anticipato che consente di specificare quali proprietà correlate devono essere caricate insieme all'oggetto principale. In questo caso, stiamo dicendo a Entity Framework Core di caricare anche i prodotti associati ai clienti. ogni oggetto Cliente nella lista clienti conterrà anche una lista dei suoi prodotti associati.
        var clienti = Clienti.Include(c => c.Prodotti).ToList();  // recupera i clienti e i loro prodotti associati dal database, e poi li trasforma in una lista di oggetti Cliente con i relativi prodotti inclusi.  carica tutti i clienti dal database e, utilizzando l'istruzione Include, carica anche i relativi prodotti associati ad ogni cliente. 
        foreach(var c in clienti)       //c è un singolo oggetto di tipo cliente nella lista clienti
        {
            System.Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome} {c.Telefono}");
            foreach(var p in c.Prodotti)
            {
                System.Console.WriteLine($"{p.Id} - {p.Nome} {p.Prezzo}");
            }
        }
    }
    
    /*var clienti = dbContext.Clienti.Include(c => c.Ordini).ThenInclude(o => o.DettagliOrdine).ToList();*/

    /*In questo esempio, stiamo recuperando i clienti dal database e includendo anche i loro ordini (Ordini) e
     i dettagli dell'ordine (DettagliOrdine).  carica tutti i clienti dal database e, utilizzando l'istruzione Include,
      carica anche i relativi prodotti associati ad ogni cliente. 
      è tipo fare SELECT * FROM Clienti LEFT JOIN Prodotti ON Clienti.Id = Prodotti.ClienteId;
      si può anche fare cosi: var clienti = Clienti.Include("Prodotti").ToList();*/


    public void InserisciProdotti(List<Prodotto> prodotti)
    {
        Prodotti.AddRange(prodotti);  //AddRange aggiunge tutti i clienti presenti nella lista clienti al set Clienti del database
        SaveChanges();
    }

    public void StampProdotti()
    {
        var prodotti = Prodotti.ToList(); //recupero i prodotti dal database
        foreach(var p in prodotti)
        {
            System.Console.WriteLine($"{p.Id} - {p.Nome} - {p.Prezzo} - {p.Cliente.Nome} - {p.Cliente.Cognome}");
        }
    }

    public void InserisciOrdini(List<Ordine> ordini)
    {
        Ordini.AddRange(ordini);
        SaveChanges();
    }

    public void StampaOrdini()
    {
        var ordini = Ordini.Include( o => o.Prodotto).ThenInclude( p => p.Cliente).ToList();
        foreach (var o in ordini)
        {
            System.Console.WriteLine($"{o.Id} - {o.Prodotto.Nome} - {o.Prodotto.Cliente.Nome} {o.Prodotto.Cliente.Cognome}");
        }
    }
}


// Database : DbContext

/*  Qui si definisce una classe chiamata Database che eredita dalla classe DbContext. 
  DbContext è una classe fornita da Entity Framework Core che rappresenta il contesto del database e fornisce
  le API per interagire con esso.
  DbContext Incapsula la connessione al database, il tracciamento degli oggetti, le operazioni di salvataggio e
  il recupero dei dati. Questo permette all'applicazione di concentrarsi sulla logica di business senza 
  doversi preoccupare dei dettagli di accesso ai dati.*/


  //public DbSet<Cliente> Clienti {get; set;} 

  /*Questa riga definisce una proprietà pubblica chiamata Clienti di tipo DbSet<Cliente>. 
  DbSet<T> è una classe fornita da Entity Framework Core che rappresenta una tabella del database. 
  Nel contesto di questo codice, sembra che si stia definendo una tabella chiamata Clienti, 
  presumibilmente per memorizzare dati relativi ai clienti.*/