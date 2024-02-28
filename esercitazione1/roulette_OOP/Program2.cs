class Program2
{
    static void Main(string[] args)
    {
        Giocatore giocatore1 = new Giocatore();
        LogicaPartita logicaPartita = new LogicaPartita();
        while (true)
        {
            
            giocatore1.PercentualeVittorie = logicaPartita.CalcolaPercentuale(giocatore1.Vittorie, giocatore1.Vittorie + giocatore1.Sconfitte);
            giocatore1.PercentualeSconfitte = logicaPartita.CalcolaPercentuale(giocatore1.Sconfitte, giocatore1.Vittorie + giocatore1.Sconfitte);

            Console.WriteLine($"Percentuale di vittorie: {Math.Round(giocatore1.PercentualeVittorie, 2)}%");
            Console.WriteLine($"Percentuale di sconfitte: {Math.Round(giocatore1.PercentualeSconfitte, 2)}%");

            logicaPartita.generaNumeroCasuale();
            logicaPartita.VerificaImporto(giocatore1);
            logicaPartita.ScegliTipoScommessa(giocatore1);
            logicaPartita.sceltaNumeriDaScommettere(giocatore1);
        }
        


        

    }
}