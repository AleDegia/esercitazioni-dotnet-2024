class View
{

    public string GetInput()
    {
        return Console.ReadLine();  //lettura dell'input dell'utente
    }
    
    public void MessaggioIniziale()
    {       
        // Richiesta all'utente di registrarsi o effettuare il login.
        System.Console.WriteLine("premi 1 per registrarti, premi 2 per fare il login, premi 3 per uscire");        
    }
}