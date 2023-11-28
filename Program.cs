using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace HangmanGame
{

    class Hangman
    {
        private string secretWord;
        private int attemptsLeft; //Börjar med 10
        private List<char> guessedLetters;
        private List<char> splitWord;

        public Hangman()
        {
            // Initialisera variabler och listor
            // Antal försök innan hängagubben ritas helt
            secretWord = PickRandomWord();
            attemptsLeft = 10;

            guessedLetters = new List<char>();
            splitWord = new List<char>(secretWord.ToCharArray());
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
            Hangman game = new Hangman();
            bool gameIsActive = true;
            while (gameIsActive)

            {
                game.DisplayGuessedLetters();
                game.DisplayWord();
                game.DisplayHangman();
                // Get user input for guessing a letter
                Console.WriteLine("Guess a letter:");
                char guessedLetter = Console.ReadKey().KeyChar;

                // Add the guessed letter to guessedLetters of the current game instance
                game.guessedLetters.Add(guessedLetter);

                Console.Clear();
            }

        }
        public static void NewGuessWord()   //stora/små bokstäver?
        {
            Console.WriteLine("Ange ett nytt ord");
            string NewWord = Console.ReadLine();

            if (!string.IsNullOrEmpty(NewWord) && !NewWord.Contains(" ")) //checkar så orden inte har mellanslag, kan lägga in flera tecken att förbjuda som!"#¤
            {
                using (StreamWriter writer = new StreamWriter("../../../wordlist.txt", true))
                {
                    writer.WriteLine(NewWord);
                }
                Console.WriteLine($"{NewWord} lyckades att sparas!");
            }
            else
            {
                Console.WriteLine($"Något gick fel med ordet!");
            }
        }
        public static void HelpMessage()
        {
            Console.WriteLine("starta   -      Påbörjar en ny runda                 ");
            Console.WriteLine("nytt     -      Lägger till ett nytt ord i ordlistan ");
            Console.WriteLine("språk    -      Ändrar språk på spelet     !NYI!     ");
            Console.WriteLine("hjälp    -      Visar alla kommandon                 ");
            Console.WriteLine("avsluta  -      Stänger av spelet                    ");
            Console.WriteLine("---");
        }


        public void DisplayHangman()
        {
            // Implementera ASCII-grafik för hängagubben
            // Updatera attemptsLeft sen anropa DisplayHangman() för att rita gubben beroende på hur många liv man har kvar
            if (this.attemptsLeft == 9)
            {
                Console.WriteLine("\n\n\n\n\n\n");
            }
            else if (this.attemptsLeft == 8)
            {
                Console.WriteLine("");
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("   |   ");
                }
            }
            else if (this.attemptsLeft == 7)
            {
                Console.WriteLine("   __________");
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("   |   ");
                }
            }
            else if(this.attemptsLeft == 6)
            {
                Console.WriteLine("   __________");
                Console.WriteLine("   |        |");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("   |   ");
                }
            }
            else if(this.attemptsLeft==5)
            {
                Console.WriteLine("   __________");
                Console.WriteLine("   |        |");
                Console.WriteLine("   |        O");
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("   |   ");
                }
            }
            else if(attemptsLeft == 4)
            {
                Console.WriteLine("   __________");
                Console.WriteLine("   |        |");
                Console.WriteLine("   |        O");
                Console.WriteLine("   |        |");
                Console.WriteLine("   |   ");
            }
            else if(attemptsLeft == 3)
            {
                Console.WriteLine("   __________");
                Console.WriteLine("   |        |");
                Console.WriteLine("   |        O");
                Console.WriteLine("   |        |");
                Console.WriteLine("   |       /");
            }
            else if(attemptsLeft == 2) 
            {
                Console.WriteLine("   __________");
                Console.WriteLine("   |        |");
                Console.WriteLine("   |        O");
                Console.WriteLine("   |        |");
                Console.WriteLine(@"   |       / \");
            }
            else if(attemptsLeft == 1) 
            {
                Console.WriteLine("   __________");
                Console.WriteLine("   |        |");
                Console.WriteLine("   |        O");
                Console.WriteLine("   |       /|");
                Console.WriteLine(@"   |       / \");
            }
            else if(attemptsLeft == 0) 
            {
                Console.WriteLine("   __________");
                Console.WriteLine("   |        |");
                Console.WriteLine("   |        O");
                Console.WriteLine(@"   |       /|\");
                Console.WriteLine(@"   |       / \");
            }
            if (attemptsLeft < 9) { Console.WriteLine("   |   "); }
            if (attemptsLeft <= 9) { Console.WriteLine("___|___"); }
        }

        public void DisplayWord()
        {
            foreach (char letter in splitWord)
            {
                if (guessedLetters.Contains(letter))
                {
                    Console.Write(letter + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
        }

        public void CheckGameEnd()
        {
            // Implementera logik för att kontrollera om spelet är slut (vinst/förlust)
        }

        public void DisplayGuessedLetters()
        {
            Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters)); // Access guessedLetters directly

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
            Console.WriteLine("hjälp = alla kommandon");
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
                    //Om bokstaven finns med i ordet:
                    //Console.WriteLine($"Bokstaven '{variabelnamn?}' finns med i ordet");
                }
                else if (command == "hjälp")
                {
                    //Kommando för hjälpfunktion
                    Hangman.HelpMessage();
                }
                else if (command == "nytt")
                {
                    //Kommando för nytt ord
                    Hangman.NewGuessWord();
                    //Hur stora/små ord,
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

            // Låt användaren gissa bokstäver och hantera spelets logik
            // Använd de olika funktionerna från Hangman-klassen

        }
    }
}