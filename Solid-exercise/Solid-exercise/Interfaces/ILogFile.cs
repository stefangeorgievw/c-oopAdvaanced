using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_exercise.Interfaces
{
    public interface ILogFile
    {
        string Path { get; }

        int Size { get; }

        void WriteToFile(string errorLog);
    }
}
