using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace HangmanGame
{
    class Program
    {
        static char currentLanguage = 's';

    class Hangman
    {
        public bool Victory = false;
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
                string[] words;
                // Läs in ordlista från en textfil
                if (currentLanguage == 's')
                {
                    words = File.ReadAllLines("../../../wordlistSwedish.txt");
                }
                else
                {
                    words = File.ReadAllLines("../../../wordlistEnglish.txt");
                }
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
                    Console.Write("Guess a letter: ");
                    char guessedLetter = Console.ReadKey().KeyChar;

                    // Check if the guessed letter is in the secret word
                    if (!game.splitWord.Contains(guessedLetter))
                    {
                        // Decrement attemptsLeft only if the guessed letter is incorrect
                        game.attemptsLeft--;
                    }

                    // Add the guessed letter to guessedLetters of the current game instance
                    game.guessedLetters.Add(guessedLetter);


                    Console.Clear();

                if (guessedLetter == '!')
                {
                    Console.WriteLine("Quitting the game, returning to the meny");
                    gameIsActive = false;
                }
                else if (!game.splitWord.Contains(guessedLetter))
                {
                    Console.WriteLine($"The letter '{guessedLetter}' dont are not in the word");
                }
                else
                {
                    Console.WriteLine($"The letter '{guessedLetter}' are in the word");
                }

                    if (game.attemptsLeft <= 0)
                    {
                        game.DisplayHangman();
                        game.DisplayWord();
                        gameIsActive = false;

                    Console.WriteLine("Oh no! you have lost!");
                    Console.WriteLine($"'{game.secretWord}' was your word!");
                    Console.WriteLine("Press Enter to return to the meny");

                    Console.ReadLine();
                    Console.Clear();
                }
                if (game.Victory || game.AllLettersGuessed())
                {
                    game.DisplayHangman();
                    game.DisplayWord();
                    gameIsActive = false;

                    if (game.Victory)
                    {
                        Console.WriteLine("Congratulation, you have guessed the word!");
                    }
                    else
                    {
                        Console.WriteLine("You have guessed all the letters correctly!");
                    }

                    Console.WriteLine("Press Enter to return to the meny");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

        }
        public static void NewGuessWord()   //stora/små bokstäver?
        {
            Console.WriteLine("Enter a new word");
            string NewWord = Console.ReadLine();

            if (!string.IsNullOrEmpty(NewWord) && !NewWord.Contains(" ")) //checkar så orden inte har mellanslag, kan lägga in flera tecken att förbjuda som!"#¤
            {
                    if (currentLanguage == 's')
                    {
                        using (StreamWriter writer = new StreamWriter("../../../wordlistSwedish.txt", true))
                        {
                            writer.WriteLine(NewWord);
                        }
                        Console.WriteLine($"{NewWord} successfully saved!");
                    }
                    else
                    {
                        using (StreamWriter writer = new StreamWriter("../../../wordlistEnglish.txt", true))
                        {
                            writer.WriteLine(NewWord);
                        }
                        Console.WriteLine($"{NewWord} successfully saved!");
                    }
            }        
            else
            {
                Console.WriteLine("Something went wrong with the word!");
            }
        }
        public static void HelpMessage()
        {
            Console.WriteLine("start          -      Begin a new round of hangman                  ");
            Console.WriteLine("new            -      Create a new word to the wordlist             ");
            Console.WriteLine("language       -      Change between english and swedish wordlist   ");
            Console.WriteLine("help           -      Display all commands                          ");
            Console.WriteLine("quit           -      Quit the program                              ");
            Console.WriteLine("!              -      Quit the active game                          ");
            Console.WriteLine("---");
        }


            public void DisplayHangman()
            {
                // Implementera ASCII-grafik för hängagubben
                Console.WriteLine($"Lives left: {attemptsLeft}/10");
                // Updatera attemptsLeft sen anropa DisplayHangman() för att rita gubben beroende på hur många liv man har kvar
                if (this.attemptsLeft == 9)
                {
                    Console.WriteLine("\n\n\n\n\n");
                }
                else if (this.attemptsLeft == 10)
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
                else if (this.attemptsLeft == 6)
                {
                    Console.WriteLine("   __________");
                    Console.WriteLine("   |        |");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("   |   ");
                    }
                }
                else if (this.attemptsLeft == 5)
                {
                    Console.WriteLine("   __________");
                    Console.WriteLine("   |        |");
                    Console.WriteLine("   |        O");
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine("   |   ");
                    }
                }
                else if (attemptsLeft == 4)
                {
                    Console.WriteLine("   __________");
                    Console.WriteLine("   |        |");
                    Console.WriteLine("   |        O");
                    Console.WriteLine("   |        |");
                    Console.WriteLine("   |   ");
                }
                else if (attemptsLeft == 3)
                {
                    Console.WriteLine("   __________");
                    Console.WriteLine("   |        |");
                    Console.WriteLine("   |        O");
                    Console.WriteLine("   |        |");
                    Console.WriteLine("   |       /");
                }
                else if (attemptsLeft == 2)
                {
                    Console.WriteLine("   __________");
                    Console.WriteLine("   |        |");
                    Console.WriteLine("   |        O");
                    Console.WriteLine("   |        |");
                    Console.WriteLine(@"   |       / \");
                }
                else if (attemptsLeft == 1)
                {
                    Console.WriteLine("   __________");
                    Console.WriteLine("   |        |");
                    Console.WriteLine("   |        O");
                    Console.WriteLine("   |       /|");
                    Console.WriteLine(@"   |       / \");
                }
                else if (attemptsLeft == 0)
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

            public void DisplayGuessedLetters()
            {
                // Använder HashSet för att tabort dublicerade bokstäver från guessedLetters
                HashSet<char> uniqueGuessedLetters = new HashSet<char>(guessedLetters);

                Console.WriteLine("Guessed letters: " + string.Join(", ", uniqueGuessedLetters));

                int lettersLeft = 0;
                foreach (char letter in splitWord)
                {
                    if (!guessedLetters.Contains(letter))
                    {
                        lettersLeft++;
                    }
                }

            Console.WriteLine($"Letters left to guess: {lettersLeft}");
            if (lettersLeft == 0)
            {
                Victory = true;
            }
        }
        public bool AllLettersGuessed()
        {
            foreach (char letter in splitWord)
            {
                if (!guessedLetters.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }
    }

        static void Main(string[] args)
        {
            Console.WriteLine("help = all commands");
            do
            {

                Console.Write("> ");
                string userInput = Console.ReadLine().Trim();
                string[] argument = userInput.Split();
                string command = argument[0];

                if (command == "quit")
                {
                    Console.WriteLine("Exiting the program");
                    break;
                }
                else if (command == "start")
                {
                    //Kommando för att starta nytt spel
                    Console.Clear();
                    Hangman.StartGame();
                }
                else if (command == "help")
                {
                    //Kommando för hjälpfunktion
                    Hangman.HelpMessage();
                }
                else if (command == "new")
                {
                    //Kommando för nytt ord
                    Hangman.NewGuessWord();
                    //Hur stora/små ord,
                }
                else if (command == "language")
                {
                    //Kommando för att ändra språk
                    Console.Write($"Currently selected language is ");
                    if(currentLanguage == 'e') Console.WriteLine("English");
                    else Console.WriteLine("Swedish");
                    Console.WriteLine("Type 'e' for English or 's' for Swedish");
                    do
                    {
                        Console.Write("> ");
                        currentLanguage = Console.ReadKey().KeyChar;
                        Console.WriteLine("");
                        if (currentLanguage == 'e')
                        {
                            Console.WriteLine("Language changed to English");
                            break;
                        }
                        else if(currentLanguage == 's')
                        {
                            Console.WriteLine("Language changed to Swedish");
                            break;
                        }   
                        else
                        {
                            Console.WriteLine("Unknown command, please type 'e' for English or 's' for Swedish");
                        }
                    } while (true);
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }

            } while (true);

            // Låt användaren gissa bokstäver och hantera spelets logik
            // Använd de olika funktionerna från Hangman-klassen

        }
    }
}