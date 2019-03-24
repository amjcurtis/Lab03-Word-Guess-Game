using System;
using System.IO;

namespace Lab03_Word_Guess_Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "../../../word_game.txt";
            string[] initialWordBank = { "cat", "kitty", "mouse", "giraffe", "monkey", "kitty", "snake" };

            // Create word bank file and populate with initial bank of words
            CreateFile(filePath, initialWordBank);

            Console.WriteLine("Welcome to the Word Guess Game!");

            bool keepShowingInterface = showInterface(filePath);
            while (keepShowingInterface == true)
            {
                try
                {
                    showInterface(filePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    showInterface(filePath);
                    keepShowingInterface = showInterface(filePath);
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Shows Home menu to user
        /// </summary>
        /// <param name="filePath">Path to word bank file</param>
        /// <returns>Returns boolean that tells calling method whether to keep running program</returns>
        public static bool showInterface(string filePath)
        {
            // Show Home menu
            Console.WriteLine(" ");
            Console.WriteLine("Enter the number of the option you would like to select.");
            Console.WriteLine("   1. Play game\n" +
                "   2. View all mystery words\n" +
                "   3. Add new mystery word to word bank\n" +
                "   4. Remove a mystery word from word bank\n" +
                "   5. Exit program");

            bool runProgram = true;

            try
            {
                string userAction = Console.ReadLine();

                while (runProgram == true)
                {
                    switch (userAction)
                    {
                        case "1":
                            Console.WriteLine("You've selected \"Play game.\"");
                            PlayGame(filePath);
                            break;

                        case "2":
                            Console.WriteLine("You've selected \"View all mystery words.\"");
                            ViewWords(filePath);
                            break;

                        case "3":
                            Console.WriteLine("You've selected \"Add new mystery word to word bank.\"");
                            Console.WriteLine("What word would you like to add?");
                            string wordToAdd = Console.ReadLine();
                            AddWord(filePath, wordToAdd);
                            Console.WriteLine("New word successfully added! Here's the updated list of words in your word bank.");
                            ViewWords(filePath);
                            break;

                        case "4":
                            Console.WriteLine("You've selected \"Remove a mystery word from word bank.\"");
                            Console.WriteLine("What word would you like to remove?");
                            string wordToRemove = Console.ReadLine();
                            DeleteWordFromFile(filePath, wordToRemove);
                            Console.WriteLine("Word successfully removed. Here's the updated list of words in your word bank.");
                            ViewWords(filePath);
                            break;

                        case "5":
                            runProgram = false;
                            Console.WriteLine("You've selected \"Exit program.\"");
                            Console.WriteLine("Hit Enter to confirm exit.");
                            Console.ReadLine();
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Please enter just a number 1-5.");
                            break;
                    }

                    // Give user option to choose new option
                    Console.WriteLine(" ");
                    Console.WriteLine("To select a new option, type the number of the option you want.\n" +
                        "Or hit Enter to exit the program.");
                    Console.WriteLine("   1. Play game\n" +
                    "   2. View all mystery words\n" +
                    "   3. Add new mystery word to word bank\n" +
                    "   4. Remove a mystery word from word bank\n" +
                    "   5. Exit program");
                    userAction = Console.ReadLine();
                    if (userAction != "1" &&
                            userAction != "2" &&
                            userAction != "3" &&
                            userAction != "4" &&
                            userAction != "5")
                    {
                        runProgram = false;
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Hit Enter to return to the Home menu.");
            Console.ReadLine();

            return runProgram;
        }

        /// <summary>
        /// Creates new file if no file exists
        /// </summary>
        /// <param name="path">Takes in file path as string</param>
        /// <param name="wordBank">Takes in list of words as string array</param>
        public static void CreateFile(string path, string[] wordBank)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (string word in wordBank)
                    {
                        sw.WriteLine(word);
                    }
                }
            }
        }

        /// <summary>
        /// Writes all words in file to console
        /// </summary>
        /// <param name="path">Path to file</param>
        public static string ViewWords(string path)
        {
            string[] words = File.ReadAllLines(path);

            // Write all words in file to console
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }

            // Returns last word added to file (for testing whether method can retrieve last added word)
            return words[words.Length - 1];
        }

        /// <summary>
        /// Add new word to word bank file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="newWord">New word to add to file</param>
        /// <returns>Number of words in file</returns>
        public static bool AddWord(string path, string newWord)
        {
            string[] words = File.ReadAllLines(path);
            int numberOfWordsBeforeAdding = words.Length;
            Console.WriteLine($"words.Length: {words.Length}");

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(newWord);
            }

            words = File.ReadAllLines(path);
            int numberOfWordsAfterAdding = words.Length;
            Console.WriteLine($"words.Length is now: {words.Length}");

            // If statement; used for returning boolean to use for testing success of AddWord method
            if (numberOfWordsAfterAdding == (numberOfWordsBeforeAdding + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes all instances of specified word from word bank file; if word not exists in file, does nothing
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="wordToDelete">A specified word to delete from word bank file</param>
        public static void DeleteWordFromFile(string path, string wordToDelete)
        {
            // Array of all words in old file
            string[] allWords = File.ReadAllLines(path);
            Console.WriteLine($"allWords.Length: {allWords.Length}");

            // Only update word bank file if word to delete is present in it
            if (Array.Exists(allWords, str => str.Contains(wordToDelete)))
            {
                string tempFilePath = "../../../temp_word_bank.txt";

                // Replace all words in old array that match word to delete with ""
                for (int i = 0; i < allWords.Length; i++)
                {
                    if (allWords[i] == wordToDelete)
                    {
                        allWords[i] = "";
                    }
                }

                // Create new temp file
                using (StreamWriter swForTemp = new StreamWriter(tempFilePath))

                // Write all non-deleted words from old file into temp file
                using (StreamReader srForOldFile = new StreamReader(path))
                {
                    for (int j = 0; j < allWords.Length; j++)
                    {
                        if (allWords[j] != "")
                        {
                            swForTemp.WriteLine(allWords[j]);
                        }
                    }
                }
                string[] filteredLines = File.ReadAllLines(tempFilePath);

                // Delete old file, create new file with updated word bank, and delete temp file 
                DeleteFile(path);
                CreateFile(path, filteredLines);
                DeleteFile(tempFilePath);
            }
            // Redisplay words in file to confirm all instances of specified word have been deleted
            allWords = File.ReadAllLines(path);
            Console.WriteLine($"allWords.Length is now: {allWords.Length}");
        }

        /// <summary>
        /// Deletes file
        /// </summary>
        /// <param name="path">Path to file</param>
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        /// <summary>
        /// Gets random word from file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>Returns randomly picked word</returns>
        public static string GetRandomWordFromFile(string path)
        {
            string[] wordArray = File.ReadAllLines(path);

            Random newRandNum = new Random();

            // Get random index of word array
            int indexOfNewMysteryWord = newRandNum.Next(0, wordArray.Length);
            Console.WriteLine($"indexOfNewMysteryWord: {indexOfNewMysteryWord}");

            // Save word at random index to return as new mystery word
            string randomMysteryWord = wordArray[indexOfNewMysteryWord];
            Console.WriteLine($"randomMysteryWord: {randomMysteryWord}");

            return randomMysteryWord;
        }

        /// <summary>
        /// Checks whether user's guessed letter is present in the mystery word
        /// </summary>
        /// <param name="mysteryWord">The mystery word that the user is trying to guess</param>
        /// <param name="guessedLetter">The letter the user guessed</param>
        /// <returns>Returns Boolean value indicating whether word contains letter</returns>
        public static bool CheckIfWordContainsLetter(string mysteryWord, char guessedLetter)
        {
            if (mysteryWord.Contains(guessedLetter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Contains gameplay functionality for word guessing game
        /// </summary>
        /// <param name="path">Path of file containing word bank for game</param>
        public static void PlayGame(string path)
        {
            // TODO Handle situation where there are no words in file yet
                // Prompt user to add words to word bank file

            string mysteryWord = GetRandomWordFromFile(path);

            // Create char array of letters in mystery word
            char[] mysteryWordLetters = mysteryWord.ToCharArray();
            Console.WriteLine("mysteryWordLetters: [{0}]", string.Join(" ", mysteryWordLetters));
            Console.WriteLine(" ");

            // String that will contain each letter that user guesses
            string stringOfAllGuessedLetters = "";

            // Create array to update with guessed correctly letters
            string[] arrayWithCorrectGuesses = new string[mysteryWordLetters.Length];

            // Initially populate array that will hold correct guesses with '_ '
            for (int i = 0; i < arrayWithCorrectGuesses.Length; i++)
            {
                arrayWithCorrectGuesses[i] = "_ ";
            }

            // Counter to use for limiting number of guesses allowed to number of letters in mystery word
            int count = 0;

            // Loop allows user to guess letters until all letters of word have been guessed OR user runs out of guesses
            while (Array.Exists(arrayWithCorrectGuesses, str => str.Contains("_")) && (count < mysteryWordLetters.Length))
            {
                Console.WriteLine("Guess a letter.");
                Console.WriteLine(" ");

                // Display array of spaces and/or letters guessed correctly so far
                Console.WriteLine("{0}", string.Join(" ", arrayWithCorrectGuesses));

                // Read user input and save to variable
                string guessedLetterAsString = Console.ReadLine();

                // TODO Make user input case-insensitive

                // TODO Add regex test that only allows user to guess letters

                // TODO Handle if user inputs more than one letter or invalid character
                if (guessedLetterAsString.Length > 1)
                {
                    throw new Exception("Oops! You may only enter one letter at a time.");
                }

                Console.WriteLine($"You guessed \"{guessedLetterAsString}\"");
                char guessedLetterAsChar = Convert.ToChar(guessedLetterAsString);

                // Add guessed letter to string of all guessed letters if it's not already in it
                if (!(stringOfAllGuessedLetters.Contains(guessedLetterAsString)))
                {
                    stringOfAllGuessedLetters += guessedLetterAsString;
                }

                // Check if mystery word contains guessed letter 
                bool mysteryWordContainsGuessedLetter = CheckIfWordContainsLetter(mysteryWord, guessedLetterAsChar);

                // Add correctly guessed letters to appropriate index(es) in arrayWithCorrectGuesse
                if (mysteryWordContainsGuessedLetter)
                {
                    // For each letter in mysteryWordLetters array
                    for (int j = 0; j < mysteryWordLetters.Length; j++)
                    {
                        // If guessed letter equals letter in mysteryWordLetters array at [j]
                        if (guessedLetterAsChar == mysteryWordLetters[j])
                        {
                            // Swap in letter for '_ ' in array of correctly guessed letters at [j]
                            arrayWithCorrectGuesses[j] = guessedLetterAsString;
                        }
                    }
                }

                // Display list of all guessed letters
                Console.WriteLine($"The letters you've guessed so far are: {stringOfAllGuessedLetters}");

                count++;
            }
            // Display array of spaces and/or letters guessed correctly so far
            Console.WriteLine("{0}", string.Join(" ", arrayWithCorrectGuesses));

            // Show what mystery word was
            Console.WriteLine($"The mystery word was: {mysteryWord}");
            Console.WriteLine("Hit Enter to return to Home menu.");
            Console.ReadLine();
        }

        // IDEAS
        // Create single method that takes in both the mystery word and user's letter guess and detects if the word contains the letter, and return boolean so I can test

        // REQUIREMENTS
        // User inputs one letter at a time in guesses
        // Save all guessed letters, correct and incorrect, throughout each *session*
        // Show letters that've been correctly guessed for the displayed word
        // Mystery word in each new session should come from hard-coded bank of words in external .txt file
        // User can view, add, and delete words in word bank

        // SPECIFICATIONS
        // METHODS
        // Home navigation
        // Pick random word for game session
        // View words
        // Add word
        // Delete word
        // Exit game
        // Play game

    }
}
