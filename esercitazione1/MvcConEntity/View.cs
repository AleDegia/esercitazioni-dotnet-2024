class View
{
    private Database _db;
    private User _user;

    public View(Database db, User us)
    {
        _db = db;
        _user = us;
    }



    public void ShowMainMenu()
    {
        System.Console.WriteLine("1. Aggiungi user");
        System.Console.WriteLine("2. Leggi users");
        System.Console.WriteLine("3. Modifica user");
        System.Console.WriteLine("4. Elimina user");
        System.Console.WriteLine("5. Esci");
    }

    public void ShowUsers(List<User> users)
    {
        foreach(var user in users)
        {
            System.Console.WriteLine(user.Name);    //visualizzazione dei nomi degli utenti
        }
    }

    public string GetInput()
    {
        return Console.ReadLine();  //lettura dell'input dell'utente
    }
}