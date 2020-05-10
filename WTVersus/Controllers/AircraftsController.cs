using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WTVersus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WTVersus.Controllers
{
    public class AircraftsController : Controller
    {
        #region DbContext
        public AppDbContext Context { get; }
        public AircraftsController(AppDbContext context)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }
        #endregion

        #region Logger
        private readonly ILogger<AircraftsController> _logger;

        public AircraftsController(ILogger<AircraftsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into Controller");
        }
        #endregion

        [HttpGet]
        public IActionResult Compare(int vehicle1, int vehicle2, int vehicle3, int vehicle4)
        {
            var planesFromDb = Context.Planes.OrderBy(x => x.BR).ToList();
            planesFromDb.Insert(0, new Plane { Image = "http://wtversus.com/images/EmptyPlane.png", Nation = "EmptyFlag", Name = "Select aircraft", VehicleId=0 }); //Перший пустий елемент, щоб не засмічувати БД
            var selectedPlanes = new List<Plane>();
            ViewBag.AllPlanesSelected = planesFromDb;

            selectedPlanes.Add(planesFromDb.FirstOrDefault(p => p.VehicleId == vehicle1));
            selectedPlanes.Add(planesFromDb.FirstOrDefault(p => p.VehicleId == vehicle2));
            selectedPlanes.Add(planesFromDb.FirstOrDefault(p => p.VehicleId == vehicle3));
            selectedPlanes.Add(planesFromDb.FirstOrDefault(p => p.VehicleId == vehicle4));

            _logger.LogInformation("Log Message");

            return View(selectedPlanes);
        }

    }
}
