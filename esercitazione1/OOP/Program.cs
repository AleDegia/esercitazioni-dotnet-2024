class Program
{
    static void Main(string[] args)
    {
        Dado d1 = new Dado();
        Dado d2 = new Dado();

        int n1 = d1.Lancia();
        int n2 = d2.Lancia();

        System.Console.WriteLine("Dado 1: " + n1);
        System.Console.WriteLine("Dado 2: " + n2);
    }
}