
using System;
using System.Linq;
namespace FestivalManager.Core
{
   
    using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using IO.Contracts;

	/// <summary>
	/// by g0shk0
	/// </summary>
	class Engine : IEngine
	{
	    public IReader reader;
	    public IWriter writter;
        public Engine( IFestivalController festival ,ISetController set, IReader reader, IWriter writter )
        {
            this.reader = reader;
            this.writter = writter;
            this.FestivalCоntroller = festival;
            this.SetCоntroller = set;
        }

		public IFestivalController FestivalCоntroller { get; private set; }
		public ISetController SetCоntroller  { get; private set; }

   
    public void Run()
		{
			while (true)
			{
				var input = reader.ReadLine();

				if (input == "END")
					break;
                
				try
				{
					string.Intern(input);

					var result = this.ProcessCommand(input);
					this.writter.WriteLine(result);
				}
				catch (Exception ex) // in case we run out of memory
				{
					this.writter.WriteLine("ERROR: " + ex.Message);
				}
			}

            var end = this.FestivalCоntroller.ProduceReport();

			this.writter.WriteLine("Results:");
			this.writter.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var args = input.Split(" ");

			var first = args.First();
			var parameters = args.Skip(1).ToArray();

			if (first == "LetsRock")
			{
                var sets = this.SetCоntroller.PerformSets();
				return sets;
			}

			var festivalcontrolfunction = this.FestivalCоntroller.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == first);

			string a;

			try
			{
				a = (string)festivalcontrolfunction.Invoke(this.FestivalCоntroller, new object[] { parameters });
			}
			catch (TargetInvocationException up)
			{
				throw up.InnerException; // ha ha
			}

			return a;
		}

      
    }
}