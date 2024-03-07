using Microsoft.EntityFrameworkCore;
// using System.Data.SQLite;
class Database : DbContext
{
    public DbSet<User> Users { get; set; }          //creo tabella Players
    public DbSet<Product> Products { get; set; }
    string pathDbUtentiEPassword = @"utentiEpassword.db";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source =MyDatabase.sqlite");   //dico di usar il database 'MyDatabase'
        //optionsBuilder.UseInMemoryDatabase("MyDatabase");
    }


    public void CheckDbExistance()
    {
        if (!File.Exists(pathDbUtentiEPassword))  //creazione database: just run your application and read or write to the DbContext. It will then automatically create the database "on access".
        {
            using (var context = new Database())
            {}
        }
    }

    public void AddInitialProducts()
    {
        var gamingMouse = new Product
        {
            Name = "gaming mouse";
            Price = 19.99;
            Quantity = 37;
        }

        var joypad = new Product
        {
            Name = "joypad";
            Price = 39.99;
            Quantity = 28;
        }
        Products.Add(gamingMouse);
        Products.Add(joypad);

    }
    
    
        public List<User> GetUsers()   //metodo per recuperare i nomi degli utenti da una tabella chiamata "users" 
        {     
            var users = Users.ToList();  // recupera gli utenti dal database
            return users;                   
        }

        public void AddUser(string username, string password)       //gli oggetti sono records di una tabella, gli attributi degli oggetti sono le colonne nel database
        {
            var user = new User {Name = username, Password = password};    //stai istanziando un nuovo oggetto User e impostando il suo nome con il valore passato come parametro alla funzione AddUser 
            Users.Add(user);      //serve a aggiungere l'oggetto alla tabella users (perciò come record)
            SaveChanges();      
        }
    
}