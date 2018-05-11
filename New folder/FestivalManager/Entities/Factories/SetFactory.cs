using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;





namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            var Type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            
            ISet set = (ISet)Activator.CreateInstance(Type, name);

            return set;

		}
	}




}
