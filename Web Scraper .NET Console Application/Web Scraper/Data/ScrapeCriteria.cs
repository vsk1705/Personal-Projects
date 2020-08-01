using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Web_Scraper
{
    class ScrapeCriteria
    {
        public string Data { get; set; }        
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }
        public List<ScrapeCriteriaPart> Parts { get; set; }
        public ScrapeCriteria()
        {
            Parts = new List<ScrapeCriteriaPart>();               // to look into a HTML element scraped by ScrapeCriteria
        }

    }
}



