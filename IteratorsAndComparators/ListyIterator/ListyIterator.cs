using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T>:IEnumerable<T>
{
    List<T> elements;
    int currentInternalIndex;

    public ListyIterator()
    {
        this.elements = new List<T>();
        currentInternalIndex = 0;
    }
    public ListyIterator(List<T> elements)
    {
        if (elements == null)
        {
            throw new ArgumentException("Elements cannot be null!");
        }
        this.elements = elements;
        currentInternalIndex = 0;
    }

    public bool Move()
    {
        if (this.currentInternalIndex < this.elements.Count - 1)
        {
            this.currentInternalIndex++;
            return true;
        }
        return false;
    }

    public void Print()
    {
        if (elements.Count == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }
        else
        {
            Console.WriteLine(elements[currentInternalIndex]);
        }
    }

    public bool HasNext()
    {
        return this.currentInternalIndex < this.elements.Count - 1;
    }

    public void PrintAll()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var element in this.elements)
        {
            sb.Append($"{element} ");
        }
        

        Console.WriteLine(sb.ToString().Trim());
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.elements.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

