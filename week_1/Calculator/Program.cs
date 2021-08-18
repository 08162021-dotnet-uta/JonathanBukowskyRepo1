using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // input stuff
            int input1 = int.Parse(Console.ReadLine()); // type inference, parsing
            int input2 = int.Parse(Console.ReadLine());
            var result1 = Add(input1, input2);
            var result2 = Subtract(input1, input2);
            var result3 = Multiply(input1, input2);
            var result4 = Divide(input1, input2);

            // output stuff
            Print(result1, result2, result3, result4);
        }

        static int Add(int input1, int input2)
        {
            // compute stuff
            int compute = input1 + input2; // type inference, casting
            return compute;
        }
        static int Subtract(int input1, int input2)
        {
            // compute stuff
            int compute = input1 - input2; // type inference, casting
            return compute;
        }

        static int Multiply(int input1, int input2)
        {
            int compute = input1 * input2;
            return compute;
        }

        static void Print(params int[] results)
        {
            //output stuff
            foreach (int result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
