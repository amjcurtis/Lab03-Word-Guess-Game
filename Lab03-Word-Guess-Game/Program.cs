using System;
using System.IO;

namespace Lab03_Word_Guess_Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "../../../file.txt";
            string[] wordBank = { "cat", "mouse", "giraffe", "monkey", "snake" };
            string wordToAdd = "HEY!!";

            // TODO Show Home menu
                // TODO Give options to Play Game, View Words, Add Word, Remove Word, Delete File, Exit Program

            CreateFile(filePath, wordBank);
            AddWord(filePath, wordToAdd);
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

        // Read file
        public static void ViewWords(string path)
        {
            string[] words = File.ReadAllLines(path);

            // Display all words in file in console
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
        }

        // Add word
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

        // TODO Delete word from file


        // Delete file
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        // Pick random word for game session
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

        public static void PlayGame(string path)
        {
            // TODO Handle situation where there are no words in file yet
                // Prompt user to add words to word bank file

            string mysteryWord = GetRandomWordFromFile(path);

            // Create char array of letters in mystery word
            char[] mysteryWordLetters = mysteryWord.ToCharArray();
            Console.WriteLine("mysteryWordLetters: [{0}]", string.Join(" ", mysteryWordLetters));
            Console.WriteLine(" ");

            // Create array storing all user's guesses so far
            char[] arrayOfAllGuessedLetters = new char[mysteryWordLetters.Length];

            // Create array to update with guessed correctly letters
            string[] arrayWithCorrectGuesses = new string[mysteryWordLetters.Length];

            // Initially populate array that will hold correct guesses with '_ '
            for (int i = 0; i < arrayWithCorrectGuesses.Length; i++)
            {
                arrayWithCorrectGuesses[i] = "_ ";
            }

            //////// LOGIC for for loop below ////////

            // LOOP
            // Prompt user to guess letter
            // Display array of spaces and/or letters guessed correctly so far
            // Read user input
            // Validate user input
                // IF input invalid, throw error
                // ELSE continue
            // IF user input is valid letter
                // Show user the letter they guessed
                // IF letter is contained in word
                    // Add letter to array that shows blanks and letters guessed correctly so far
                    // Tell user they guessed correctly
                // ELSE
                    // Tell user they didn't guess correctly, and don't update array of correctly guessed letters
                // Add letter to list of letters they've guessed so far
            // Display array of all letters guessed so far

            // Run loop to let user guess letter until number of user guesses == number of letters in word
            for (int i = 0; i < mysteryWordLetters.Length; i++)
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

                // Check if mystery word contains guessed letter 
                bool mysteryWordContainsGuessedLetter = CheckIfWordContainsLetter(mysteryWord, guessedLetterAsChar);

                // Add correctly guessed letters to appropriate index(es) in arrayWithCorrectGuesse
                if (mysteryWordContainsGuessedLetter == true) // Need to explicitly include '== true'?
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

                // Add guessed letter to array of all guessed letters
                arrayOfAllGuessedLetters[i] = guessedLetterAsChar;

                // Display list of all guessed letters
                Console.WriteLine("The letters you've guessed so far are: [{0}]", string.Join(", ", arrayOfAllGuessedLetters));
            }
        }

        // TODO Method to check if mystery word contains guessed letter
            // Should take in two params: mystery word and guessed letter
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
