using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WTVersus.Models;

namespace WTVersus.Controllers
{
    public class TanksController : Controller
    {
        #region DbContext, Logger
        public AppDbContext Context { get; }
        private readonly ILogger<TanksController> _logger;

        public TanksController(AppDbContext context, ILogger<TanksController> logger)
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
            var tankssFromDb = Context.Tanks.OrderBy(x => x.VehicleId).ThenBy(x=>x.BR).ToList();
            tankssFromDb.Insert(0, new Tank { Image = "https://wtversus.com/images/EmptyTank.png", Nation = "EmptyFlag", Name = "Select vehicle", VehicleId = 0 }); //Перший пустий елемент, щоб не засмічувати БД
            var selectedTanks = new List<Tank>();
            ViewBag.AllTanksSelected = tankssFromDb;

            selectedTanks.Add(tankssFromDb.FirstOrDefault(p => p.VehicleId == vehicle1));
            selectedTanks.Add(tankssFromDb.FirstOrDefault(p => p.VehicleId == vehicle2));
            selectedTanks.Add(tankssFromDb.FirstOrDefault(p => p.VehicleId == vehicle3));
            selectedTanks.Add(tankssFromDb.FirstOrDefault(p => p.VehicleId == vehicle4));

            return View(selectedTanks);
        }

        /// <summary>
        /// Controller show list of all ground vehicles
        /// </summary>
        /// <returns>Return vehicle collection from DB to View</returns>
        public IActionResult Tree()
        {
            var tanksFromDb = Context.Tanks.OrderByDescending(x => x.Type).ThenBy(t => t.BR);

            return View(tanksFromDb);
        }

        /// <summary>
        /// Send models for View
        /// </summary>
        /// <returns>Return vehicle collection from DB to View</returns>
        public IActionResult Count()
        {
            var tanksFromDb = Context.Tanks.ToList();
            return View(tanksFromDb);
        }

        /// <summary>
        /// Send models for View
        /// </summary>
        /// <returns>Return vehicle collection from DB to View</returns>
        public IActionResult Repair()
        {
            var tanksFromDb = Context.Tanks.ToList();
            return View(tanksFromDb);
        }

        /// <summary>
        /// Send models for View
        /// </summary>
        /// <returns>Return vehicle collection from DB to View</returns>
        public IActionResult MaxSpeed()
        {
            var tanksFromDb = Context.Tanks.ToList();
            return View(tanksFromDb);
        }

        /// <summary>
        /// Send models for View
        /// </summary>
        /// <returns>Return vehicle collection from DB to View</returns>
        public IActionResult ReloadAndPenetration()
        {
            var tanksFromDb = Context.Tanks.ToList();
            return View(tanksFromDb);
        }

        /// <summary>
        /// Send models for View
        /// </summary>
        /// <returns>Return vehicle collection from DB to View</returns>
        public IActionResult ThermalAndStab()
        {
            var tanksFromDb = Context.Tanks.ToList();
            return View(tanksFromDb);
        }

        /// <summary>
        /// Send models for View
        /// </summary>
        /// <returns>Return vehicle collection from DB to View</returns>
        public IActionResult NVDAndSmoke()
        {
            var tanksFromDb = Context.Tanks.ToList();
            return View(tanksFromDb);
        }

        /// <summary>
        /// Send models for View
        /// </summary>
        /// <returns>Return vehicle collection from DB to View</returns>
        public IActionResult Shells()
        {
            var tanksFromDb = Context.Tanks.ToList();
            return View(tanksFromDb);
        }

    }
}