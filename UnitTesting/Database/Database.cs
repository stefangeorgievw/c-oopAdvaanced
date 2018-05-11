using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Database
{
    public class Database:IDatabase
    {
        private int[] data;
        

        
        private Database()
        {
            this.data = new int[16];
            this.CurrentIndex = default(int);
        }

        public Database(params int[] integers)
            :this()
        {            
            AddingFromConstructor(integers);
        }

        public int CurrentIndex { get; private set; }

        public void AddingFromConstructor(int[] elements)
        {
            if (elements.Length > 16)
            {
                throw new InvalidOperationException("Array cannot contain more than 16 integers!");
            }
            
                foreach (var element in elements)
                {
                    this.data[CurrentIndex] = element;
                    CurrentIndex++;
                }

        }

        public void Add(int element)
        {
            if (CurrentIndex >= 16)
            {
                throw new InvalidOperationException("Array cannot contain more than 16 integers!");
            }

            this.data[CurrentIndex] = element;
        }

        public int Remove()
        {
            if (CurrentIndex == 0)
            {
                throw new InvalidOperationException("There is no elements int the database!");
            }

            int result = this.data[this.CurrentIndex -1 ];
            this.data[this.CurrentIndex] = default(int);
            this.CurrentIndex--;
            return result;
        }

        public int[] Fetch()
        {
            if (CurrentIndex == 0)
            {
                throw new InvalidOperationException("There is no elements int the database!");
            }

            int[] elementsArray = new int[CurrentIndex];
            Array.Copy(this.data, elementsArray, CurrentIndex);
            return elementsArray;
        }
    }
}
