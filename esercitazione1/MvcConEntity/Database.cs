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


    public List<User> GetUsers()   //metodo per recuperare i nomi degli utenti da una tabella chiamata "users" 
    {     
        var users = Users.ToList();  // recupera gli utenti dal database
        return users;
        // foreach(var u in users)       //c è un singolo oggetto di tipo cliente nella lista clienti
        // {
        //     System.Console.WriteLine($"{u.Id} - {u.Name}");
        //     // foreach(var p in c.Prodotti)
        //     // {
        //     //     System.Console.WriteLine($"{p.Id} - {p.Nome} {p.Prezzo}");
        //     // }
        // }
    }

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
