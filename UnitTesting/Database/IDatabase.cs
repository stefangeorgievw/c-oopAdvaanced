using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    interface IDatabase
    {
        int CurrentIndex { get; }

        void Add(int element);
    }
}
