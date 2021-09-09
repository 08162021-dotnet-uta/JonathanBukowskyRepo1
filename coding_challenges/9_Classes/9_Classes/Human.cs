using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human
    {
        private string firstName = "Pat";
        private string lastName = "Smyth";
        internal Human() { }
        internal Human(string fName, string lName)
        {
            firstName = fName;
            lastName = lName;
        }

        internal string AboutMe()
        {
            return $"My name is {firstName} {lastName}.";
        }
    }//end of class
}//end of namespace