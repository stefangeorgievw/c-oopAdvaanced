using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseExtended
{
    public interface IPerson:IIdentifiable
    {
         string Username { get; }
    }
}
