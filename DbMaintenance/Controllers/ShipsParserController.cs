using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AngleSharp.Dom;
using WTVersus.Models;
using System.Diagnostics;
using DbMaintenance.ParserHelpers;

namespace DbMaintenance.Controllers
{    
    /// <summary>Controller for writing ship data to the database</summary>
    public class ShipsParserController : Controller
    {
        #region Creating needed instances
        WikiParserHelper shipsParserHelper = new WikiParserHelper();
        #endregion

        #region DbContext
        public AppDbContext Context { get; }
        public ShipsParserController(AppDbContext context)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US"); //fix point and comma conflict in DB
        }
        #endregion

        /// <summary>Load ships parses page</summary>
        /// <returns>View</returns>
        public IActionResult ParseShip()
        {
            var shipsCollection = Context.Ships.ToList(); //Get colllection from DB

            for (int i = 0; i < Context.Ships.Count(); i++)
            {
                string wikiLink = shipsCollection.ElementAt(i).WikiLink;
                string[] arrayResult = shipsParserHelper.WikiPageParser(wikiLink).Result; //Call parser method who's take loop index as parameter

                //Splitting raw string and get needed value
                string rawRepairCosе = arrayResult[2].ToCharArray().Contains('/') ? arrayResult[2].Split("/")[1].Replace(" ", "") : arrayResult[2].Split("/")[0].Replace(" ", "");

                shipsCollection.ElementAt(i).Image = arrayResult[0];
                shipsCollection.ElementAt(i).BR = Convert.ToDouble(arrayResult[1]);
                shipsCollection.ElementAt(i).RepairCost = Convert.ToInt32(rawRepairCosе);

                Debug.WriteLine(arrayResult[0]);
                Debug.WriteLine(arrayResult[1]);
                Debug.WriteLine(arrayResult[2]);
            }

            Context.SaveChanges();
            return View();
        }

        /// <summary>Add ships from collection range to Db</summary>
        /// <returns>View</returns>
        public IActionResult AddShip()
        {
            Context.Ships.AddRange
                (
                    
                );
            Context.SaveChanges();
            return View();
        }
    }
}
