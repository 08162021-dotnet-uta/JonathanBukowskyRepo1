﻿using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Add();
        }

        static void Add()
        {
            // input stuff
            int input1 = int.Parse(Console.ReadLine()); // type inference, parsing
            int input2 = int.Parse(Console.ReadLine());
            // compute stuff
            int compute = (int)input1 + (int)input2; // type inference, casting
            // output stuff
            Console.WriteLine(compute);
        }
    }
}
