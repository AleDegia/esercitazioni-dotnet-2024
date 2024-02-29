class Program
{
    static void Main(string[] args)
    {
        using (var db = new Database()) // Per garantire che il database venga chiuso
        {
            var cliente = new Cliente { Nome = "Mario", Cognome = "Rossi" }; // Creazione nuovo cliente
            db.Clienti.Add(cliente); // Aggiunta del cliente al database
            var cliente2 = new Cliente {Nome = "Luca", Cognome = "Verdi"};
            db.Clienti.Add(cliente2); // Aggiunta del cliente al database
            db.SaveChanges(); // Salvataggio delle modifiche

            var clienti = db.Clienti.ToList(); // recupera tutti i record presenti nella tabella Clienti del database e li converte in una lista di oggetti. 
            foreach (var c in clienti)
            {
                System.Console.WriteLine($"{c.Id} - {c.Nome} {c.Cognome}"); // Stampa di tutti i clienti
            }
        }
    }
}

/* usiamo var invece che la sintassi regolare perchè il programma non sa in anticipo che tipo di dati riceverà*/


/*La costruzione using in C# viene utilizzata per garantire la corretta gestione delle risorse, 
in particolare delle risorse che devono essere liberate dopo l'utilizzo, come le connessioni al database.*/