using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AngleSharp.Dom;
using WTVersus.Models;
using System.Diagnostics;
using DbMaintenance.ParserHelpers;

namespace DbMaintenance.Controllers
{
    /// <summary>Controller for writing tanks data to the database</summary>
    public class TanksParserController : Controller
    {
        #region Creating needed instances
        WikiParserHelper aircraftsParserHelper = new WikiParserHelper();
        #endregion

        #region DbContext
        public AppDbContext Context { get; }
        public TanksParserController(AppDbContext context)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }
        #endregion

        /// <summary>Load tanks parses page</summary>
        /// <returns>View</returns>
        public IActionResult ParseTank()
        {
            var tanksCollection = Context.Tanks.ToList(); //Get colllection from DB

            for (int i = 500; i < Context.Tanks.Count(); i++)
            {
                string wikiLink = tanksCollection.ElementAt(i).WikiLink;
                string[] arrayResult = aircraftsParserHelper.WikiPageParser(wikiLink).Result; //Call parser method who's take loop index as parameter

                //Splitting raw string and get needed value
                string rawRepairCosе = arrayResult[2].ToCharArray().Contains('/') ? arrayResult[2].Split("/")[1].Replace(" ", "") : arrayResult[2].Split("/")[0].Replace(" ", "");

                tanksCollection.ElementAt(i).Image = arrayResult[0];
                tanksCollection.ElementAt(i).BR = Convert.ToDouble(arrayResult[1]);
                tanksCollection.ElementAt(i).RepairCost = Convert.ToInt32(rawRepairCosе);

                Debug.WriteLine(arrayResult[0]);
                Debug.WriteLine(arrayResult[1]);
                Debug.WriteLine(arrayResult[2]);
            }
            Context.SaveChanges();

            return View();
        }

        /// <summary>Add aircrafts from collection range to Db</summary>
        /// <returns>View</returns>
        public IActionResult AddTank()
        {
            Context.Tanks.AddRange
             (
            //new Tank
            //{
            //    VehicleId = 29201,
            //    Name = "SAV 20.12.48",
            //    Nation = "Sweden",
            //    Rank = "II",
            //    Class = "DestroyerTank",
            //    Type = "Premium",
            //    FirstRideYear = 1948,
            //    MaxSpeedAtRoad = 48,
            //    MaxSpeedAtTerrain = 47,
            //    MaxReverseSpeed = 18,
            //    AccelerationTo100 = 14,
            //    TurnTurretTime = 0,
            //    TurnHullTime = 19,
            //    EnginePower = 400,
            //    Weight = 20,
            //    Penetration = 95,
            //    ShellSpeed = 525,
            //    ReloadTime = 1.2,
            //    UpAimAngle = 25,
            //    DownAimAngle = -10,
            //    Stabilizer = false,
            //    AAMachineGun = false,
            //    ShellAP = false,
            //    ShellHE = true,
            //    ShellAPHE = true,
            //    ShellAPCR = false,
            //    ReducedArmorFrontTurret = 0,
            //    ReducedArmorTopSheet = 30,
            //    ReducedArmorBottomSheet = 50,
            //},


                );
            Context.SaveChanges();

            return View();
        }
    }
}