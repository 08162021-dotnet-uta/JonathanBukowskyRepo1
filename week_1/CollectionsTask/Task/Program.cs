using System;
using System.Collections.Generic;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new()
            {
                new Person() { Name = "John Smith", Age = 21, PhoneNumber = "1418223363" },
                new Person() { Name = "Joe Smith", Age = 56, PhoneNumber = "1112823633" },
                new Person() { Name = "Joe Smith", Age = 57, PhoneNumber = "1112823633" },
                new Person() { Name = "Joe Smith", Age = 57, PhoneNumber = "1112823633" },
                new Person() { Name = "Joe Smith", Age = 57, PhoneNumber = "1112823634" },
                new Person() { Name = "Bob Smith", Age = 27, PhoneNumber = "1842683433" },
                new Person() { Name = "Judy Smith", Age = 39, PhoneNumber = "1862223383" },
                new Person() { Name = "Jane Doe", Age = 24, PhoneNumber = "2223334444" }
            };
            people.Sort();
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        class Person : IComparable<Person>
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string PhoneNumber { get; set; }

            public override string ToString()
            {
                return "Name: " + Name + ", Age: " + Age;// + ", #: " + PhoneNumber;
            }

            public int CompareTo(Person other)
            {
                if (other == null) return 1;
                if (Name.CompareTo(other.Name) == 0)
                {
                    if (Age.CompareTo(other.Age) == 0)
                    {
                        return PhoneNumber.CompareTo(other.PhoneNumber);
                    }
                    else
                    {
                        return Age.CompareTo(other.Age);
                    }
                }
                else
                {
                    return Name.CompareTo(other.Name);
                }
            }
        }
    }
}
