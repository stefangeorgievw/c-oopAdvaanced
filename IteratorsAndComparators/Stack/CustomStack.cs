using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomStack<T> : IEnumerable<T>
{
    List<T> data;

    public CustomStack()
    {
        this.data = new List<T>();
    }

    public void Push(T element)
    {
        this.data.Add(element);
    }

    public T Pop()
    {
        if (this.data.Count == 0)
        {
            throw new ArgumentException("No elements");
        }
        var result = this.data.Last();
        this.data.Remove(result);
        return result;
        
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.data.Count - 1; i >= 0; i--)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

