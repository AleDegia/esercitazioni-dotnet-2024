using Microsoft.EntityFrameworkCore;
using System.Linq; // Aggiunto per utilizzare ToList()

class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; }     //tabella database 'clienti'
    public DbSet<Prodotto> Prodotti { get; set; }   // tabella database 'prodotti'
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source =MyDatabase.sqlite");   //dico di usar il database 'MyDatabase'
    }

    public void InserisciClienti(List<Cliente> clienti)     //metodo per inserire lista di clienti nel database
    {
        Clienti.AddRange(clienti);  //AddRange aggiunge tutti i clienti presenti nella lista clienti al set Clienti del database
        SaveChanges();
    }

    public void StampaClienti()
    {
        //Include è una funzione di caricamento anticipato che consente di specificare quali proprietà correlate devono essere caricate insieme all'oggetto principale. In questo caso, stiamo dicendo a Entity Framework Core di caricare anche i prodotti associati ai clienti. ogni oggetto Cliente nella lista clienti conterrà anche una lista dei suoi prodotti associati.
        var clienti = Clienti.Include(c => c.Prodotti).ToList();  //metodo Include per caricare anche i prodotti associati ai clienti 
        foreach(var c in clienti)
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
     i dettagli dell'ordine (DettagliOrdine). La chiamata ThenInclude viene utilizzata per specificare la proprietà
      di navigazione all'interno dell'ordine per includere i dettagli dell'ordine.*/


    public void InserisciProdotti(List<Prodotto> prodotti)
    {
        Prodotti.AddRange(prodotti);  //AddRange aggiunge tutti i clienti presenti nella lista clienti al set Clienti del database
        SaveChanges();
    }

    public void StampProdotti()
    {
        var prodotti = Prodotti.ToList();
        foreach(var p in prodotti)
        {
            System.Console.WriteLine($"{p.Id} - {p.Nome} - {p.Prezzo} - {p.Cliente.Nome} - {p.Cliente.Cognome}");
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