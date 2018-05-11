using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Box<T>
{
    List<T> elements;

    public Box()
    {
        elements = new List<T>();
    }

    public void Add(T item)
    {
        elements.Add(item);
    }

   public  int Count => this.elements.Count;

    public T Remove()
    {
        var element = elements.Last();
        elements.Remove(element);
        return element;
    }


}

