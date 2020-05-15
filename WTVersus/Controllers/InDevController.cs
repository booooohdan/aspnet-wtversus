using Microsoft.AspNetCore.Mvc;

namespace WTVersus.Controllers
{
    public class InDevController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}