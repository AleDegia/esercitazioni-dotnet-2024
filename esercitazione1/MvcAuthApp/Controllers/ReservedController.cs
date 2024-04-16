using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MvcAuthApp.Controllers
{
    public class ReservedController : Controller
    {
        //GET:/Reserved/Index  (permette di vedere la pagina a /Reserved/Index se sono autenicato senno no)
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        // GET: /Reserved/Admin
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }
        // GET: /Reserved/User
        [Authorize(Roles = "User")]
        public IActionResult User()
        {
            return View();
        }
    }
}