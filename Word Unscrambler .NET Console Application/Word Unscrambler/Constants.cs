using System;
using System.Collections.Generic;
using System.Text;

namespace Word_Unscrambler
{
    public class Constants
    {
        public const string OptionsOnHowToEnterScrambledWords = "Enter scrambled word(s) manually or as a file: M - manually / F - file";
        public const string OptionsOnContinuingTheProgram = "Do you want to continue: (Y/N)";

        public const string EnterScrambledWordsManually = "Enter scrambled words manually(separated by commas if multiple):";
        public const string EnterScrambledWordsViaFile = "Enter full path inlcuding the file name:";
        public const string InvalidOption = "Invalid option recognised";

        public const string ScrambledWordsFileError = "Scrambled words file could not be loaded";
        public const string ProgramTermination = "The program will be terminated";

        public const string MatchFound = "Match found for {0}: {1}";
        public const string MatchNotFound = "No matches have been found";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string WordListFilePath = "wordlist.txt";
    }
}
