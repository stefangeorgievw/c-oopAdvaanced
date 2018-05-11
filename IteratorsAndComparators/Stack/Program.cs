using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        string command;
        CustomStack<int> stack = new CustomStack<int>();
        while ((command = Console.ReadLine()) != "END")
        {
            var commandArgs = command.Split(new string[] { ", "," " },StringSplitOptions.RemoveEmptyEntries).ToList();

            switch (commandArgs[0])
            {
                case "Pop":
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "Push":
                    commandArgs.RemoveAt(0);
                    var arggs = commandArgs.Select(int.Parse).ToList();
                    foreach (var element in arggs)
                    {
                        stack.Push(element);
                    }
                    
                    break;
                default:
                    break;
            }
        }
        if (stack.Any())
        {

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

