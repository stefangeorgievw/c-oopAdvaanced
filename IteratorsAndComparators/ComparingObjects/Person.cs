using System;
using System.Collections.Generic;
using System.Text;

public class Person : IComparable<Person>
{
    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }
    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Town { get; private set; }

    public int CompareTo(Person other)
    {
        var comparison = this.Name.CompareTo(other.Name);
        if (comparison != 0)
        {
            return comparison;
        }

        comparison = this.Age.CompareTo(other.Age);
        if (comparison != 0)
        {
            return comparison;
        }

        return this.Town.CompareTo(other.Town);
    }
}

