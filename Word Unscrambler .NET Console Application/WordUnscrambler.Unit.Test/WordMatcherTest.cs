using Microsoft.VisualStudio.TestTools.UnitTesting;
using Word_Unscrambler.Workers;

namespace WordUnscrambler.Unit.Test
{
    [TestClass]
    public class WordMatcherTest
    {
        private readonly WordMatcher _wordMatcher = new WordMatcher();
        [TestMethod]
        public void ScrambledWordMatchesWordsInTheWordList()
        {
            string[] WordList = { "cat", "chair", "more" };
            string[] ScrambledWords = { "tca" };

            var matchedWords = _wordMatcher.Match(ScrambledWords, WordList);
            Assert.IsTrue(matchedWords.Count == 1);
            Assert.IsTrue(matchedWords[0].ScrambledWord == "tca");
            Assert.IsTrue(matchedWords[0].Word == "cat");
        }

        [TestMethod]
        public void ScrambledWordsMatchesWordsInTheWordList()
        {
            string[] WordList = { "cat", "chair", "more" };
            string[] ScrambledWords = { "tca", "omre" };

            var matchedWords = _wordMatcher.Match(ScrambledWords, WordList);
            Assert.IsTrue(matchedWords.Count == 2);
            Assert.IsTrue(matchedWords[0].ScrambledWord == "tca");
            Assert.IsTrue(matchedWords[0].Word == "cat");
            Assert.IsTrue(matchedWords[1].ScrambledWord == "omre");
            Assert.IsTrue(matchedWords[1].Word == "more");
        }
    }
}

