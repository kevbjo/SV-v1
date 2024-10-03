using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SV_v2.Models;

namespace SV_v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Den här metoden hanterar startsidan
        public IActionResult Index()
        {
            return View(); // Återgår till Index.cshtml
        }

        public IActionResult Flashcards()
        {
            return RedirectToAction("Index", "Flashcard"); // Omled till FlashcardController
        }

        public IActionResult Applex()
        {
            return View();
        }

        public IActionResult Lagar()
        {
            return View();
        }

        public IActionResult Kontakt()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
