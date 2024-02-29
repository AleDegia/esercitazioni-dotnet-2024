using Microsoft.EntityFrameworkCore;
using System.Linq; // Aggiunto per utilizzare ToList()

class Database : DbContext
{
    public DbSet<Cliente> Clienti { get; set; } // "Clienti" con la "C" maiuscola per seguire la convenzione di nomi

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    public void InserisciClienti(List<Cliente> clienti)
    {
        Clienti.AddRange(clienti);  //AddRange aggiunge tutti i clienti presenti nella lista clienti al set Clienti del database
        SaveChanges();
    }

    public void StampaClienti()
    {
        var clienti = Clienti.ToList(); //recupera tutti i clienti del database
        foreach(var c in clienti)
        {
            System.Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome}");
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