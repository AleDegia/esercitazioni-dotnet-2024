class Program
{
    static void Main(string[] args)
    {
        string[] nomi = new string[3];
        nomi[0] = "Mario";
        nomi[1] = "Luigi";
        nomi[2] = "Giovanni";
        List<string> nomiConM = new List<string>();

        foreach (string nome in nomi)
        {
            // Non è necessario dividere la parola in lettere, puoi confrontare direttamente la prima lettera
            if (nome[0] == 'M' || nome[0] == 'm') //mettendo i 2 apici da errore perchè per i singoli caratteri serve il singolo apice
            {
                // Aggiungi alla lista i nomi con la "M" o "m"
                nomiConM.Add(nome);
            }
        }

        foreach (string nomeSingolo in nomiConM)
        {
            System.Console.WriteLine(nomeSingolo);
        }
    }
}

