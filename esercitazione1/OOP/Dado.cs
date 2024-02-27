public class Dado
{
    private Random random = new Random();
    
    public int Lancia()
    {
        return random.Next(1,7);
    }

}