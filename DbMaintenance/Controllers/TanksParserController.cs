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

namespace DbMaintenance.Controllers
{
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


        public IActionResult Index()
        {
            for (int i = 0; i <Context.Tanks.Count(); i++)
            {
                var tankss = Context.Tanks.ToList(); //Отримання колекції з БД
                string[] arrayResult = ParseImageString(tankss.ElementAt(i).WikiLink).Result; //Виклик методу з параметом індекса циклу
                var first = arrayResult[0];
                var second = arrayResult[1];

                string third;
                var arrayFromParser = arrayResult[2].Split("/");
                var charArray = arrayResult[2].ToCharArray();
                third = charArray.Contains('/') ? arrayFromParser[1].Replace(" ", "") : arrayFromParser[0].Replace(" ", "");

                tankss.ElementAt(i).Image = first;
                tankss.ElementAt(i).BR = Convert.ToDouble(second);
                tankss.ElementAt(i).RepairCost = Convert.ToInt32(third);

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