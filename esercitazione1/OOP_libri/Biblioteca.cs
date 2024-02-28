class Biblioteca
{
    private List<Libro> libri = new List<Libro>();

    public void Aggiungi(Libro libro)
    {
        libri.Add(libro);
    }

    public void Stampa()
    {
        foreach (Libro libro in libri)
        {
            System.Console.WriteLine("Titolo: " + libro.titolo);
            System.Console.WriteLine("Autore: " + libro.autore);
        }
    }
}