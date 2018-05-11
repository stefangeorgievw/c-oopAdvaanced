using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseExtended
{
    public class Database
    {
        private List<IPerson> people;

        public Database()
        {
            this.people = new List<IPerson>();
        }


        public Database(IEnumerable<IPerson> humans)
            : this()
        {
            this.AddingFromConstructor(humans);
        }

        public void AddingFromConstructor(IEnumerable<IPerson> humans)
        {
            if (humans == null)
            {
                throw new InvalidOperationException("People cannot be null!");
            }
           
                foreach (var person in humans)
                {
                    this.people.Add(person);
                }
            
        }

        public int Count => this.people.Count;

        public void Add(IPerson person)
        {
            if (this.people.Any(p=> p.Id == person.Id || p.Username == person.Username))
            {
                throw new InvalidOperationException("Person with this username or Id already exists!");
            }
            this.people.Add(person);

        }

        public void Remove(IPerson person)
        {
            var targetPerson = this.people.First(p => p.Id == person.Id || p.Username == person.Username);
            if (targetPerson == null)
            {
                throw new InvalidOperationException("There is no such person in the database!");
            }
            this.people.Remove(targetPerson);
        }

        public IPerson FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative!");
            }
            var person = this.people.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                throw new InvalidOperationException("There is no person with that Id in the database!");
            }

            return person;
        }

        public IPerson FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null!");
            }
            var person = this.people.FirstOrDefault(p => p.Username == username);
            if (person == null)
            {
                throw new InvalidOperationException("There is no such person with that username in the database");
            }
            return person;
        }


    }
}
