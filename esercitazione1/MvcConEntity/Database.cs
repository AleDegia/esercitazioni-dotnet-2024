using Microsoft.EntityFrameworkCore;
using System.Data.SQLite;
class Database : DbContext
{
    public DbSet<User> Users { get; set; }          //creo tabella users

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source =MyDatabase.sqlite");   //dico di usar il database 'MyDatabase'
        //optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }

    public void AddUser( string username)       //gli oggetti sono records di una tabella, gli attributi degli oggetti sono le colonne nel database
    {
        var user = new User { Name = username };    //stai istanziando un nuovo oggetto User e impostando il suo nome con il valore passato come parametro alla funzione AddUser 
        Users.Add(user);      //serve a aggiungere l'oggetto alla tabella users (perciò come record)
        SaveChanges();      
    }


//     public List<string> GetUsers()   //metodo per recuperare i nomi degli utenti da una tabella chiamata "users" 
//     {
//         var command = new SQLiteCommand("SELECT name FROM users", _connection); //creazione comando x leggere gli utenti
//         var reader = command.ExecuteReader();   //esecuzione query per leggere i risultati, che restituisce oggetto SQLiteDataReader
//         var users = new List<string>(); //creazione lista per memorizzare i nomi degli utenti

//         while (reader.Read())
//         {
//             users.Add(reader.GetString(0)); //aggiunta nome utente alla lista
//         }
//         return users;   //restituzione della lista
//     }

//     public void ModifyUser(string vecchioNome, string nuovoNome)
//     {
//         var command = new SQLiteCommand($"UPDATE users SET name = '{nuovoNome}' WHERE name = '{vecchioNome}'", _connection);
//         command.ExecuteNonQuery();
//     }

//     public void DeleteUser(string nomeUser)
//     {
//         var command = new SQLiteCommand($"DELETE FROM users WHERE name = '{nomeUser}'", _connection);
//         command.ExecuteNonQuery();
//     }
}
