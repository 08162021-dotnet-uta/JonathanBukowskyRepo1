﻿using System;

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

            // output stuff
            Print();
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

        static void Print()
        {
            //output stuff
            Console.WriteLine(input1, input2);
        }
    }
}
