using System;
using System.IO;

namespace Lab03_Word_Guess_Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "../../../word_game.txt";
            string[] wordBank = { "cat", "kitty", "mouse", "giraffe", "monkey", "kitty", "snake" };
            string wordToAdd = "kitty";
            string wordToDelete = "kitty";

            // TODO Show Home menu
                // TODO Give options to Play Game, View Words, Add Word, Remove Word, Delete File, Exit Program

            CreateFile(filePath, wordBank);
            AddWord(filePath, wordToAdd);
            ViewWords(filePath);

            DeleteWordFromFile(filePath, wordToDelete);
            ViewWords(filePath);

            // GetRandomWordFromFile(filePath);
            PlayGame(filePath);

            Console.ReadLine();
            // DeleteFile(filePath);

            Console.ReadLine();
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
        public static void ViewWords(string path)
        {
            string[] words = File.ReadAllLines(path);

            // Write all words in file to console
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
        }

        /// <summary>
        /// Add new word to word bank file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="newWord">New word to add to file</param>
        /// <returns>Number of words in file</returns>
        public static int AddWord(string path, string newWord)
        {
            string[] words = File.ReadAllLines(path);
            Console.WriteLine($"words.Length: {words.Length}");

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(newWord);
            }

            words = File.ReadAllLines(path);
            Console.WriteLine($"words.Length is now: {words.Length}");
            return words.Length;
        }

        /// <summary>
        /// Deletes all instances of specified word from word bank file; if word not exists in file, does nothing
        /// </summary>
        /// <param name="path"></param>
        /// <param name="wordToDelete"></param>
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

                // TODO Handle if user inputs more than one letter or invalid character


                Console.WriteLine($"You guessed {guessedLetterAsString}");
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
