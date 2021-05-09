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
    /// <summary>Controller for writing tanks data to the database</summary>
    public class TanksParserController : Controller
    {
        #region DbContext
        public AppDbContext Context { get; }
        public TanksParserController(AppDbContext context)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }
        #endregion

        public IActionResult ParseTank()
        {
            var tanksCollection = Context.Tanks.ToList(); //Get colllection from DB

            for (int i = 0; i < Context.Tanks.Count(); i++)
            {
                string wikiLink = tanksCollection.ElementAt(i).WikiLink;
                string[] arrayResult = WikiPageParser(wikiLink).Result; //Call parser method who's take loop index as parameter

                //Operation with string and get needed value
                string rawBr = arrayResult[0];
                string rawRepairCost = arrayResult[1].ToCharArray().Contains('→') ?
                    new string(arrayResult[1].Split("→")[1].Where(Char.IsDigit).ToArray()) :
                    new string(arrayResult[1].Split("→")[0].Where(Char.IsDigit).ToArray());
                string rawEnginePower = new string(arrayResult[2].Where(Char.IsDigit).ToArray());
                string rawWeight = arrayResult[3].Substring(6).TrimEnd(' ','t');

                //Assignment of values to DB records
                tanksCollection.ElementAt(i).BR = Convert.ToDouble(rawBr);
                tanksCollection.ElementAt(i).RepairCost = string.IsNullOrEmpty(rawRepairCost) ? 0 : Convert.ToInt32(rawRepairCost);
                tanksCollection.ElementAt(i).EnginePower = string.IsNullOrEmpty(rawEnginePower) ? 0 : Convert.ToInt32(rawEnginePower);
                tanksCollection.ElementAt(i).Weight = string.IsNullOrEmpty(rawWeight) ? 0 : Convert.ToDouble(rawWeight);

                Debug.WriteLine(new string('-', 20));
                Debug.WriteLine(tanksCollection.ElementAt(i).Name);
                Debug.WriteLine(rawBr);
                Debug.WriteLine(rawRepairCost);
                Debug.WriteLine(rawEnginePower);
                Debug.WriteLine(rawWeight);
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
            string resultEnginePower = EnginePowerParser(document);
            string resultWeight = WeightParser(document);

            return new string[] { resultBattleRating, resultRepairCost, resultEnginePower, resultWeight };
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
                 m.GetAttribute("class").Contains("specs_char_line")).ElementAt(19).TextContent.ToString();

            return repairCost;
        }

        private static string EnginePowerParser(IDocument document)
        {
            string enginePower = document.All.Where(m =>
                 m.LocalName == "div" &&
                 m.HasAttribute("class") &&
                 m.GetAttribute("class").Contains("specs_char_line")).ElementAt(13).TextContent.ToString();

            return enginePower;
        }

        private static string WeightParser(IDocument document)
        {
            string weight = document.All.Where(m =>
                 m.LocalName == "div" &&
                 m.HasAttribute("class") &&
                 m.GetAttribute("class").Contains("specs_char_line")).ElementAt(10).TextContent.ToString();

            return weight;
        }

        /// <summary>Add tanks from collection range to Db</summary>
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
