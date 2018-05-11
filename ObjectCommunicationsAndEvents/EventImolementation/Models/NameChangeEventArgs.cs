﻿using System;
using System.Collections.Generic;
using System.Text;

public class NameChangeEventArgs : EventArgs
{
    public NameChangeEventArgs(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }
}
