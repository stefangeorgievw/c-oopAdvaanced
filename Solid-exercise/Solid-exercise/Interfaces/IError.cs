using System;

namespace Solid_exercise.Interfaces
{
    public interface IError : ILevable
    {
        DateTime DateTime { get; }

        string Message { get; }

        
    }
}