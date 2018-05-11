using System;
using System.Collections.Generic;
using System.Text;

public class RoyalGuard : Soldier
{
    public RoyalGuard(string name)
        : base(name)
    {
    }

    public override void KingUnderAttack()
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}