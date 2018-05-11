using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core.Commands
{
    public abstract class  Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            set { unitFactory = value; }
        }


        protected IRepository Repository
        {
            get { return repository; }
           private set { repository = value; }
        }


        protected string[] Data
        {
            get { return data; }
            private set { data = value; }
        }

        public abstract string Execute();
        
    }
}
