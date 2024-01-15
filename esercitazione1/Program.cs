class Program //aggiungere case name con variabile con nostro nome, quando facciamo case name stampi il nostro nome
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Inserisci un comando speciale (esempio: 'cmd:info', 'cmd:exit'):");

        while(true)
        {
            string? input = Console.ReadLine();

            //analizza l'input per vedere se segue un formato specifico
            if(input.StartsWith("cmd:"))
            {
                string comando = input.Substring(4); //estrae la parte del comando dopo cmd
                string nome = "Alessandro";

                switch(comando.ToLower())
                {
                    case "info":
                        System.Console.WriteLine("Comando 'info' riconosciuto. Mostrando le informazioni...");
                        //aggiungi qui la logica
                        break;
                    case "exit":
                        System.Console.WriteLine("Comando 'exit' riconosciuto. Uscita in corso...");
                        return;
                    case "name":
                        System.Console.WriteLine($"Ecco il tuo nome: {nome}");
                        break;
                    default:
                        System.Console.WriteLine($"Comando  '{comando}' non riconosciuto");
                        break;
                }
            }
            else 
            {
                System.Console.WriteLine("Input non valido. Inserisci un comando");
            }

            System.Console.WriteLine("\nInserisci un altro comando:");
        }
    }
}


