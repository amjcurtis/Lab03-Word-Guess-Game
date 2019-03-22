using System;
using System.IO;

namespace Lab03_Word_Guess_Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "../../../file.txt";
            string wordToAdd = "HEY!!";

            CreateFile(filePath);
            // AddWord(filePath, wordToAdd);
            ReadFile(filePath);
            Console.ReadLine();
            // DeleteFile(filePath);

            Console.ReadLine();
        }

        // Create file
        public static void CreateFile(string path)
        {
            string[] wordBank = { "cat", "mouse", "giraffe", "monkey", "snake" };

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
        public static void ReadFile(string path)
        {
            string[] words = File.ReadAllLines(path);

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
        }

        // Add word
        public static void AddWord(string path, string newWord)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(newWord);
            }
        }

        // Delete file
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

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
