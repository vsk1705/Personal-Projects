using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Web_Scraper.Builders;
using Web_Scraper.Workers;

namespace Web_Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter which city you would like to scrape information from:");
                string craigslistCity = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Please enter which category you would like to scrape:");
                string craigslistCategory = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString("");
                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                        .WithData(content)
                        .WithRegex(@"<title>\s*(.+?)\s*</title>")
                        .WithRegexOptions(RegexOptions.ExplicitCapture)
                        .Build();

                    Scraper scraper = new Scraper();
                    var scrapedElements = scraper.Scrape(scrapeCriteria);

                    if (scrapedElements.Any())
                        foreach (var scrapedElement in scrapedElements)
                            Console.WriteLine(scrapedElement);
                    else
                        Console.WriteLine("There were no matches found for the specified scrape criteria");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
