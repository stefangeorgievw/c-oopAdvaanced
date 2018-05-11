using System;
using System.Linq;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
        var lake = new Lake(input);
        StringBuilder sb = new StringBuilder();
        foreach (var item in lake)
        {
            sb.Append(item + ", ");
        }
        sb.Remove(sb.Length - 2, 2);
        Console.WriteLine(sb.ToString().Trim());
    }
}

