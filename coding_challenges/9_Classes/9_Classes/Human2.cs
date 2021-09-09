using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human2
    {
        private string firstName = "Pat";
        private string lastName = "Smyth";
        private string eyeColor;
        private int age = -1;
        private int _weight;
        public int Weight
        {
            get => _weight;
            set
            {
                if (value >= 0 && value <= 400)
                {
                    _weight = value;
                }
                else
                {
                    _weight = 0;
                }
            }
        }
        internal Human2() { }
        internal Human2(string fn, string ln)
        {
            firstName = fn;
            lastName = ln;
        }
        internal Human2(string fn, string ln, string eColor, int a)
        {
            firstName = fn;
            lastName = ln;
            eyeColor = eColor;
            age = a;
        }
        internal Human2(string fn, string ln, int a)
        {
            firstName = fn;
            lastName = ln;
            age = a;
        }
        internal Human2(string fn, string ln, string eColor)
        {
            firstName = fn;
            lastName = ln;
            eyeColor = eColor;
        }

        internal string AboutMe()
        {
            return $"My name is {firstName} {lastName}.";
        }

        public string AboutMe2()
        {
            string result = $"My name is {firstName} {lastName}.";
            if (age != -1)
            {
                result += $" My age is {age}.";
            }
            if (eyeColor != null)
            {
                result += $" My eye color is {eyeColor}.";
            }
            return result;
            /*
            if (eyeColor == "" && age == -1)
            {
                return $"My name is {firstName} {lastName}.";
            }
            else if (eyeColor == "")
            {
                return $"My name is {firstName} {lastName}. My age is {age}.";
            }
            else if (age == -1)
            {
                return $"My name is {firstName} {lastName}. My eye color is {eyeColor}.";
            }
            else
            {
                return $"My name is {firstName} {lastName}. My age is {age}. My eye color is {eyeColor}.";
            }
            */
        }
    }
}