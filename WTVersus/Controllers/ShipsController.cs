using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WTVersus.Models;

namespace WTVersus.Controllers
{
    public class ShipsController : Controller
    {
        #region DbContext, Logger
        public AppDbContext Context { get; }
        private readonly ILogger<ShipsController> _logger;

        public ShipsController(AppDbContext context, ILogger<ShipsController> logger)
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
            var shipsFromDb = Context.Ships.OrderBy(x => x.VehicleId).ThenBy(x => x.BR).ToList();
            shipsFromDb.Insert(0, new Ship { Image = "https://wtversus.com/images/EmptyShip.png", Nation = "EmptyFlag", Name = "Select ship", VehicleId = 0 }); //Перший пустий елемент, щоб не засмічувати БД
            var selectedShips = new List<Ship>();
            ViewBag.AllShipsSelected = shipsFromDb;

            selectedShips.Add(shipsFromDb.FirstOrDefault(p => p.VehicleId == vehicle1));
            selectedShips.Add(shipsFromDb.FirstOrDefault(p => p.VehicleId == vehicle2));
            selectedShips.Add(shipsFromDb.FirstOrDefault(p => p.VehicleId == vehicle3));
            selectedShips.Add(shipsFromDb.FirstOrDefault(p => p.VehicleId == vehicle4));

            _logger.LogInformation("Log Message");

            return View(selectedShips);
        }

        /// <summary>
        /// Controller show list of all ships
        /// </summary>
        /// <returns>Return vehicle collection from DB to View</returns>
        public IActionResult Tree()
        {
            var shipsFromDb = Context.Ships.OrderByDescending(x => x.Type).ThenBy(t => t.BR);

            return View(shipsFromDb);
        }
    }
}
