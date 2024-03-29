using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProgettoRazorQuiz.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    //non servono perchè gia gli asp-page deli botti portano a Registrazione e Login

    // public IActionResult OnPostRegistrati()
    //     {
    //         // Redirect alla pagina di registrazione
    //         return RedirectToPage("/Registrati");
    //     }

    //     public IActionResult OnPostLogin()
    //     {
    //         // Redirect alla pagina di login
    //         return RedirectToPage("/Login");
    //     }
}
