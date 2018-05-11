using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var box = new Box<double>();
        for (int i = 0; i < n; i++)
        {
            var input = double.Parse(Console.ReadLine());
            box.Add(input); 
        }

        var arg = double.Parse(Console.ReadLine());
        Console.WriteLine(box.Compare(box.data, arg));


        

    }
}

