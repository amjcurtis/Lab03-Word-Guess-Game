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
            DisplayBlankWord(filePath);

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

        public static void DisplayBlankWord(string path)
        {
            // TODO Handle situation where there are no words in file yet

            string mysteryWord = GetRandomWordFromFile(path);

            char[] mysteryLetters = mysteryWord.ToCharArray();
            Console.WriteLine("mysteryLetters: [{0}]", string.Join(" ", mysteryLetters));

            Console.WriteLine(" ");
            Console.WriteLine("Guess a letter.");
            foreach (char letter in mysteryLetters)
            {
                Console.Write("_ ");
            }
            Console.WriteLine(" ");

            // TODO Read user input and save to variable
            string guessedLetterAsString = Console.ReadLine();
            Console.WriteLine($"You guessed {guessedLetterAsString}");
            char guessedLetterAsChar = Convert.ToChar(guessedLetterAsString);

            // TODO Handle if user inputs more than one letter or invalid character

            // TODO Add valid guessed letter to array of guessed letters

            // TODO Display list of guessed letters


            // TODO Call method to check if mystery word contains guessed letter 
            bool mysteryWordContainsGuessedLetter = CheckIfWordContainsLetter(mysteryWord, guessedLetterAsChar);

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
