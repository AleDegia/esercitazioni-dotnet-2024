using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

<<<<<<< HEAD

namespace MvcIdentityQuiz.Models;

public class PunteggiModel
{
public Utente? Utente { get; set; }

public List <int> Punteggi { get; set; }

public int Record {get; set;}
=======
namespace MvcIdentityQuiz.Models;

public class PunteggiModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<Verifica> Verifiche { get; set; }
>>>>>>> 3a604f090cf949c1c534cad82e633700f2fac7d0
}