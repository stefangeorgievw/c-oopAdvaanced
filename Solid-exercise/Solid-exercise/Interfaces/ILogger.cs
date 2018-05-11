﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_exercise.Interfaces
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }
        void Log(IError error);
    }
}
