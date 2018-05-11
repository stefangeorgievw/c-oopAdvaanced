using Solid_exercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Solid_exercise.Models.Factories
{
    public class ErrorFactory
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTimeString, string errorLevelString, string message)
        {
            DateTime dateTime = DateTime.ParseExact(dateTimeString, DateFormat, CultureInfo.InvariantCulture);

            ErrorLevel errorLevel = ParseErrorLevel(errorLevelString);

            IError error = new Error(dateTime, message, errorLevel);

            return error;
        }

        private ErrorLevel ParseErrorLevel(string levelString)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException e)
            {

                throw new ArgumentException("Invalid ErrorLevel Type!", e);
            }
        }
    }
}
