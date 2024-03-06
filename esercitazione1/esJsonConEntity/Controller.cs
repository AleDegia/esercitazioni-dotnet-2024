class Controller            //il controller a seconda se è 1 o 2 o 3 esegue la logica
{
    private Database _db;   //riferimento al modello
    private View _view;     //riferimento alla vista

    private UserModel _userModel;     //riferimento al model
    private User _user;

    string pathDbUtentiEPassword = @"utentiEpassword.db";

    public Controller(Database db, View view, UserModel userModel, User user)
    {
        _db = db;       //inizializzazione del riferimento al modello
        _view = view;   //inizializzazione del riferimento alla view
        _userModel = userModel;  //inizializzazione del riferimento allo usermodel
        _user = user;
    }

    // _userModel.NomiUtenti = new List<string>();
    // _userModel.Passwords = new List<string>();
    
    public void MainMenu()
{
    while(true)
    {
        _view.MessaggioIniziale();   //visualizzazione del menu principale grazie al metodo della classe View
        var input = _view.GetInput();   //lettura dell'input dell'utente
        if(input == "1")
        {
            Registrazione();  
        }
        else if (input == "2")
        {
            break; 
        }
        
        Rinizio();
    }
}

public void Registrazione()
{
    //string scelta = _view.GetInput();

    // Registrazione dell'utente.
    
        // Inserimento del nome utente e della password.
        System.Console.WriteLine("Inserisci il nome utente");
        _user.Name = _view.GetInput();
        _userModel.NomiUtenti.Add(_user.Name);
        System.Console.WriteLine("Inserisci una password");
        _user.Password = _view.GetInput();
        _userModel.Passwords.Add(_user.Password);

        checkEsistenzaUtente();
    
}

public void checkEsistenzaUtente()
{
    var users = _db.GetUsers(); //lettura degli utenti dal database
    foreach(User user in users)
    {
        if(user.Name == _user.Name)
        {
            System.Console.WriteLine("Utente esistente, inserisci un nome utente diverso");
            Rinizio();
        }
        else
        {
            System.Console.WriteLine("utente registrato correttamente");
            break;
        }
    }
}

public void Rinizio()
{
    // Qui gestisci il codice per riprendere dall'inizio del loop nel menu principale.
}

}