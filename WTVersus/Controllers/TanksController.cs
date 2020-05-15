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

        [HttpGet]
        public IActionResult Compare(int vehicle1, int vehicle2, int vehicle3, int vehicle4)
        {
            var tankssFromDb = Context.Tanks.OrderBy(x => x.BR).ToList();
            tankssFromDb.Insert(0, new Tank { Image = "http://wtversus.com/images/EmptyTank.png", Nation = "EmptyFlag", Name = "Select vehicle", VehicleId = 0 }); //Перший пустий елемент, щоб не засмічувати БД
            var selectedTanks = new List<Tank>();
            ViewBag.AllTanksSelected = tankssFromDb;

            selectedTanks.Add(tankssFromDb.FirstOrDefault(p => p.VehicleId == vehicle1));
            selectedTanks.Add(tankssFromDb.FirstOrDefault(p => p.VehicleId == vehicle2));
            selectedTanks.Add(tankssFromDb.FirstOrDefault(p => p.VehicleId == vehicle3));
            selectedTanks.Add(tankssFromDb.FirstOrDefault(p => p.VehicleId == vehicle4));

            return View(selectedTanks);
        }

    }
}