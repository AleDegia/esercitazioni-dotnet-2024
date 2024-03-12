

class Controller            //il controller a seconda se è 1 o 2 o 3 esegue la logica
{
    private Database _db;   //riferimento al modello
    private View _view;     //riferimento alla vista

    private UserModel _userModel;     //riferimento al model
    private User _user;
    private Product _product;

    string pathDbUtentiEPassword = @"utentiEpassword.db";

    // public Controller(){}

    public Controller(Database db, View view, UserModel userModel, User user, Product product)
    {
        _db = db;       //inizializzazione del riferimento al modello
        _view = view;   //inizializzazione del riferimento alla view
        _userModel = userModel;  //inizializzazione del riferimento allo usermodel
        _user = user;
        _product = product;
    }

    // _userModel.NomiUtenti = new List<string>();
    // _userModel.Passwords = new List<string>();
    
    public void MainMenu()
    {
        while(true)
        {
            _view.MessaggioIniziale();      //visualizzazione del menu principale grazie al metodo della classe View
            var input = _view.GetInput();   //lettura dell'input dell'utente

            if(input == "1")
            {
                UtenteRegistrazione();  
            }
            else if (input == "2")
            {
                UtenteLogin();
            }

            else if (input == "3")
            {
                AdminLogin(); 
            }
            
            else if (input == "4")
            {
                 Environment.Exit(0);
                // break;
            } else{
                System.Console.WriteLine("Input non valido, digita un input valido");
                continue;
            }

            RichiestaAcquisto(_user);
            VisualizzaOrdini(_user);
        }
    }

    public void UtenteRegistrazione()
    {
        // Registrazione dell'utente.
        
        // Inserimento del nome utente e della password.
        System.Console.WriteLine("Inserisci il nome utente");
        string name = _view.GetInput();
        // _user.Name = name;
        _userModel.NomiUtenti.Add(_user.Name);
        System.Console.WriteLine("Inserisci una password");
        string password = _view.GetInput();
        // _user.Password = password;
        _userModel.Passwords.Add(_user.Password);

        checkEsistenzaUtente(name, password);     // da mettere prima dell'inserimento password   

        // AddUser(name, password);     ->   l'ho messo dentro checkEsistenteUtente cosi prende i parametri

        MainMenu();
    }

    public void UtenteLogin()
    {
        Ripartiamo:
        System.Console.WriteLine("Inserisci il nome utente");
        string name = _view.GetInput(); 
        _user.Name = name;
        System.Console.WriteLine("Inserisci la password");
        string password = _view.GetInput();
        _user.Password = password;

        int i = 1;
        int numberOfRows = _db.Users.Count();
        var users = _db.GetUsers(); //lettura degli utenti dal database
        if(numberOfRows==0)
        {
            System.Console.WriteLine("non sei ancora registrato");
            Rinizio();
            MainMenu();
        }
        foreach(User user in users)
        {
            
            // System.Console.WriteLine(user.Name);
            if(user.Name == name && user.Password == password)
            {
                System.Console.WriteLine("Login avvenuto correttamente");
                break;
            }
            else if(i == numberOfRows)
            {               
                System.Console.WriteLine("nome utente errato o non esistente");
                goto Ripartiamo;
            }
            i++;
        }
    }
    
    public void RichiestaAcquisto(User user)
    {
        using (var context = new Database())
        {
            var userr = context.Users.FirstOrDefault(p => p.Name == user.Name);
            System.Console.WriteLine("Il tuo balance è di: " + userr.Balance);
        }
        _view.MessaggioAcquisto();
        string scelta = _view.GetInput();

            if(scelta=="1"||scelta=="2"||scelta=="3")
            {
                AddPurchaseToDb(scelta, user, this);
                
            }
            
            else
            {
                System.Console.WriteLine("scelta non valida");
                RichiestaAcquisto(user);
            }
    }

