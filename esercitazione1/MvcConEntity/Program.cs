using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {   
        var us = new User();
        var db = new Database();//Model
        var view = new View(db, us);//View
        var controller = new Controller(db, view);//Controller
        // controller.MainMenu();//Menu principale dell'app


        
        // using (db = new Database()) // Per garantire che il database venga chiuso
        // {

        //     System.Console.WriteLine("Dì il nome dell'utente che vuoi inserire");
        //     var nomeDato = Console.ReadLine();

        //     var user = new User{Nome=nomeDato};
            
        //     System.Console.WriteLine("utenti: ");
        //     // db.InserisciClienti(users);           
        // }

        controller.MainMenu();//Menu principale dell'app
    }
}


