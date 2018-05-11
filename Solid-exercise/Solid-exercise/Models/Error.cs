using Solid_exercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_exercise.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, ErrorLevel level)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }
        public DateTime DateTime { get; }

        public string Message { get; }

        public ErrorLevel Level { get; }
    }
}
