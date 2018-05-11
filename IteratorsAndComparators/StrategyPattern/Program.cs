using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        SortedSet<Person> sortedByName = new SortedSet<Person>(new PersonNameComparator());
        SortedSet<Person> sortedByAge = new SortedSet<Person>(new PersonAgeComparator());


        for (int i = 0; i < n; i++)
        {
            var inputArgs = Console.ReadLine().Split();
            sortedByName.Add(new Person(inputArgs[0], int.Parse(inputArgs[1])));
            sortedByAge.Add(new Person(inputArgs[0], int.Parse(inputArgs[1])));
        }

        foreach (var person in sortedByName)
        {
            Console.WriteLine(person);
        }

        foreach (var person in sortedByAge)
        {
            Console.WriteLine(person);
        }
    }
}

