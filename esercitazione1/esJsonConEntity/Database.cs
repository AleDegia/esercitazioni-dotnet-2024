using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        
        var gamingMouse = new Product {Name = "gaming mouse", Price = 19.99, Quantity = 27};
        // var gamingMouse = new Product("gaming mouse", 19.99, 37);
        var joypad = new Product {Name = "joypad", Price = 39.99, Quantity = 17};
        // var joypad = new Product("joypad",39.99,28);
        var monitor = new Product {Name = "monitor", Price = 99.99, Quantity = 10};
        // var monitor = new Product("monitor",99.99,128);

        using (var context = new Database())
        {
        
        //prima di fare l'add verifico se il record monitor è gia stato aggiunto ed in tal caso non faccio l'add
        bool exists = context.Products.Any(r => r.Name == "monitor");

        if (exists)
        {
            
        }
        else        //aggiungo i 3 prodotti in products
        {
            Products.Add(gamingMouse);
            SaveChanges();
            Products.Add(joypad);
            SaveChanges();
            Products.Add(monitor);
            SaveChanges();
        }
        }
                
        
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