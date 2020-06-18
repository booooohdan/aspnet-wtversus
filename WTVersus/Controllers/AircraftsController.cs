using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WTVersus.Models;

namespace WTVersus.Controllers
{
    public class AircraftsController : Controller
    {
        #region DbContext, Logger
        public AppDbContext Context { get; }
        private readonly ILogger<AircraftsController> _logger;

        public AircraftsController(AppDbContext context, ILogger<AircraftsController> logger)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
           
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into Controller");
        }
        #endregion

        /// <summary>
        /// Controller, takes 4 parameters. Default value in Startup.cs
        /// </summary>
        /// <param name="vehicle1">Id for first vehicle</param>
        /// <param name="vehicle2">Id for second vehicle</param>
        /// <param name="vehicle3">Id for third vehicle</param>
        /// <param name="vehicle4">Id for fourth vehicle</param>
        /// <returns>Return vehicle collection from DB to View</returns>
        [HttpGet]
        public IActionResult Compare(int vehicle1, int vehicle2, int vehicle3, int vehicle4)
        {
            var planesFromDb = Context.Planes.OrderBy(x => x.VehicleId).ThenBy(x => x.BR).ToList();
            planesFromDb.Insert(0, new Plane { Image = "https://wtversus.com/images/EmptyPlane.png", Nation = "EmptyFlag", Name = "Select aircraft", VehicleId=0 }); //Перший пустий елемент, щоб не засмічувати БД
            var selectedPlanes = new List<Plane>();
            ViewBag.AllPlanesSelected = planesFromDb;

            selectedPlanes.Add(planesFromDb.FirstOrDefault(p => p.VehicleId == vehicle1));
            selectedPlanes.Add(planesFromDb.FirstOrDefault(p => p.VehicleId == vehicle2));
            selectedPlanes.Add(planesFromDb.FirstOrDefault(p => p.VehicleId == vehicle3));
            selectedPlanes.Add(planesFromDb.FirstOrDefault(p => p.VehicleId == vehicle4));

            _logger.LogInformation("Log Message");

            return View(selectedPlanes);
        }

        /// <summary>
        /// Controller show list ofal vehicles
        /// </summary>
        /// <returns>Return vehicle collection from DB to View</returns>
        public IActionResult Tree()
        {
            var planesFromDb = Context.Planes.OrderByDescending(x => x.Type).ThenBy(t => t.BR);

            return View(planesFromDb);
        }
    }
}