    public void VisualizzaOrdini(User user)
    {
        _view.MessaggioVisualizzaOrdini();
        string scelta = _view.GetInput();
        
        if(scelta == "y")
            _db.ViewPurchases(user);
    }


    public void AdminLogin()
    {
        
        System.Console.WriteLine("Inserisci il nome utente");
        string name = _view.GetInput(); 
        System.Console.WriteLine("Inserisci la password");
        string password = _view.GetInput();

        if(name == "admin" && password == "1")
        {   
            System.Console.WriteLine("login effettuato con successo");
            Rinizia:
            System.Console.WriteLine();
            System.Console.WriteLine("Cosa vuoi fare? ");
            System.Console.WriteLine("1) aggiungi prodotto, 2) stampa prodotti disponibili, 3) modifica prodotto, 4)elimina prodotto 5)esci");
            string scelta = _view.GetInput();

            if(scelta=="1")
            {
                //aggiungi un nuovo prodotto
                System.Console.WriteLine("scrivi il nome del prodotto da aggiungere");
                string newProductName = _view.GetInput();
                System.Console.WriteLine("scrivi il prezzo del prodotto da aggiungere");
                string newProductPrice = _view.GetInput();
                System.Console.WriteLine("scrivi la quantità in stock");
                string newProductQuantity = _view.GetInput();
                _db.AdminCreate(newProductName, newProductPrice, newProductQuantity);
                System.Console.WriteLine("Prodotto inserito con successo");
                goto Rinizia;
            }
            else if(scelta == "2")
            {
                _db.AdminRead();
                goto Rinizia;
            }
            else if(scelta == "3")
            {
                System.Console.WriteLine("Inserisci l'id del prodotto da modificare");
                string sceltaProdotto = _view.GetInput();  
                System.Console.WriteLine("Cosa vuoi modificare? 1) nome, 2) prezzo, 3) quantità");
                string sceltaCampoDaModificare = _view.GetInput();
                System.Console.WriteLine("Inserisci la modifica da effettuare");
                string modifica = _view.GetInput();

                _db.AdminUpdate(sceltaProdotto, sceltaCampoDaModificare, modifica);
                goto Rinizia;
            }
            else if(scelta == "4")
            {
                System.Console.WriteLine("Inserisci l'id del prodotto da eliminare");
                string sceltaProdotto = _view.GetInput();
                _db.AdminRemove(sceltaProdotto);
                goto Rinizia;
            }
            else if (scelta == "5")
            {
                Environment.Exit(0);
            }
            else{
                System.Console.WriteLine("Input non valido, digita un input valido");
                goto Rinizia;
            }
        }
    } 

    public void checkEsistenzaUtente(string name, string password)
    {
        var users = _db.GetUsers(); //lettura degli utenti dal database
        
        int numberOfRows = _db.Users.Count();
        // System.Console.WriteLine(numberOfRows);
        int i = 1;
        if(numberOfRows==0)
        {
            double balance = 100;
            System.Console.WriteLine("utente registrato correttamente");
            AddUser(name, password, balance);
        }
        if(numberOfRows>0)
        {
            foreach(User user in users)
            {
                // System.Console.WriteLine(user.Name);
                if(user.Name == name)
                {
                    System.Console.WriteLine("Utente esistente, inserisci un nome utente diverso");
                    Rinizio();
                    // return; // Esci dal metodo dopo aver chiamato Rinizio()
                }
                else if(i == numberOfRows)
                {
                    double balance = 100;
                    System.Console.WriteLine("utente registrato correttamente");
                    AddUser(name, password, balance);
                    break;
                }    
                i++;
            }
        }
    }

    public void Rinizio()
    {
        UtenteRegistrazione();
    }

    private void AddUser(string name, string password, double balance )
    {
        _db.AddUser(name, password, balance);  //aggiunta dell'utente al database
    }

    private void AddPurchaseToDb(string scelta, User user, Controller controller)
    {
        _db.AddPurchase(scelta, user, controller);
    }
    
}