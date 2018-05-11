﻿using System;
using System.Linq;

[Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public class Program
{
    static void Main(string[] args)
    {
        var attr = (InfoAttribute)typeof(Program).GetCustomAttributes(false).First();

        var command = Console.ReadLine();

        while (command != "END")
        {
            switch (command)
            {
                case "Author":
                    Console.WriteLine($"Author: {attr.Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: {attr.Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {attr.Description}");
                    break;
                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ", attr.Reviewers)}");
                    break;
                default:
                    break;
            }

            command = Console.ReadLine();
        }
    }
}

