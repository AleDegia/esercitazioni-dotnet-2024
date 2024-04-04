public class VerificaDoppia
{
  public int Id { get; set; }
  public required string RispostaUtente { get; set; }
  public required string[] RisposteGiuste { get; set; } 
  public bool Uguali { get; set; } 
}