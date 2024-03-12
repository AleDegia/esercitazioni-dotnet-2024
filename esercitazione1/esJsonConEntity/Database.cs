using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Globalization;
// using System.Data.SQLite;
class Database : DbContext
{
    public DbSet<User> Users { get; set; }          //creo tabella Players
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
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
    
        
        if(!exists)        //aggiungo i 3 prodotti in products
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

        public void AddUser(string username, string password, double balance)       //gli oggetti sono records di una tabella, gli attributi degli oggetti sono le colonne nel database
        {
            var user = new User {Name = username, Password = password, Balance = balance};    //stai istanziando un nuovo oggetto User e impostando il suo nome con il valore passato come parametro alla funzione AddUser 
            Users.Add(user);      //serve a aggiungere l'oggetto alla tabella users (perciò come record)
            SaveChanges();      
        }

        public void AddPurchase(string scelta, User user, Controller controller)
        {
            
            if(scelta == "1")
            {
                //
                using (var context = new Database())
                {
                    

                    //cerco un utente il cui nome (Name) corrisponde al nome dell utente fornito (user.Name)
                    var userr = context.Users.FirstOrDefault(p => p.Name == user.Name); 
                    var prod = context.Products.FirstOrDefault(p => p.Id == Int32.Parse(scelta));
                    int idUtente = userr.Id;
                   
                    if(userr.Balance-prod.Price>=0)
                    {
                        var purchase = new Purchase {IdUtente = idUtente, IdProdotto = 1, Prezzo = 19.99};
                        Purchases.Add(purchase);
                        //sottraggo il costo del prodotto dal balance dell'utente
                        userr.Balance = userr.Balance-prod.Price;
                        //sottraggo la quantità
                        prod.Quantity -= 1;
                        context.SaveChanges();          //se uso context usarlo anche col SaveChanges
                        System.Console.WriteLine("Il tuo balance ora è di " + userr.Balance);
                    }
                    else
                    {
                        System.Console.WriteLine("non hai abbastanza soldi!");
                        controller.RichiestaAcquisto(user);
                    }                    
                }
            }
            else if(scelta == "2")
            {
                using (var context = new Database())
                {
                    //cerco un utente il cui nome (Name) corrisponde al nome dell utente fornito (user.Name)
                    var userr = context.Users.FirstOrDefault(p => p.Name == user.Name); 
                    int idUtente = userr.Id;
                    
                    
                    // Ottengo il prodotto per ottenerne il prezzo
                    var prod = context.Products.FirstOrDefault(p => p.Id == Int32.Parse(scelta));
                 
                    // Creo un nuovo acquisto e lo aggiungo al database
                    if(userr.Balance-prod.Price>=0)
                    {
                        var purchase = new Purchase {IdUtente = idUtente, IdProdotto = 2, Prezzo = 39.99};
                        context.Purchases.Add(purchase);
                        // Sottraggo il costo del prodotto dal balance dell'utente
                        double balance = userr.Balance;
                        userr.Balance = balance - prod.Price;
                        //sottraggo la quantità
                        prod.Quantity -= 1;
                        context.SaveChanges();
                        System.Console.WriteLine("Il tuo balance ora è di " + userr.Balance);  
                    }
                    else
                    {
                        System.Console.WriteLine("non hai abbastanza soldi!");
                        controller.RichiestaAcquisto(user);
                    }

                    // Salvare le modifiche sia per l'acquisto che per l'utente                                   
                }
            }
            else if(scelta == "3")
            {
                using (var context = new Database())
                {
                    //cerco un utente il cui nome (Name) corrisponde al nome dell utente fornito (user.Name)
                    var userr = context.Users.FirstOrDefault(p => p.Name == user.Name); 
                    var prod = context.Products.FirstOrDefault(p => p.Id == Int32.Parse(scelta));
                    int idUtente = userr.Id;
                    
                    if(userr.Balance-prod.Price>=0)
                    {
                    var purchase = new Purchase {IdUtente = idUtente, IdProdotto = 3, Prezzo = 99.99};
                    Purchases.Add(purchase);
                    //sottraggo il costo del prodotto dal balance dell'utente                   
                    userr.Balance = userr.Balance-prod.Price;
                    //sottraggo la quantità
                    prod.Quantity -= 1;
                    context.SaveChanges();          //se uso context usarlo anche col SaveChanges
                    System.Console.WriteLine("Il tuo balance ora è di " + userr.Balance);
                    }
                    else
                    {
                        System.Console.WriteLine("non hai abbastanza soldi!");
                        controller.RichiestaAcquisto(user);
                    }                                    
                }
            }
        }

        public void ViewPurchases(User user)
        {
            using (var context = new Database())
            { 
                // Eseguire una query per recuperare l 'utente con nome "x"
                var userr = context.Users.FirstOrDefault(p => p.Name == user.Name);
                //query per recuperare la lista di tutti gli acquisti
                var purchases = context.Purchases.ToList();

                foreach (var purchase in purchases)
                {
                    if(userr.Id == purchase.IdUtente)
                    {
                        Console.WriteLine($"Purchase Id: {purchase.Id}, Id utente: {purchase.IdUtente}, Id prodotto: {purchase.IdProdotto}, Prezzo: {purchase.Prezzo}");
                    }
                }
                context.SaveChanges();
            }
        }
        
        
        public void AdminCreate(string newProductName, string newProductPrice, string newProductQuantity)
        {

                double newProductPriceConverted = Double.Parse(newProductPrice, CultureInfo.InvariantCulture);
                int newProductQuantityConverted = Int32.Parse(newProductQuantity);
                //aggiungi un nuovo prodotto
                var newProduct = new Product {Name = newProductName, Price = newProductPriceConverted, Quantity = newProductQuantityConverted };
                Products.Add(newProduct);
                SaveChanges();
                     
        }   

        public void AdminRead()
        {
            System.Console.WriteLine("Ecco i prodotti in vendita:");
            var allProducts = Products.ToList();
            Console.WriteLine("\nAll Products:");
            foreach (var product in allProducts)
            {
                Console.WriteLine($"ProductId: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }

        public void AdminUpdate(string sceltaProdotto, string sceltaCampo, string modifica)
        {
            var product = Products.FirstOrDefault(p => p.Id == Int32.Parse(sceltaProdotto));
            if(sceltaCampo=="1")
            {
                //int sceltaCampoInt = Int32.Parse(sceltaCampo);
                product.Name = modifica;
                SaveChanges();
            }           
            else if (sceltaCampo =="2")
            {
                product.Price = Double.Parse(modifica);
                SaveChanges();
            }
            else if (sceltaCampo =="3")
            {
                product.Quantity = Int32.Parse(modifica);
                SaveChanges();
            }
        }

        public void AdminRemove(string productToRemove)
        {
            var product = Products.FirstOrDefault(p => p.Id == Int32.Parse(productToRemove));

            if (product != null)
            {
                Products.Remove(product);
                SaveChanges();
                System.Console.WriteLine("Eliminazione avvenuta con successo");
            }
            else
            {
                Console.WriteLine("Elemento non trovato.");
                // Oppure lanciare un'eccezione, a seconda delle tue esigenze
            }
        }
}