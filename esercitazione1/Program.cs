class Program
{
    static void Main(string[] args)
    {
        try
        {
            int [] numeri = new int[int.MaxValue]; //è il max value che può contenere un int, e un array non ci arriva
        }
        catch(Exception e)
        {
            System.Console.WriteLine("Memoria insufficiente");
            return;
        }
    }
}

