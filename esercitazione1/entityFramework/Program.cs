class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database()) // Per garantire che il database venga chiuso
        {

            var clienti2 = new List<Cliente>
            {
                new Cliente {Nome = "Mario", Cognome = "Rossi"},
                new Cliente {Nome = "Luca", Cognome = "Verdi"},
                new Cliente {Nome = "Daje", Cognome = "Namo"}
            };

            db.InserisciClienti(clienti2);
            db.StampaClienti();
        }
    }           
}

/* usiamo var invece che la sintassi regolare perchè il programma non sa in anticipo che tipo di dati riceverà*/


/*La costruzione using in C# viene utilizzata per garantire la corretta gestione delle risorse, 
in particolare delle risorse che devono essere liberate dopo l'utilizzo, come le connessioni al database.*/