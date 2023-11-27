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

        public static void StartGame()
        {
            bool gameIsActive = true;

            do
            {
                if (!gameIsActive)
                {
                    //Bryter loop om spelet inte är aktivt
                    Console.WriteLine("Spelet ej aktivt");
                    break;
                }
                else
                {
                    Console.WriteLine("spelet är aktivt");
                    break;//bryter loopen för att inte loopa sönder
                }
            } while (gameIsActive);
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

        public void DisplayGuessedLetters()
        {
            Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));
            int lettersLeft = splitWord.Count - guessedLetters.Distinct().Count();
            Console.WriteLine($"Letters left to guess: {lettersLeft}");
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

            do
            {
                Console.Write("> ");
                string userInput = Console.ReadLine().Trim();
                string[] argument = userInput.Split();
                string command = argument[0];

                if (command == "avsluta")
                {
                    Console.WriteLine("Programmet avslutat");
                    break;
                }
                else if (command == "starta")
                {
                    //Kommando för att starta nytt spel
                    Hangman.StartGame();
                }
                else if (command == "hjälp")
                {
                    //Kommando för hjälpfunktion
                }
                else if (command == "nytt")
                {
                    //Kommando för nytt ord
                }
                else if (command == "språk")
                {
                    //Kommando för att ändra språk?
                }
                else
                {
                    Console.WriteLine("Okänt kommando");
                }

            } while (true);
=======
            Hangman game = new Hangman();
            // Låt användaren gissa bokstäver och hantera spelets logik
            // Använd de olika funktionerna från Hangman-klassen
>>>>>>> b813fe497916617874290a995bd6777791b6c61f
        }
    }
}