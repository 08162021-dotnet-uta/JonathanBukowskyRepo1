using System;
using System.Collections;
using System.Collections.Generic;

namespace _11_ArraysAndListsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {

            ArrayList arr = new ArrayList() { "hi", 1, 2.5, 10.0, 2, "bye" };
            Console.WriteLine($"Avg of values: {ArrayListAvg(arr)}");
        }//EoM

        /// <summary>
        /// This method takes an array of integers and returns a double, the average 
        /// value of all the integers in the array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static double AverageOfValues(int[] array)
        {
            double avg = 0;
            foreach (int i in array)
            {
                avg += i;
            }
            avg /= array.Length;
            return avg;
        }

        /// <summary>
        /// This method increases each array element by 2 and 
        /// returns an array with the altered values.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int[] SunIsShining(int[] x)
        {
            int[] growth = new int[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                growth[i] = x[i] + 2;
            }
            return growth;
        }

        /// <summary>
        /// This method takes an ArrayList containing types of double, int, and string 
        /// and returns the average of the ints and doubles only, as a decimal.
        /// It ignores the string values and rounds the result to 3 decimal places toward the nearest even number.
        /// </summary>
        /// <param name="myArrayList"></param>
        /// <returns></returns>
        public static decimal ArrayListAvg(ArrayList myArrayList)
        {
            decimal avg = 0;
            int count = 0;
            foreach (object o in myArrayList)
            {
                if (o.GetType() == typeof(int))
                {
                    avg += (int)o;
                    count++;
                }
                else if (o.GetType() == typeof(double))
                {
                    avg += (decimal)(double)o;
                    count++;
                }
            }
            return Math.Round((avg / count), 3);
        }

        /// <summary>
        /// This method returns the rank (starting with 1st place) of a new 
        /// score entered into a list of randomly ordered scores.
        /// </summary>
        /// <param name="myArray1"></param>
        public static int ListAscendingOrder(List<int> scores, int yourScore)
        {
            scores.Sort();
            int i;
            for (i = 0; i < scores.Count; i++)
            {
                if (yourScore <= scores[i])
                {
                    break;
                }
            }
            return ++i;
        }

        /// <summary>
        /// This method has with two parameters takes a List<string> and a string.
        /// The method returns true if the string parameter is found in the List, otherwise false.
        /// </summary>
        /// <param name="myArray2"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool FindStringInList(List<string> myArray2, string word)
        {
            return myArray2.Exists((string s) => s == word);
        }
    }//EoP
}// EoN