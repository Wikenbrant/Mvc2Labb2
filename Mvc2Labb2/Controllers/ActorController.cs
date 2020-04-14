using Microsoft.AspNetCore.Mvc;
using Mvc2Labb2.ViewModels;

namespace Mvc2Labb2.Controllers
{
    public class ActorController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}