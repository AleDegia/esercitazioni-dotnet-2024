public class UserModel
{
    // Lista dei nomi utenti
    public List<string> NomiUtenti { get; set; }

    // Lista delle password
    public List<string> Passwords { get; set; }

    public UserModel()
    {
        NomiUtenti = new List<string>();
        Passwords = new List<string>();
    }
}