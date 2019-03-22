using System;
using System.IO;

namespace Lab03_Word_Guess_Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "../../../file.txt";

            CreateFile(filePath);
            ReadFile(filePath);
            Console.ReadLine();
        }

        // Create file
        public static void CreateFile(string path)
        {
            string[] wordBank = { "cat", "mouse", "giraffe", "monkey", "snake" };

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string word in wordBank)
                {
                    sw.WriteLine(word);
                }
            }
        }

        // Read file
        public static void ReadFile(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }

        // TODO AddWord() function
        // If no file exists, create one

        // REQUIREMENTS
        // User inputs one letter at a time in guesses
        // Save all guesses, correct and incorrect, throughout each *session*
        // Show letters that've been correctly guessed for the displayed word
        // Mystery word in each new session should come from hard-coded bank of words in external .txt file
        // User can view, add, and delete words in word bank

        // SPECIFICATIONS
        // METHODS
        // Home navigation
        // View words
        // Add word
        // Delete word
        // Exit game
        // Play game

    }
}
