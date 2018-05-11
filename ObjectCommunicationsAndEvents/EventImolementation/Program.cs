using System;


public class Program
{
    static void Main(string[] args)
    {
        var dispatcher = new Dispatcher();
        var handler = new Handler();
        dispatcher.NameChange += handler.OnDispatcherNameChange;

        while (true)
        {
            var name = Console.ReadLine();
            if (name == "End") break;

            dispatcher.Name = name;
        }
    }
}

