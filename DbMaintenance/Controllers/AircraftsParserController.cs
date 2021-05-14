using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AngleSharp.Dom;
using WTVersus.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using AngleSharp;

namespace DbMaintenance.Controllers
{
    /// <summary>Controller for writing plane data to the database</summary>
    public class AircraftsParserController : Controller
    {
        #region DbContext
        public AppDbContext Context { get; }
        public AircraftsParserController(AppDbContext context)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US"); //fix point and comma conflict in DB
        }
        #endregion

        public IActionResult ParsePlane()
        {
            var planesCollection = Context.Planes.ToList(); //Get colllection from DB

            for (int i = 0; i < Context.Planes.Count(); i++)
            {
                string wikiLink = planesCollection.ElementAt(i).WikiLink;
                string[] arrayResult = WikiPageParser(wikiLink).Result; //Call parser method who's take loop index as parameter

                //Operation with string and get needed value
                string rawBr = arrayResult[0];
                string rawRepairCost = arrayResult[1].ToCharArray().Contains('→') ?
                    new string(arrayResult[1].Split("→")[1].Where(Char.IsDigit).ToArray()) :
                    new string(arrayResult[1].Split("→")[0].Where(Char.IsDigit).ToArray());
                string rawFlutter = new string(arrayResult[2].Where(Char.IsDigit).ToArray());

                //Assignment of values to DB records
                planesCollection.ElementAt(i).BR = Convert.ToDouble(rawBr);
                planesCollection.ElementAt(i).RepairCost = string.IsNullOrEmpty(rawRepairCost) ? 0 : Convert.ToInt32(rawRepairCost);
                planesCollection.ElementAt(i).Flutter = Convert.ToInt32(rawFlutter);

                Debug.WriteLine(new string('-', 20));
                Debug.WriteLine(planesCollection.ElementAt(i).Name);
                Debug.WriteLine(rawBr);
                Debug.WriteLine(rawRepairCost);
                Debug.WriteLine(rawFlutter);
            }

            Context.SaveChanges();
            return View();
        } 

        public async Task<string[]> WikiPageParser(string wikiLink)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(wikiLink);

            //Get data via LINQ
            string resultBattleRating = BattleRatingParser(document);
            string resultRepairCost = RepairCostParser(document);
            string resultFlutter = FlutterParser(document);

            return new string[] { resultBattleRating, resultRepairCost, resultFlutter };
        }

        private string BattleRatingParser(IDocument document)
        {
            string br = document.QuerySelectorAll("td").Select(m => m.TextContent).ElementAt(5);

            return br;
        }

        private static string RepairCostParser(IDocument document)
        {
            string repairCost = document.All.Where(m =>
                 m.LocalName == "div" &&
                 m.HasAttribute("class") &&
                 m.GetAttribute("class").Contains("specs_char_line")).ElementAt(14).TextContent.ToString();

            if (repairCost.Contains("RB"))
            {
                return repairCost;
            }
            else
            {
                return repairCost;
            }
        }
        
        private static string FlutterParser(IDocument document)
        {
            string flutter = document.All.Where(m =>
                 m.LocalName == "div" &&
                 m.HasAttribute("class") &&
                 m.GetAttribute("class").Contains("specs_char_line")).ElementAt(10).TextContent.ToString();

            return flutter;
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