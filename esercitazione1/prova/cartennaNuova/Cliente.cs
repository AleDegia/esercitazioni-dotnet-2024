public class Cliente
{
    public int Id {get; set;}   //id viene assegnato in automatico nel database
    public string Nome {get; set;}
    public string Cognome {get; set;}
    public string Telefono {get; set;}
    public List<Prodotto> Prodotti {get; set;}      //Relazione uno a molti con la tabella prodotti
}