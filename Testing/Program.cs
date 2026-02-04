using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hangmanStageOne = @"|-------
|      |
|
|
|
|
|";

            string hangmanStageTwo = @"|-------
|      |
|      0
|
|
|
|";

            string hangmanStageThree = @"|-------
|      |
|      0
|      I
|
|
|";

            string hangmanStageFour = @"|-------
|      |
|      0
|      I
|     /
|
|";

            string hangmanStageFive = @"|-------
|      |
|      0
|      I
|     / \
|
|";

            string hangmanStageSix = @"|-------
|      |
|      0
|    --I
|     / \
|
|";

            string hangmanStageSeven = @"|-------
|      |
|      0
|    --I--
|     / \
|
|";

            List<string> hangmanStages = new List<string> {hangmanStageOne, hangmanStageTwo, hangmanStageThree, hangmanStageFour, hangmanStageFive, hangmanStageSix, hangmanStageSeven};
            List<string> wordList = new List<string> { "cooperative", "board", "pollution", "ceremony", "carriage", "invasion", "contraction", "reputation", "realize", "farewell" };
            List<char> chosenWordList = new List<char> { };
            List<string> chosenWordListString = new List<string> { };
            List<string> guessedCharacters = new List<string> { };
            List<string> currentGuessedProgress = new List<string> { }; 

            int hangmanCount = 0;

            int listValueCount = wordList.Count() - 1;

            Random rnd = new Random();
            int ranNum = rnd.Next(0, listValueCount);

            string ranWordFromList = wordList[ranNum];

            foreach (char letter in ranWordFromList)
            {
                chosenWordList.Add(letter);
            }

            foreach (var listedValue in chosenWordList)
            {
                chosenWordListString.Add(listedValue.ToString());
            }

            string youLostCONST = $"You lost! Better luck next time. The word was //{ranWordFromList}//";
            string youWonCONST = $"You won! Well done. You got the word correct, it was indeed //{ranWordFromList}//";

            Console.WriteLine("Welcome to Hang Man");
            Console.WriteLine("Created by Albert S");
            Console.WriteLine("");
            Console.WriteLine("1. Play");
            Console.WriteLine("2. Quit");
            Console.WriteLine("");
            Console.Write("Enter number from menu: ");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.Clear();
                Console.WriteLine("A random word has been chosen!");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Try and guess it! Remember though, only one letter at a time");
                Console.ReadLine();
                Console.Clear();

                foreach (var itemListed in chosenWordList)
                {
                    currentGuessedProgress.Add("_");
                }

                while (true)
                {
                    if (hangmanCount == 6)
                    {
                        Console.Clear();
                        Console.WriteLine(youLostCONST);
                        break;
                    }

                    if (chosenWordListString.SequenceEqual(currentGuessedProgress))
                    {
                        Console.Clear();
                        Console.WriteLine(youWonCONST);
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine(hangmanStages[hangmanCount]);
                    Console.WriteLine();
                    Console.Write("The word: ");

                    foreach (var listItem in currentGuessedProgress)
                    {
                        Console.Write(listItem);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("Your guess: ");
                    string userGuess = Console.ReadLine();

                    ///main logic here, checks if the chosen word list has the users guess, if so add that guess to the guessed letters list
                    if (chosenWordList.Any(entry => entry.ToString().Contains(userGuess)))
                    {
                        guessedCharacters.Add(userGuess);

                        currentGuessedProgress.Clear();

                        ///iterates through the chosen word list, then checks if the current iteration is in the guessed characters list and if so add it to the current progess so it can be output to the console
                        foreach (char checkUserInputLetter in chosenWordList)
                        {
                            if (guessedCharacters.Any(entry => entry.Contains(checkUserInputLetter)))
                            {
                                currentGuessedProgress.Add(checkUserInputLetter.ToString());
                            }

                            ///otherwise just add an underscore to the current progress since the use didn't guess right
                            else
                            {
                                currentGuessedProgress.Add("_");
                            }

                        }
                    }
                    ///

                    else
                    {
                        hangmanCount += 1;
                    }
                }
            }

            else if (userInput == "2")
            {
                Console.Clear();
                Console.WriteLine("Goodbye");
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Invalid entry");
            }
        }
    }
}
