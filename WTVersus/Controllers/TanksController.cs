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
    public class TanksController : Controller
    {
        #region DbContext
        public AppDbContext Context { get; }
        public TanksController(AppDbContext context)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }
        #endregion

        [HttpGet]
        public IActionResult Compare(int vehicle1, int vehicle2, int vehicle3, int vehicle4)
        {
            var tankssFromDb = Context.Tanks.OrderBy(x => x.BR).ToList();
            tankssFromDb.Insert(0, new Tank { Image = "http://wtversus.com/images/EmptyPlane.png", Nation = "EmptyFlag", Name = "Select vehicle", VehicleId = 0 }); //Перший пустий елемент, щоб не засмічувати БД
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