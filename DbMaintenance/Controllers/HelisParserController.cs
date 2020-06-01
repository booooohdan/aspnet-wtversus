using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AngleSharp.Dom;
using WTVersus.Models;
using System.Diagnostics;
using DbMaintenance.ParserHelpers;

namespace DbMaintenance.Controllers
{
    /// <summary>Controller for writing heli data to the database</summary>
    public class HelisParserController : Controller
    {
        #region Creating needed instances
        WikiParserHelper helisParserHelper = new WikiParserHelper();
        #endregion

        #region DbContext
        public AppDbContext Context { get; }
        public HelisParserController(AppDbContext context)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US"); //fix point and comma conflict in DB
        }
        #endregion

        /// <summary>Load helis parses page</summary>
        /// <returns>View</returns>
        public IActionResult ParseHeli()
        {
            var helisCollection = Context.Helis.ToList(); //Get colllection from DB

            for (int i = 0; i < Context.Helis.Count(); i++)
            {
                string wikiLink = helisCollection.ElementAt(i).WikiLink;
                string[] arrayResult = helisParserHelper.WikiPageParser(wikiLink).Result; //Call parser method who's take loop index as parameter

                //Splitting raw string and get needed value
                string rawRepairCosе = arrayResult[2].ToCharArray().Contains('/') ? arrayResult[2].Split("/")[1].Replace(" ", "") : arrayResult[2].Split("/")[0].Replace(" ", "");

                helisCollection.ElementAt(i).Image = arrayResult[0];
                helisCollection.ElementAt(i).BR = Convert.ToDouble(arrayResult[1]);
                helisCollection.ElementAt(i).RepairCost = Convert.ToInt32(rawRepairCosе);

                Debug.WriteLine(arrayResult[0]);
                Debug.WriteLine(arrayResult[1]);
                Debug.WriteLine(arrayResult[2]);
            }

            Context.SaveChanges();
            return View();
        }

        /// <summary>Add helis from collection range to Db</summary>
        /// <returns>View</returns>
        public IActionResult AddHeli()
        {
            Context.Helis.AddRange
                (

            //new Heli
            //{
            //    VehicleId = 37701,
            //    Name = "EC-665 Tiger HAD",
            //    Nation = "France",
            //    Rank = "VII",
            //    BR = 10.3,
            //    Class = "AttackHelicopter",
            //    Type = "Usual",
            //    FirstFlyYear = 1991,
            //    MaxSpeed = 331,
            //    ClimbTo1000 = 93,
            //    Turn360 = 7,
            //    EnginePower = 2934,
            //    Weight = 6000,
            //    AGMCount = 8,
            //    AGMArmorPenetration = 1100,
            //    AGMSpeed = 475,
            //    AGMRange = 8000,
            //    ASMCount = 68,
            //    BombLoad = 0,
            //    AGMissile = true,
            //    ASMissile = true,
            //    AAMissile = true,
            //    Bomb = false,
            //    Flares = true,
            //}


                );
            Context.SaveChanges();
            return View();
        }

    }
}