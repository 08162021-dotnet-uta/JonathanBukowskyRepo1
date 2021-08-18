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
            Add(input1, input2);
            Subtract(input1, input2);

            // output stuff
            Console.WriteLine(compute);
        }

        static void Add(int input1, int input2)
        {
            // compute stuff
            int compute = (int)input1 + (int)input2; // type inference, casting
        }
        static void Subtract(int input1, int input2)
        {
            // compute stuff
            int compute = (int)input1 - (int)input2; // type inference, casting
        }
    }
}
