using System;
using System.Collections.Generic;

namespace _8_LoopsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Your code here */

        }

        /// <summary>
        /// Return the number of elements in the List<int> that are odd.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseFor(List<int> x)
        {
            int count = 0;
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i] % 2 == 1)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// This method counts the even entries from the provided List<object> 
        /// and returns the total number found.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForEach(List<object> x)
        {
            int count = 0;
            foreach(object o in x)
            {
                //System.Console.WriteLine($"val: {o} type: {o.GetType()}");
                //long? val = o as long?;
                long val;
                if (o is int)
                {
                    val = (long)(int)o;
                }
                else if (o is short)
                {
                    val = (long)(short)o;
                }
                else if (o is long)
                {
                    val = (long)o;
                }
                else
                {
                    continue;
                }
                //System.Console.WriteLine($"long val: {val}");
                if (val % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// This method counts the multiples of 4 from the provided List<int>. 
        /// Exit the loop when the integer 1234 is found.
        /// Return the total number of multiples of 4.
        /// </summary>
        /// <param name="x"></param>
        public static int UseWhile(List<int> x)
        {
            int count = 0;
            int idx = 0;
            int val;
            do
            {
                val = x[idx];
                if (val % 4 == 0)
                {
                    count++;
                }
            } while (++idx < x.Count && val != 1234);
            return count;
        }

        /// <summary>
        /// This method will evaluate the Int Array provided and return how many of its 
        /// values are multiples of 3 and 4.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForThreeFour(int[] x)
        {
            int count = 0;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 3 == 0 && x[i] % 4 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// This method takes an array of List<string>'s. 
        /// It concatenates all the strings, with a space between each, in the Lists and returns the resulting string.
        /// </summary>
        /// <param name="stringListArray"></param>
        /// <returns></returns>
        public static string LoopdyLoop(List<string>[] stringListArray)
        {
            string result = "";
            foreach (var strList in stringListArray)
            {
                foreach (var str in strList)
                {
                    /*
                    if (result == "")
                    {
                        result += str;
                    }
                    else
                    {
                        result += " " + str;
                    }
                    */
                    result += str + " ";
                }
            }
            return result;
        }
    }
}