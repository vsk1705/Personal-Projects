using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Word_Unscrambler.Data;
using Word_Unscrambler.Workers;

namespace Word_Unscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private const string wordListFileName = Constants.WordListFilePath;
        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscrambler = false;
                do
                {
                    Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);
                    string option = Console.ReadLine().ToUpper() ?? string.Empty;
                    switch (option)
                    {
                        case Constants.Manual: Console.WriteLine(Constants.EnterScrambledWordsManually);
                                               ExecuteManualEntryScenario();
                                               break;
                        case Constants.File:   Console.Write(Constants.EnterScrambledWordsViaFile);
                                               ExecuteFileScenarioa();
                                               break;
                        default:               Console.WriteLine(Constants.InvalidOption);
                                               break;
                    }
                    string userChoice = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                        userChoice = Console.ReadLine().ToUpper() ?? string.Empty;
                    }
                    while (userChoice != Constants.Yes && userChoice != Constants.No);

                    if (userChoice == Constants.Yes) { continueWordUnscrambler = true; }
                    else { continueWordUnscrambler = false; }
                }
                while (continueWordUnscrambler);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ProgramTermination + ex.Message);
            }

            static void ExecuteFileScenarioa()
            {
                try
                {
                    var fileName = Console.ReadLine() ?? string.Empty;
                    string[] scrambledWords = _fileReader.Read(fileName);
                    DisplayMatchedUnscrambledWords(scrambledWords);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(Constants.ScrambledWordsFileError + ex.Message);
                }
            }

            static void ExecuteManualEntryScenario()
            {
                var userInput = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = userInput.Split(",");
                DisplayMatchedUnscrambledWords(scrambledWords);
            }

            static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
            {
                string[] wordList = _fileReader.Read(wordListFileName);

                List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

                if (matchedWords.Any())
                {
                    foreach (var matchedWord in matchedWords)
                        Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
                else
                    Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}



