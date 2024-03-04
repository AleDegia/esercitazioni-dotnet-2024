public class Prodotto
{
    public int Id {get; set;}   //id viene assegnato in automatico nel database
    public string Nome {get; set;}
    public double Prezzo {get; set;}
    public int ClienteId {get; set;}
    public Cliente Cliente {get; set;}  //relazione con la tabella clienti

    public List<Ordine> Ordini {get; set;}
}