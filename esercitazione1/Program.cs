class Program
{
    static void Main()
    {
        List<String> nomi = ["Alex", "Simone", "Fabio", "Giada", "Carlo", "Dylan", "Natalia", "Alessandro"]; 
        Random random = new Random();
        int indice = random.Next(0,nomi.Count);
        System.Console.WriteLine($"Il nome sorteggiato è {nomi[indice]}");  
    }
}