class Program{
    static void Main(string[] args)
    {
        string[] nomi = new string[3]; //l'array deve essere predeterminato, va assegnato perciò subito il numero degli elementi
        nomi[0] = "Mario";
        nomi[1] = "Luigi"; 
        nomi[2] = "Giovanni"; 
        
        foreach (string nome in nomi){
            Console.WriteLine($"Ciao {nome}"); 
        }
    }
}



//per ogni nome su una lista, se inizia con la m aggiungimelo ad un altra lista