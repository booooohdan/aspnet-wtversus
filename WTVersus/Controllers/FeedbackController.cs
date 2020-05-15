using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WTVersus.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(ILogger<FeedbackController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into Controller");
        }

        public IActionResult Index()
        {  
            return View();
        }
    }
}