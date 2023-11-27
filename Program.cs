using System;
using System.Collections.Generic;
using System.IO;

namespace HangmanGame
{
    class Hangman
    {
        private string secretWord;
        private int attemptsLeft;
        private List<char> guessedLetters;
        private List<char> splitWord;

        public Hangman()
        {
            // Initialisera variabler och listor
            // Antal försök innan hängagubben ritas helt
            secretWord = PickRandomWord();
            Console.WriteLine("The secret word is: " + secretWord);

        }

        public string PickRandomWord()
        {
            // Läs in ordlista från en textfil
            string[] words = File.ReadAllLines("../../../wordlist.txt");

            // Välj ett slumpmässigt ord från listan
            Random rand = new Random();
            return words[rand.Next(0, words.Length)].ToLower(); // Slumpmässigt ord 
            splitWord = new List<char>(secretWord.ToCharArray());
        }

        public void StartGame()
        {
            // Implementera start av spelet
            Console.WriteLine("test test test");
            Console.WriteLine("test2");
        }

        public void DisplayHangman()
        {
            // Implementera ASCII-grafik för hängagubben
        }

        public void DisplayWord()
        {
            // Implementera funktion för att visa gissade bokstäver i ordet
        }

        public void GuessLetter(char letter)
        {
            // Implementera logik för att gissa bokstäver
        }

        public void CheckGameEnd()
        {
            // Implementera logik för att kontrollera om spelet är slut (vinst/förlust)
        }
        public void AddWordToList()
        {
            // Implementera logik för att lägga till ord i listan
        }

        public void DisplayResult()
        {
            // Implementera funktion för att visa resultatet (vinst/förlust)
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "help")
                {
                    Console.WriteLine("helping you");
                }
                else if (input == "nej")
=======
            while(true)
            {
                string input = Console.ReadLine();
                if(input == "help")
                {
                    Console.WriteLine("helping you");
                }
                else if(input == "nej") 
>>>>>>> 694ae51f0bde1a673e9f0f1f2984bdbe928410e4
                {
                    Console.WriteLine("nej");
                }
                else if (input == "du")
                {
                    Console.WriteLine("du");
                }
                else if (input == "ja")
                {
                    Console.WriteLine("ja");
                }
                else if (input == "!!!!!!!!")
                {
                    Console.WriteLine("!!!!!!!");
                }
            }
            // Låt användaren gissa bokstäver och hantera spelets logik
            // Använd de olika funktionerna från Hangman-klassen
        }
    }
}