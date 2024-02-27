public class Dado{
    public Random random = new Random();
    // private Random random2 = new Random();
    public int Lancia()
    {
        return random.Next(1,7);
    }
    
}