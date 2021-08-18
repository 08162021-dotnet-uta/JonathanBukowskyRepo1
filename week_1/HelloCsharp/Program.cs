using System;

namespace HelloCsharp
{
    class Program
    {
        // Build a simple calculator using 5 methods: Add, Multiply, Subtract, Divide, Print
        // (I'm going to add my own methods, GetCurrentValue() and SetCurrentValue())
        static void Main(string[] args)
        {
            string input = "";
            Console.WriteLine("Enter numbers and operands to perform a calculation (enter q to quit): ");
            int num = getNumber();
            Calculator calc = new Calculator(num);
            do
            {
                // Get input
                Console.Write("Enter an operator: ");
                input = Console.ReadLine().Trim();
                if (input != "q")
                {
                    num = getNumber();
                }

                // perform calculation
                switch (input)
                {
                    case "+":
                        calc.Add(num);
                        break;
                    case "-":
                        calc.Subtract(num);
                        break;
                    case "*":
                        calc.Multiply(num);
                        break;
                    case "/":
                        calc.Divide(num);
                        break;
                }
            } while (input != "q");
            calc.Print();
            //Console.WriteLine("Your calculated value: " + calc.GetValue());
        }

        static int getNumber()
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            return int.Parse(input);
        }
    }

    class Calculator
    {
        private int value;
        public Calculator()
        {
            this.value = 0;
        }

        public Calculator(int value)
        {
            this.value = value;
        }

        public Calculator Add(int x)
        {
            this.value += x;
            return this;
        }

        public Calculator Multiply(int x)
        {
            this.value *= x;
            return this;
        }

        public Calculator Divide(int x)
        {
            this.value /= x;
            return this;
        }

        public Calculator Subtract(int x)
        {
            this.value -= x;
            return this;
        }

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int x)
        {
            this.value = x;
        }

        public void Print()
        {
            Console.WriteLine("Computed Value: " + value);
        }
    }
}
