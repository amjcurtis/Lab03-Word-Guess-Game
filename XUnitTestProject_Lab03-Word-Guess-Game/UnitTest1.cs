using Lab03_Word_Guess_Game;
using Xunit;

namespace XUnitTestProject_Lab03_Word_Guess_Game
{
    public class UnitTest1
    {
        /// <summary>
        /// Tests whether ViewWords method can retrieve and display last added words
        /// </summary>
        [Fact]
        public void CanRetrieveAllWordsFromFile()
        {
            // Arrange
            string pathArg = "../../../../Lab03-Word-Guess-Game/word_game.txt"; // Better alternative is to "sandbox" my tests and create separate test.txt file in corresponding location in test solution and run test on that rather than on real "production" .txt file
            string wordToAdd = "Booyah";

            // Act
            Program.AddWord(pathArg, wordToAdd);
            string lastWordAdded = Program.ViewWords(pathArg);

            // Assert
            Assert.Equal(wordToAdd, lastWordAdded);
        }

        /// <summary>
        /// Tests whether number of words in file is incremented by 1 after new word added
        /// </summary>
        [Fact]
        public void CanAddNewWordToFile()
        {
            // Arrange
            string pathArg = "../../../../Lab03-Word-Guess-Game/word_game.txt";
            string wordToAdd = "Booyah";

            // Act
            bool testLength = Program.AddWord(pathArg, wordToAdd);

            // Assert
            Assert.True(testLength);
        }

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
