using System;

namespace _9_ClassesChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human h1 = new Human();
            Human h2 = new Human("Bob", "Dylan");
            Console.WriteLine(h1.AboutMe());
            Console.WriteLine(h2.AboutMe());
            Human2 h3 = new Human2("Johnny", "Bravo", "Blue");
            Human2 h4 = new Human2("Dick", "Butkus", 25);
            Human2 h5 = new Human2("Dave", "Chapelle", "Brown", 48);
            Console.WriteLine(h3.AboutMe2());
            Console.WriteLine(h4.AboutMe2());
            Console.WriteLine(h5.AboutMe2());
            Human2 h6 = new Human2("Bruce", "Willis", "Blue", 92);
            Console.WriteLine($"Before set: {h6.Weight}");
            h6.Weight = 20;
            Console.WriteLine($"After set 20: {h6.Weight}");
            h6.Weight = -10;
            Console.WriteLine($"After set -10: {h6.Weight}");
            h6.Weight = 20;
            Console.WriteLine($"After set 20: {h6.Weight}");
            h6.Weight = 401;
            Console.WriteLine($"After set 401: {h6.Weight}");
        }
    }
}
