﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Web_Scraper.Workers
{
    class Scraper
    {
        public List<String> Scrape(ScrapeCriteria scrapeCriteria)
        {
            List<String> scrapedElements = new List<string>();

            MatchCollection matches = Regex.Matches(scrapeCriteria.Data, scrapeCriteria.Regex, scrapeCriteria.RegexOption);

            foreach(Match match in matches)
            {
                if (!scrapeCriteria.Parts.Any())
                    scrapedElements.Add(match.Groups[0].Value);
                else
                {
                    foreach(var part in scrapeCriteria.Parts)
                    {
                        Match matchedPart = Regex.Match(match.Groups[0].Value, part.Regex, part.RegexOption);
                        if (matchedPart.Success)
                            scrapedElements.Add(matchedPart.Groups[1].Value);
                    }
                }
            }

            return scrapedElements;
        }
    }
}
