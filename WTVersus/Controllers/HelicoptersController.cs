using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WTVersus.Models;

namespace WTVersus.Controllers
{
    public class HelicoptersController : Controller
    {
        #region DbContext, Logger
        public AppDbContext Context { get; }
        private readonly ILogger<HelicoptersController> _logger;

        public HelicoptersController(AppDbContext context, ILogger<HelicoptersController> logger)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            _logger = logger;
            _logger.LogDebug(1, "NLog injected into Controller");
        }
        #endregion

        /// <summary>
        /// Controllers, takes 4 parameters. Default value in Startup.cs
        /// </summary>
        /// <param name="vehicle1">Id for first vehicle</param>
        /// <param name="vehicle2">Id for second vehicle</param>
        /// <param name="vehicle3">Id for third vehicle</param>
        /// <param name="vehicle4">Id for fourth vehicle</param>
        /// <returns>Return vehicle collection from DB to View</returns>
        [HttpGet]
        public IActionResult Compare(int vehicle1, int vehicle2, int vehicle3, int vehicle4)
        {
            var helisFromDb = Context.Helis.OrderBy(x => x.BR).ToList();
            helisFromDb.Insert(0, new Heli { Image = "http://wtversus.com/images/EmptyHeli.png", Nation = "EmptyFlag", Name = "Select aircraft", VehicleId=0 }); //Перший пустий елемент, щоб не засмічувати БД
            var selectedHelis = new List<Heli>();
            ViewBag.AllHelisSelected = helisFromDb;

            selectedHelis.Add(helisFromDb.FirstOrDefault(p => p.VehicleId == vehicle1));
            selectedHelis.Add(helisFromDb.FirstOrDefault(p => p.VehicleId == vehicle2));
            selectedHelis.Add(helisFromDb.FirstOrDefault(p => p.VehicleId == vehicle3));
            selectedHelis.Add(helisFromDb.FirstOrDefault(p => p.VehicleId == vehicle4));

            _logger.LogInformation("Log Message");

            return View(selectedHelis);
        }
    }
}