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
        
    }

    public void ModifyUser(string vecchioNome, string nuovoNome)
    {
        
        var users = Users.ToList();
        foreach(dynamic user in users)
        {
            if(user.Name == vecchioNome)               //se viene trovato il nome inserito tra i record del database
            {
                user.Name = nuovoNome;         //faccio la modifica del nome del record
                SaveChanges();
                System.Console.WriteLine("update avvenuto con successo");
            }
            else
            {
                System.Console.WriteLine("utente non presente nel database");
            }
        }
    }

    public void DeleteUser(string nomeUser)
    {
        using (var context = new Database())
        {
        var userToDelete = context.Users.FirstOrDefault(u => u.Name == nomeUser);

            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);
                context.SaveChanges();
            }
        }
    }
}
