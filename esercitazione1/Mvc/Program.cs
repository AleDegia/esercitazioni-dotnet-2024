using System.Data.SQLite;

class Program
{
    static void Main(string[] args)
    {
        var db = new Database();//Model
        var view = new View(db);//View
        var controller = new Controller(db, view);//Controller
        controller.MainMenu();//Menu principale dell'app
    }
}


/*
in Controller chiamo i metodi fatti nel database per le query e ci aggiungo la richiesta di input per
 prendere l'input dall'utente

Qui, in Program, creo reference e oggetto delle classi Database e View e li passo al costruttore di Controller
*/