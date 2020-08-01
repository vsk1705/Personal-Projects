using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Web_Scraper.Builders
{
    class ScrapeCriteriaBuilder
    {
        private string _data;
        private string _regex;
        private RegexOptions _regexOptions;
        private List<ScrapeCriteriaPart> _parts;
        public ScrapeCriteriaBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            this._data = string.Empty;
            this._regex = string.Empty;
            this._regexOptions = RegexOptions.None;
            this._parts = new List<ScrapeCriteriaPart>();
        }

        public ScrapeCriteriaBuilder WithData(string data)
        {
            this._data = data;
            return this;
        }

        public ScrapeCriteriaBuilder WithRegex(string regex)
        {
            this._regex = regex;
            return this;
        }

        public ScrapeCriteriaBuilder WithRegexOptions(RegexOptions regexOptions)
        {
            this._regexOptions = regexOptions;
            return this;
        }

        public ScrapeCriteriaBuilder WithPart(ScrapeCriteriaPart scrapeCriteriaPart)
        {
            this._parts.Add(scrapeCriteriaPart);
            return this;
        }

        public ScrapeCriteria Build()
        {
            ScrapeCriteria scrapeCriteria = new ScrapeCriteria();
            scrapeCriteria.Data = _data;
            scrapeCriteria.Regex = _regex;
            scrapeCriteria.RegexOption = _regexOptions;
            scrapeCriteria.Parts = _parts;
            return scrapeCriteria;
        }
    }
}


