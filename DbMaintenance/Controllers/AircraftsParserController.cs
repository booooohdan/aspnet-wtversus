using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using AngleSharp.Html.Parser;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using WTVersus.Models;
using System.Diagnostics;

namespace WTVersus.Controllers
{
    public class AircraftsParserController : Controller
    {
        #region DbContext
        public AppDbContext Context { get; }
        public AircraftsParserController(AppDbContext context)
        {
            Context = context;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }
        #endregion

        public IActionResult Index()
        {
            for (int i = 640; i < 649; i++)
            {
                var planess = Context.Planes.ToList(); //Отримання колекції з БД
                string[] arrayResult = ParseImageString(planess.ElementAt(i).WikiLink).Result; //Виклик методу з параметом індекса циклу
                var first = arrayResult[0];
                var second = arrayResult[1];

                string third;
                var arrayFromParser = arrayResult[2].Split("/");
                var charArray = arrayResult[2].ToCharArray();
                third = charArray.Contains('/') ? arrayFromParser[1].Replace(" ", "") : arrayFromParser[0].Replace(" ", "");

                planess.ElementAt(i).Image = first;
                planess.ElementAt(i).BR = Convert.ToDouble(second);
                planess.ElementAt(i).RepairCost = Convert.ToInt32(third);

                Debug.WriteLine(first);
            }
            Context.SaveChanges();

            return View();
        }

        [NonAction]
        public async Task<string[]> ParseImageString(string wikiLink)
        {
            string adress = wikiLink;
            string[] srcStartAt = { "https://encyclopedia.warthunder.com" }; //початок посилання зображення

            ////////Ініціалізація і передача адреси////////
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(adress);

            ////////Парсинг картинки////////
            var resultImage = from element in document.All
                              from attribute in element.Attributes
                              where srcStartAt.Any(e => attribute.Value.StartsWith(e))
                              select attribute;
            string result = resultImage.FirstOrDefault().Value.ToString();

            ////////Парсинг БР////////
            var result1 = document.All.Where(m =>
           m.LocalName == "span" &&
           m.HasAttribute("class") &&
           m.GetAttribute("class").Contains("ttx-rb ttx-value")
                       ).ElementAt(0).TextContent.ToString();
            ////////Парсинг ремонту////////
            string result2;
            try
            {
                result2 = document.All.Where(m =>
                m.LocalName == "span" &&
                m.HasAttribute("class") &&
                m.GetAttribute("class").Contains("ttx-rb ttx-value")
                            ).ElementAt(1).TextContent.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                result2 = "0";
            }


            string[] resultArray = new string[] { result, result1, result2 };

            return resultArray;
        }

        public IActionResult AddPlane()
        {


            Context.Planes.AddRange
                (
                //new Plane
                //{
                //    VehicleId = 11101,
                //    Name = "P-26A-34 M2",
                //    Nation = "USA",
                //    Rank = "I",
                //    BR = 1.0,
                //    Class = "Fighter",
                //    Type = "Usual",
                //    FirstFlyYear = 1932,
                //    MaxSpeedAt0 = 362,
                //    MaxSpeedAt5000 = 365,
                //    BombLoad = 92,
                //    TurnAt0 = 18,
                //    Climb = 419,
                //    Flutter = 510,
                //    EnginePower = 611,
                //    Weight = 1600,
                //    ThrustToWeight = 0.38,
                //    BurstMass = 0.71,
                //    ASMissile = false,
                //    HCannon = false,
                //    HBomb = true,
                //    HTorpedo = false
                //},

                );
            Context.SaveChanges();


            return View();
        }


    }
}