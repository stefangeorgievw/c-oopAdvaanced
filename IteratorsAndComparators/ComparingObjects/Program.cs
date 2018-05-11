using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        string command;
        List<Person> people = new List<Person>();
        while ((command = Console.ReadLine()) != "END")
        {
            var commandArgs = command.Split();
            string name = commandArgs[0];
            int age = int.Parse(commandArgs[1]);
            string town = commandArgs[2];
            people.Add(new Person(name, age, town));
        }

        int targetPersonNumber = int.Parse(Console.ReadLine());

        if (targetPersonNumber < 0 || targetPersonNumber >= people.Count)
        {
            Console.WriteLine("No matches");
            Environment.Exit(0);
        }

        var targetPerson = people[targetPersonNumber - 1];
        int equalPeopleCount = CountEqualPeople(targetPerson, people);
        if (equalPeopleCount > 1)
        {
            Console.WriteLine($"{equalPeopleCount} {people.Count - equalPeopleCount} {people.Count}");
        }
        


    }

    private static int CountEqualPeople(Person targetPerson, List<Person> people)
    {
        int count = 0;
        foreach (var person in people)
        {
            if (targetPerson.CompareTo(person) == 0)
            {
                count++;
            }
        }

        return count;
    }
}

