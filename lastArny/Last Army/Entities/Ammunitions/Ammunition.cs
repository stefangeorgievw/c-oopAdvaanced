using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Ammunition : IAmmunition
{


    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
    }

    public string Name  {get;}

    public double Weight { get; }

    public double WearLevel => this.Weight * 100;

    public void DecreaseWearLevel(double wearAmount)
    {
        throw new NotImplementedException();
    }
}

