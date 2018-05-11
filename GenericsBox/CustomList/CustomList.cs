using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CustomList<T>
    where T : IComparable<T>
{
    private List<T> items;

    public CustomList()
    {
        this.items = new List<T>();
    }

    public void Add(T element)
    {
        this.items.Add(element);
    }

    public T Remove(int index)
    {
        T result = this.items[index];
        this.items.RemoveAt(index);
        return result;
    }

    public bool Contains(T element)
    {
        bool result = false;
        if (this.items.Contains(element))
        {
            result = true;
        }

        return result;
    }

    public void Swap(int index1, int index2)
    {
        var temp = this.items[index1];
        this.items[index1] = this.items[index2];
        this.items[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        var counter = 0;
        foreach (var item in this.items)
        {
            if (item.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        return this.items.Max();
    }

    public T Min()
    {
        return this.items.Min();
    }

    public void Print()
    {
        string result = string.Join(Environment.NewLine, this.items);
        Console.WriteLine(result);
    }

    public void Sort()
    {
       this.items = this.items.OrderBy(x => x).ToList();
    }

    
}

