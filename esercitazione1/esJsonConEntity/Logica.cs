
public class Logica
{
    
        // Inizializzazione delle variabili e liste.
        List<string> nomiUtenti = new List<string>();
        List<string> passwords = new List<string>();
        Boolean flag = false;
        string utenteRegistrato = null;
        string passwordUtenteRegistrato = null;

        // Percorso del file JSON contenente i nomi utenti e le password.
        string pathJsonUtentiEPassword = @"utentiEpassword.json";
        string pathJsonProdottiEPrezzi = @"prodottiEprezzi.json";
        string json = null;
        string file2;
        string file4;
        dynamic obj = null;
        dynamic obj2 = null;
        string nomeUtente = null;
        string password = null;
        string utenteLoggato = null;
        string passwordUtenteLoggato;
        bool utenteEsistente = false;

        
    }
