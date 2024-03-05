using Microsoft.EntityFrameworkCore;
using System.Data.SQLite;
class Database
{
    private SQLiteConnection _connection;  //classe che rappresenta una connessione a un database SQLite

    public Database()
    {
        _connection = new SQLiteConnection("Data Source=database.db");  //creo connessione al database
        _connection.Open();                                             //apertura della connessione
        //creazione tabella users
        var command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)", _connection);
        command.ExecuteNonQuery();  //esecuzione del comando
    }

    public void AddUser(string name)
    {
        var command = new SQLiteCommand($"INSERT INTO users (name) VALUES ('{name}')", _connection); //creazione comando per inserire nuovo utente
        command.ExecuteNonQuery();  //esecuzione comando
    }

    public List<string> GetUsers()   //metodo per recuperare i nomi degli utenti da una tabella chiamata "users" 
    {
        var command = new SQLiteCommand("SELECT name FROM users", _connection); //creazione comando x leggere gli utenti
        var reader = command.ExecuteReader();   //esecuzione query per leggere i risultati, che restituisce oggetto SQLiteDataReader
        var users = new List<string>(); //creazione lista per memorizzare i nomi degli utenti

        while (reader.Read())
        {
            users.Add(reader.GetString(0)); //aggiunta nome utente alla lista
        }
        return users;   //restituzione della lista
    }

    public void ModifyUser(string vecchioNome, string nuovoNome)
    {
        var command = new SQLiteCommand($"UPDATE users SET name = '{nuovoNome}' WHERE name = '{vecchioNome}'", _connection);
        command.ExecuteNonQuery();
    }

    public void DeleteUser(string nomeUser)
    {
        var command = new SQLiteCommand($"DELETE FROM users WHERE name = '{nomeUser}'", _connection);
        command.ExecuteNonQuery();
    }
}
