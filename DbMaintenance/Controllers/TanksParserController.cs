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

            for (int i = 600; i < Context.Tanks.Count(); i++)
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


              );
            Context.SaveChanges();

            return View();
        }
    }
}