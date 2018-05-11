using System;
using System.Collections.Generic;
using System.Text;

public class Footman : Soldier
{
    public Footman(string name)
        : base(name)
    {
    }

    public override void KingUnderAttack()
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}
