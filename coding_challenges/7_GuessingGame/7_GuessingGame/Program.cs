using System;
using System.Collections.Generic;

namespace _7_GuessingGameChallenge
{
    public class Program
    {
        private static Random randGen = new();
        private const int MIN_GUESS = 1;
        private const int MAX_GUESS = 100;
        private const int NUM_GUESSES = 10;
        public static void Main(string[] args)
        {
            do
            {
                int num = GetRandomNumber();
                Console.WriteLine($"You will have {NUM_GUESSES} chances to guess my number");
                List<int> guesses = new();
                int compare;
                do
                {
                    int guess = GetUsersGuess();
                    guesses.Add(guess);
                    compare = CompareNums(num, guess);
                    if (compare < 0)
                    {
                        Console.WriteLine("Too high");
                    }
                    else if (compare > 0)
                    {
                        Console.WriteLine("Too low");
                    }
                    else
                    {
                        Console.WriteLine($"You got it! The number is {num}.");
                    }
                    Console.WriteLine($"Your guesses so far: {GuessesToString(guesses)}\n");
                } while (guesses.Count < NUM_GUESSES && compare != 0);
            } while (PlayGameAgain());
        }

        public static string GuessesToString(List<int> guesses)
        {
            string result = string.Join(", ", guesses);
            return result;
        }

        /// <summary>
        /// This method returns a randomly chosen number between 1 and 100, inclusive.
        /// </summary>
        /// <returns></returns>
        public static int GetRandomNumber()
        {
            return randGen.Next(MIN_GUESS, MAX_GUESS);
        }

        /// <summary>
        /// This method gets input from the user, 
        /// verifies that the input is valid and 
        /// returns an int.
        /// </summary>
        /// <returns></returns>
        public static int GetUsersGuess()
        {
            int guess = -1;
            bool success;
            do
            {
                Console.Write($"Enter a guess between {MIN_GUESS}-{MAX_GUESS}: ");
                success = int.TryParse(Console.ReadLine(), out guess);
            } while (!success || guess < MIN_GUESS || guess > MAX_GUESS);
            return guess;
        }

        /// <summary>
        /// This method will has two int parameters.
        /// It will:
        /// 1) compare the first number to the second number
        /// 2) return -1 if the first number is less than the second number
        /// 3) return 0 if the numbers are equal
        /// 4) return 1 if the first number is greater than the second number
        /// </summary>
        /// <param name="randomNum"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static int CompareNums(int randomNum, int guess)
        {
            if (randomNum < guess)
            {
                return -1;
            }
            else if (randomNum == guess)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static bool PlayGameAgain()
        {
            string input;
            do
            {
                Console.Write("Would you like to play again (y/n)? ");
                input = Console.ReadLine();
            } while (input != "y" && input != "n");
            return input == "y";
        }
    }
}
