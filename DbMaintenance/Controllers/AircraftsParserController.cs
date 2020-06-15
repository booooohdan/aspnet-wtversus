using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AngleSharp.Dom;
using WTVersus.Models;
using System.Diagnostics;
using DbMaintenance.ParserHelpers;

namespace DbMaintenance.Controllers
{
    /// <summary>Controller for writing plane data to the database</summary>
    public class AircraftsParserController : Controller
    {
        #region Creating needed instances
        WikiParserHelper aircraftsParserHelper = new WikiParserHelper();
        #endregion

        #region DbContext
        public AppDbContext Context { get; }
        public AircraftsParserController(AppDbContext context)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US"); //fix point and comma conflict in DB
        }
        #endregion

        /// <summary>Load aircrafts parses page</summary>
        /// <returns>View</returns>
        public IActionResult ParsePlane()
        {
            var planesCollection = Context.Planes.ToList(); //Get colllection from DB

            for (int i = 600; i < Context.Planes.Count(); i++)
            {
                string wikiLink = planesCollection.ElementAt(i).WikiLink;
                string[] arrayResult = aircraftsParserHelper.WikiPageParser(wikiLink).Result; //Call parser method who's take loop index as parameter

                //Splitting raw string and get needed value
                string rawRepairCosе = arrayResult[2].ToCharArray().Contains('/') ? arrayResult[2].Split("/")[1].Replace(" ", "") : arrayResult[2].Split("/")[0].Replace(" ", "");

                planesCollection.ElementAt(i).Image = arrayResult[0];
                planesCollection.ElementAt(i).BR = Convert.ToDouble(arrayResult[1]);
                planesCollection.ElementAt(i).RepairCost = Convert.ToInt32(rawRepairCosе);

                Debug.WriteLine(arrayResult[0]);
                Debug.WriteLine(arrayResult[1]);
                Debug.WriteLine(arrayResult[2]);
            }

            Context.SaveChanges();
            return View();
        }


        /// <summary>Add aircrafts from collection range to Db</summary>
        /// <returns>View</returns>
        public IActionResult AddPlane()
        {
            Context.Planes.AddRange
                (

                );
            Context.SaveChanges();
            return View();
        }
    }
}