using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Lake : IEnumerable<int>
{
    List<int> data;

    public Lake(List<int> elements)
    {
        this.data = elements;
    }
    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i <= this.data.Count - 1; i+=2)
        {
            yield return this.data[i];
        }
        if (this.data.Count % 2 == 0)
        {
            for (int i = this.data.Count - 1; i >= 0; i-=2)
            {
                yield return this.data[i];
            }
        }
        else
        {
            for (int i = this.data.Count - 2; i >= 0; i-=2)
            {
                yield return this.data[i];
            }
        }
        
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

