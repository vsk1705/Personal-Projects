using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using Web_Scraper;
using Web_Scraper.Builders;
using Web_Scraper.Workers;

namespace WebScraper.Unit.Test
{
    [TestClass]
    public class ScraperTest
    {
        private readonly Scraper _scraper = new Scraper();
        [TestMethod]
        public void FoundElementsWithNoParts()
        {
            var content = "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\">some text</a> more fluff data";

            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"">(.*?)</a>")
                .WithRegexOptions(RegexOptions.ExplicitCapture)
                .Build();

            var elements = _scraper.Scrape(scrapeCriteria);
            Assert.IsTrue(elements.Count == 1);
            Assert.IsTrue(elements[0] == "<a href=\"http://domain.com\" data-id=\"someId\">some text</a>");
        }


        [TestMethod]
        public void FoundElementsWithParts()
        {
            var content = "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\">some text</a> more fluff data";

            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"">(.*?)</a>")
                .WithRegexOptions(RegexOptions.ExplicitCapture)
                .WithPart(new ScrapeCriteriaPartBuilder()
                             .WithRegex(@">(.*?)</a>")
                             .WithRegexOptions(RegexOptions.Singleline)
                             .Build())
                .WithPart(new ScrapeCriteriaPartBuilder()
                             .WithRegex(@"href=\""(.*?)\""")
                             .WithRegexOptions(RegexOptions.Singleline)
                             .Build())
                .Build();

            var elements = _scraper.Scrape(scrapeCriteria);
            Assert.IsTrue(elements.Count == 2);
            Assert.IsTrue(elements[0] == "some text");
            Assert.IsTrue(elements[1] == "http://domain.com");
        }
    }
}
