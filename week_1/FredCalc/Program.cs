// Topics Discussed

// Type Inference (var)
// Parsing
// Casting (implicit, explicit)
// Scopes (namespace, class, method, block)
// Single Responsibility (part of SOLID)
// DRY (don't repeat yourself)
// Method (signature, parameter, argument)
// Primitive Types (int, bool, string, float, double)
// Type Families (value, reference)

using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = Input();
            var input1 = inputs[0];
            var input2 = inputs[1];

            // compute stuff
            int result1 = Add(input1, input2);
            int result2 = Subtract(input1, input2);
            int result3 = Multiply(input1, input2);
            int result4 = Divide(input1, input2);

            // output stuff
            Print(result1, result2, result3, result4);
        }

        static int Add(int input1, int input2)
        {
            // compute stuff
            var compute = input1 + input2; // type inference, casting
            return compute;
        }

        static int Subtract(int input1, int input2)
        {
            // compute stuff
            var compute = input1 - input2; // type inference, casting
            return compute;
        }
        static int Multiply(int input1, int input2)
        {
            // compute stuff
            var compute = input1 * input2; // type inference, casting
            return compute;
        }
        static int Divide(int input1, int input2)
        {
            // compute stuff
            var compute = input1 / input2; // type inference, casting
            return compute;
        }

        static void Print(params int[] results)
        {
            // output stuff
            foreach (int result in results)
            {
                Console.WriteLine(result);
            }
        }

        static int[] Input()
        {
            int input1, input2;
            try
            {
                // input stuff
                input1 = int.Parse(Console.ReadLine()); //123a, 123 // type inference, parsing
                input2 = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                //throw ex; // throw original exception object -- DO NOT USE (replaces stack trace of ex with current stack trace info)
                throw new Exception("we are sorry for the inconvenience", ex); // throw new exception object -- USE (keeps reference to original stack trace info)
            }
            finally
            {

            }
            //int[] result = new int[2];
            //result[0] = input1;
            //result[1] = input2;
            return new int[] { input1, input2 };
        }
    }
}
