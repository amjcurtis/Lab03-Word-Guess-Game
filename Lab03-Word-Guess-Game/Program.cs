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
            ViewWords(filePath);
            GetRandomWordFromFile(filePath);


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
        public static void ViewWords(string path)
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

            // Test to make sure file is being read and all lines are put in array 
            Console.WriteLine("Word in file: [{0}]", string.Join(", ", wordArray));

            Random newRandNum = new Random();

            // Get random index of word array
            int indexOfNewMysteryWord = newRandNum.Next(0, wordArray.Length);
            Console.WriteLine($"indexOfNewMysteryWord: {indexOfNewMysteryWord}");

            // Save word at random index to return as new mystery word
            string randomMysteryWord = wordArray[indexOfNewMysteryWord];
            Console.WriteLine($"randomMysteryWord: {randomMysteryWord}");

            return randomMysteryWord;
        }


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
