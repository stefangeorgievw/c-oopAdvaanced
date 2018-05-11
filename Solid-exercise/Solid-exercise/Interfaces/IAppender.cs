using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_exercise.Interfaces
{
    public interface IAppender:ILevable
    {
        ILayout Layout { get; }


        void Append(IError error);


    }
}
