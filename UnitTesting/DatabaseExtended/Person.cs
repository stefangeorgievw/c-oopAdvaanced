using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseExtended
{
    public class Person : IPerson
    {
        public Person(string username, long id)
        {
            this.Username = username;
            this.Id = id;
        }
        public string Username { get; private set; }

        public long Id { get; private set; }
    }
}
