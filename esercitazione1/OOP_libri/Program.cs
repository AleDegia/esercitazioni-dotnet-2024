class Program{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca();
        Libro libro1 = new Libro("Narnia" , "Pino");
        Libro libro2 = new Libro("Il nome della Rosa" , "Umberto Eco");
        biblioteca.Aggiungi(libro1);
        biblioteca.Aggiungi(libro2);
        biblioteca.Stampa();

    }
}
