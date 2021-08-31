using System;

namespace _4_MethodsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1
            string name = GetName();
            GreetFriend(name);

            //2
            double result1 = GetNumber();
            double result2 = GetNumber();
            int action1 = GetAction();
            double result3 = DoAction(result1, result2, action1);

            System.Console.WriteLine($"The result of your mathematical operation is {result3}.");
        }

        public static string GetName()
        {
            System.Console.Write("Please enter your name: ");
            string name = System.Console.ReadLine();
            return name.Trim();
        }

        public static string GreetFriend(string name)
        {
            return $"Hello, {name}. You are my friend.";
        }

        public static double GetNumber()
        {
            System.Console.Write("Please enter a number: ");
            var input = Console.ReadLine();
            double d;
            while (!double.TryParse(input, out d))
            {
                Console.WriteLine("Invalid input. Please try again.");
                System.Console.Write("Please enter a number: ");
                input = Console.ReadLine();
            }
            return d;
        }

        public static int GetAction()
        {
            Console.WriteLine("Please enter an operation: 1 - add, 2 - subtract, 3 - multiply, 4 - divide");
            Console.Write("Make a selection: ");
            var input = Console.ReadLine();
            int choice;
            while (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid choice.");
                Console.WriteLine("Please enter an operation: 1 - add, 2 - subtract, 3 - multiply, 4 - divide");
                Console.Write("Make a selection: ");
                input = Console.ReadLine();
            }
            return choice;
        }

        public static double DoAction(double x, double y, int action)
        {
            double result;
            switch (action)
            {
                case 1:
                    result = x + y;
                    break;
                case 2:
                    result = Math.Max(x, y) - Math.Min(x, y);
                    break;
                case 3:
                    result = x * y;
                    break;
                case 4:
                    result = Math.Max(x, y) / Math.Min(x, y);
                    break;
                default:
                    throw new FormatException("Invalid action");
            }
            Console.WriteLine($"Result: {result}");
            return result;
        }
    }
}
