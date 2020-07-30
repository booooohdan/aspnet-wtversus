using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace DbMaintenance.ParserHelpers
{
    /// <summary>Parser helper methods</summary>
    public class WikiParserHelper
    {
        /// <summary>AngleSharp wiki page parser</summary>
        /// <param name="wikiLink">Link to the wiki vehicle</param>
        /// <returns>Array with 3 parsed string elements</returns>
        public async Task<string[]> WikiPageParser(string wikiLink)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(wikiLink);

            //Get data via LINQ
            string resultImage = ImageParser(new string[] { "https://encyclopedia.warthunder.com" }, document);
            string resultBattleRating = BattleRatingParser(document);
            string resultRepairCost = RepairCostParser(document);

            return new string[] { resultImage, resultBattleRating, resultRepairCost };
        }

        /// <summary>Get images URL </summary>
        /// <param name="srcStartAt">URL starts from</param>
        /// <param name="document">Angle Sharp document</param>
        /// <returns>String of image URL</returns>
        private static string ImageParser(string[] srcStartAt, IDocument document)
        {
            var resultImage = from element in document.All
                                  from attribute in element.Attributes
                                  where srcStartAt.Any(e => attribute.Value.StartsWith(e))
                                  select attribute;

            return resultImage.FirstOrDefault()?.Value.ToString();
        }

        /// <summary>Get repair cost value </summary>
        /// <param name="document">Angle Sharp document</param>
        /// <returns>String of repair cost</returns>
        private static string RepairCostParser(IDocument document)
        {
            string repairCost;
            try
            {
                repairCost = document.All.Where(m =>
                m.LocalName == "span" &&
                m.HasAttribute("class") &&
                m.GetAttribute("class").Contains("ttx-rb ttx-value")
                            ).ElementAt(1).TextContent.ToString();
            }
            catch (ArgumentOutOfRangeException)
            {
                repairCost = "0";
            }

            return repairCost;
        }

        /// <summary>Get battle rating value </summary>
        /// <param name="document">Angle Sharp document</param>
        /// <returns>String of battle rating</returns>
        private static string BattleRatingParser(IDocument document)
        {
            return document.All.Where(m =>
           m.LocalName == "span" &&
           m.HasAttribute("class") &&
           m.GetAttribute("class").Contains("ttx-rb ttx-value")
                       ).ElementAt(0).TextContent.ToString();
        }
    }
}
