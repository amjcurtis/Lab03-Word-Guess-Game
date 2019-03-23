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

            CreateFile(filePath, wordBank);
            AddWord(filePath, wordToAdd);
            ViewWords(filePath);
            // GetRandomWordFromFile(filePath);
            DisplayBlankWord(filePath);

            Console.ReadLine();
            // DeleteFile(filePath);

            Console.ReadLine();
        }

        // Create file
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
            string mysteryWord = GetRandomWordFromFile(path);

            char[] letters = mysteryWord.ToCharArray();
            Console.WriteLine("letters: [{0}]", string.Join(" ", letters));

            Console.WriteLine(" ");
            Console.WriteLine("Guess a letter.");
            foreach (char letter in letters)
            {
                Console.Write("_ ");
            }
            Console.WriteLine(" ");

            // TODO Display list of letters guessed so far


            // TODO Call method to 


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
