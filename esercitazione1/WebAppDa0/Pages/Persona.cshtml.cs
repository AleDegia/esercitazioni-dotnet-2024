using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebAppDa0.Pages;


// namespace WebAppDa0.Pages;

public class PersonaModel : PageModel
{
    public IEnumerable<Persona> Persone {get; set;}

    //  public Persona Persona1 { get; set; }
    public void OnGet()
    {
        var json = System.IO.File.ReadAllText("wwwroot/persone.json");
        var personeList = JsonConvert.DeserializeObject<List<Persona>>(json);   //converto da json a lista/collection
        Persone = personeList;          //assegno all'enumerable Persone la lista/collection
    }
}