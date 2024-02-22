//dotnet add package System.Data.Sqlite  
using System.Data.SQLite;
using System.Diagnostics;                           //importa il namespace necessario per lavorare con SQLite in C#.

class Program2
{
    static void Main(string[] args)
    {
        string path = @"database.db";               //la rotta del file del database
        if(!File.Exists(path))                      //se il file del database non esiste lo crea
        {
            SQLiteConnection.CreateFile(path);      //crea il file del database
            SQLiteConnection connection = new SQLiteConnection($"Data Source = {path}; Version=3;");    //crea la connessione al database(dico quale database usare e la versione di SQLite da usare. )
            connection.Open();   //apre la connessione al database 
            string sql = @"
                CREATE TABLE prodotti (id INTEGER PRIMARY KEY AUTOINCREMENT, nome TEXT UNIQUE, prezzo REAL, quantita INTEGER CHECK (quantita >= 0));
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p1', 1, 10);
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p2', 2, 20);
                INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('p3', 3, 30);
                ";
            
            //Questo oggetto rappresenta un comando SQL da eseguire sul database SQLite. Gli viene passata una stringa sql, che contiene l'istruzione SQL da eseguire, e un oggetto SQLiteConnection chiamato connection, che rappresenta la connessione al database SQLite su cui verrà eseguito il comando.
            SQLiteCommand command = new SQLiteCommand(sql, connection);         //crea il comando sql per eseguire le query
            command.ExecuteNonQuery();                                          //esegue il comando sql sulla connessione al database
            connection.Close();                                                 //chiude la connessione al database
        }
        while (true)
        {
            System.Console.WriteLine("1 - Inserisci prodotto");
            System.Console.WriteLine("2 - Visualizza prodotti");
            System.Console.WriteLine("3 - Elimina prodotto");
            System.Console.WriteLine("4 - Modifica prodotto");
            System.Console.WriteLine("5 - Esci");
            string scelta = Console.ReadLine()!;

            switch(scelta)
            {
                case "1":
                    InserisciProdotti();
                    break;
                case "2":
                    VisualizzaProdotti();
                    break;
                case "3":
                    EliminaProdotto();
                    break;
                case "4":
                    ModificaProdotto();
                    break;
                case "5":
                    break;
            }
        }
    }

    static void InserisciProdotti()
    {
        System.Console.WriteLine("Inserisci il nome del prodotto");
        string nome = Console.ReadLine()!;
        System.Console.WriteLine("Inserisci il prezzo del prodotto");
        string prezzo = Console.ReadLine();
        System.Console.WriteLine("Inserisci la quantità del prodotto");
        string quantita = Console.ReadLine();
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3");          //crea la connessione al db
        connection.Open();   //apre la connessione al database 
        string sql = $"INSERT INTO prodotti (nome, prezzo, quantita) VALUES ('{nome}', {prezzo}, {quantita})";   //con '' capisce che è un TEXT mentre gli altri capisce che sono INTEGER
        SQLiteCommand command = new SQLiteCommand(sql, connection);         //crea il comando
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void VisualizzaProdotti()
    {
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3"); 
        connection.Open();
        string sql = "SELECT * FROM prodotti";
         SQLiteCommand command = new SQLiteCommand(sql, connection);         //crea il comando
         SQLiteDataReader reader = command.ExecuteReader();                 //esegue il comando 

         //Questo inizia un ciclo while che legge riga per riga i dati restituiti dal comando SQL. Il metodo Read() restituisce true finché ci sono righe da leggere; quando non ci sono più righe, restituisce false, terminando il ciclo.
         while(reader.Read())         
         {
            System.Console.WriteLine($"id: {reader["id"]}, nome: {reader["nome"]}, prezzo: {reader["prezzo"]}, quantita: {reader["quantita"]}");
         }
         connection.Close();
    }

    static void EliminaProdotto()
    {
        System.Console.WriteLine("Inserisci il nome del prodotto");
        string nome = Console.ReadLine();
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3");
        connection.Open();
        string sql = $"DELETE FROM prodotti WHERE nome = '{nome}'";
        SQLiteCommand command = new SQLiteCommand(sql, connection);
        command.ExecuteNonQuery();
        connection.Close();
    }

    static void ModificaProdotto()
    {
        System.Console.WriteLine("Quale prodotto vuoi modificare?");
        string prodottoScelto = Console.ReadLine()!;
        System.Console.WriteLine("Vuoi modificare nome, prezzo o quantità?");
        string scelta = Console.ReadLine()!;
        switch(scelta)
        {
            case "1": 
                System.Console.WriteLine("Inserisci il nuovo nome");
                string nome = Console.ReadLine();
                string sqlNome = $"UPDATE prodotti SET nome = '{nome}' WHERE nome = '{prodottoScelto}'";
                break;
            case "2":
                System.Console.WriteLine("Inserisci il nuovo prezzo");
                string prezzo = Console.ReadLine();
                string sqlPrezzo = $"UPDATE prodotti SET prezzo = '{prezzo}' WHERE nome = '{prodottoScelto}'";
                break;
            case "3":
                System.Console.WriteLine("Inserisci la nuova quantità");
                string quantita = Console.ReadLine();
                string sqlQuantita = $"UPDATE prodotti SET prezzo = '{quantita}' WHERE nome = '{prodottoScelto}'";
                break;
        }
        
        SQLiteConnection connection = new SQLiteConnection($"Data Source=database.db; Version=3");
        connection.Open();
        //string sql = $"UPDATE prodotti SET prezzo = 40 WHERE nome = '{nome}'";
    }

}



/*
SQLiteCommand command = new SQLiteCommand(sql, connection);

La ragione principale per cui non puoi passare direttamente il percorso del file del database path come secondo argomento
 al costruttore SQLiteCommand è che il costruttore richiede un oggetto SQLiteConnection, non una stringa che rappresenta
  il percorso del file del database.

Il costruttore SQLiteCommand accetta un oggetto SQLiteConnection come secondo argomento poiché il comando deve essere associato
 a una connessione aperta al database. Questa connessione è necessaria per eseguire il comando sul database specificato nel percorso del file.

Quindi, per creare un oggetto SQLiteCommand, devi fornire una connessione aperta al database, non solo il percorso del file del database.
È per questo che passi connection, che è un'istanza di SQLiteConnection, anziché solo path, che è una stringa.*/





