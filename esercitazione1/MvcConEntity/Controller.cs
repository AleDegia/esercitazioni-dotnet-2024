class Controller            //il controller a seconda se è 1 o 2 o 3 esegue la logica
{
    private Database _db;   //riferimento al modello
    private View _view;     //riferimento alla vista



    public Controller(Database db, View view)
    {
        _db = db;       //inizializzazione del riferimento al modello
        _view = view;   //inizializzazione del riferimento alla lista
    }

    public void MainMenu()
    {
        while(true)
        {
            _view.ShowMainMenu();   //visualizzazione del menu principale grazie al metodo della classe View
            var input = _view.GetInput();   //lettura dell'input dell'utente
            if(input == "1")
            {
                AddUser();  //aggiunta di un utente
            }
            else if (input == "2")
            {
                // ShowUsers();    //visualizzazione degli utenti
            }
            else if (input == "3")
            {
                // ModifyUser();
            }
            else if (input == "4")
            {
                //  DeleteUser();
            }
            else if (input == "5")
            {
                break;
            }
        }
    }

    private void AddUser()
    {
        System.Console.WriteLine("Enter user name:");       //richiesta del nome dell'utente
        var name = _view.GetInput();    //lettura del nome dell'utente
        _db.AddUser(name);  //aggiunta dell'utente al database
    }

    // private void ShowUsers()
    // {
    //     var users = _db.GetUsers(); //lettura degli utenti dal database
    //     _view.ShowUsers(users);     //Visualizzazione degli utenti
    // }

    // private void ModifyUser()
    // {
    //     System.Console.WriteLine("Enter new user name:"); 
    //     var newName = _view.GetInput();
    //     System.Console.WriteLine("Enter old user name:"); 
    //     var oldName = _view.GetInput();
    //     _db.ModifyUser(oldName, newName);
    // }

    // private void DeleteUser()
    // {
    //     System.Console.WriteLine("Quale user vuoi eliminare?");
    //     var name = _view.GetInput();
    //     _db.DeleteUser(name);
    // }
    
}