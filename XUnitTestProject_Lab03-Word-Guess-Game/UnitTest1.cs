using Lab03_Word_Guess_Game;
using System.IO;
using Xunit;

namespace XUnitTestProject_Lab03_Word_Guess_Game
{
    public class UnitTest1
    {
        //[Fact]
        //public void CanRetrieveAllWordsFromFile()
        //{

        //}

        //[Fact]
        //public void CanAddNewWordToFile()
        //{
        //    // Arrange
        //    string pathArg = "../../../word_game.txt";
        //    //string currentPath = "C:\\Users\\Andrew\\codework\\401\\Lab03-Word-Guess-Game\\Lab03-Word-Guess-Game/word_game.txt";
        //    string wordToAdd = "Booyah";
        //    //string[] words = File.ReadAllLines(currentPath);
        //    //bool exists = File.Exists("../../../../Lab03-Word-Guess-Game/word_game.txt");

        //    // Act
        //    // Expect: should return number of words/lines in file (i.e. length of array of all words)
        //    int testLength = Program.AddWord(pathArg, wordToAdd);

        //    // Assert
        //    Assert.Equal((words.Length + 1), testLength);
        //    //Assert.True(exists);
        //}

        /// <summary>
        /// Tests whether word contains a letter by checking equality of expected boolean and actual returned boolean
        /// </summary>
        /// <param name="boolean">Boolean returned by the method being tested</param>
        /// <param name="guessedLetter">Char to search for in word</param>
        [Theory]
        [InlineData(true, 'r')]
        [InlineData(false, 'a')]

        public void CanDetectIfMysteryWordContainsGuessedLetter(bool boolean, char guessedLetter)
        {
            // Arrange
            string mysteryWord = "crocodile";

            // Act
            bool wordContainsLetter = Program.CheckIfWordContainsLetter(mysteryWord, guessedLetter);

            //Assert
            Assert.Equal(boolean, wordContainsLetter);
        }

        /// <summary>
        /// Tests whether word contains a letter by asserting boolean true where true is expected
        /// </summary>
        /// <param name="guessedLetter">Char to search for in word</param>
        [Theory]
        [InlineData('c')]

        public void CanReturnTrueIfMysteryWordContainsGuessedLetter(char guessedLetter)
        {
            // Arrange
            string mysteryWord = "crocodile";

            // Act
            bool wordContainsLetter = Program.CheckIfWordContainsLetter(mysteryWord, guessedLetter);

            //Assert
            Assert.True(wordContainsLetter);
        }

        /// <summary>
        /// Tests whether word contains a letter by asserting boolean false where false is expected
        /// </summary>
        /// <param name="guessedLetter">Char to search for in word</param>
        [Theory]
        [InlineData('x')]

        public void CanReturnFalseIfNotMysteryWordContainsGuessedLetter(char guessedLetter)
        {
            // Arrange
            string mysteryWord = "crocodile";

            // Act
            bool wordContainsLetter = Program.CheckIfWordContainsLetter(mysteryWord, guessedLetter);

            //Assert
            Assert.False(wordContainsLetter);
        }
    }
}
