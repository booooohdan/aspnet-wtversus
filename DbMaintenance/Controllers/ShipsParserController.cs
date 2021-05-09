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
    /// <summary>Controller for writing ship data to the database</summary>
    public class ShipsParserController : Controller
    {
        #region DbContext
        public AppDbContext Context { get; }
        public ShipsParserController(AppDbContext context)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US"); //fix point and comma conflict in DB
        }
        #endregion

        public IActionResult ParseShip()
        {
            var shipsCollection = Context.Ships.ToList(); //Get colllection from DB

            for (int i = 1; i < Context.Ships.Count(); i++)
            {
                string wikiLink = shipsCollection.ElementAt(i).WikiLink;
                string[] arrayResult = WikiPageParser(wikiLink).Result; //Call parser method who's take loop index as parameter

                //Operation with string and get needed value
                string rawBr = arrayResult[0];
                string rawRepairCost = arrayResult[1].ToCharArray().Contains('→') ?
                    new string(arrayResult[1].Split("→")[1].Where(Char.IsDigit).ToArray()) :
                    new string(arrayResult[1].Split("→")[0].Where(Char.IsDigit).ToArray());

                //Assignment of values to DB records
                shipsCollection.ElementAt(i).BR = Convert.ToDouble(rawBr);
                shipsCollection.ElementAt(i).RepairCost = string.IsNullOrEmpty(rawRepairCost) ? 0 : Convert.ToInt32(rawRepairCost);

                Debug.WriteLine(new string('-', 20));
                Debug.WriteLine(shipsCollection.ElementAt(i).Name);
                Debug.WriteLine(rawBr);
                Debug.WriteLine(rawRepairCost);
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

            return new string[] { resultBattleRating, resultRepairCost };
        }

        private string BattleRatingParser(IDocument document)
        {
            string br = document.QuerySelectorAll("td").Select(m => m.TextContent).ElementAt(5);

            return br;
        }

        private static string RepairCostParser(IDocument document)
        {
            string repairCost;
            repairCost = document.All.Where(m =>
                 m.LocalName == "div" &&
                 m.HasAttribute("class") &&
                 m.GetAttribute("class").Contains("specs_char_line")).ElementAt(12).TextContent.ToString();
            if (repairCost.Contains("RB"))
            {
                return repairCost;
            }

            if (repairCost.Contains("Total cost"))
            {
                repairCost = document.All.Where(m =>
                 m.LocalName == "div" &&
                 m.HasAttribute("class") &&
                 m.GetAttribute("class").Contains("specs_char_line")).ElementAt(11).TextContent.ToString();
                return repairCost;
            }
            if (repairCost.Contains("AB"))
            {
                repairCost = document.All.Where(m =>
                 m.LocalName == "div" &&
                 m.HasAttribute("class") &&
                 m.GetAttribute("class").Contains("specs_char_line")).ElementAt(13).TextContent.ToString();
                return repairCost;
            }
            else
            {
                Debug.WriteLine("PROBLEM WITH SHIPS REPAIR COST. VALUE " + repairCost);
                return repairCost;
            }
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
