namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IStage stage;
        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISongFactory songFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.setFactory = new SetFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.songFactory = new SongFactory();
        }
        //TimeFormat
        public string ProduceReport()
        {
            var result = string.Empty;

            TimeSpan totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
            var a = totalFestivalLength.TotalSeconds - (totalFestivalLength.TotalMinutes * 60);
            var b = a.ToString("D2");
            result += ($"Festival length: {totalFestivalLength.TotalMinutes.ToString("D2")}:"+ b + "\n");


            foreach (var set in this.stage.Sets)
			{
				result += ($"--{set.Name} ({set.ActualDuration:mm\\:ss}):") + "\n";

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
					}
				}
			}

			return result.ToString();
		}

		public string RegisterSet(string[] args)
		{

            var set = this.setFactory.CreateSet(args[0], args[1]);
            if (set == null)
            {
                new ArgumentException("Set cannot be null");
            }
            this.stage.AddSet(set);

            return $"Registered {args[1]} set";

		}

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var instruments  = args.Skip(2).ToArray();

			var instrumenti2 = instruments
                .Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			var performer = this.performerFactory.CreatePerformer(name, age);
            if (instruments != null)
            {
                foreach (var instrument in instrumenti2)
			{
				performer.AddInstrument(instrument);
			}
            }
			

			this.stage.AddPerformer(performer);
            

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            string name = args[0];
            var duraction = DateTime.ParseExact(args[1], "mm:ss", CultureInfo.InvariantCulture).TimeOfDay;
            var song = this.songFactory.CreateSong(name, duraction);
            this.stage.AddSong(song);

			return $"Registered song {song}";
		}

		public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

			return $"Added {song.Name} ({song.Duration:mm\\:ss}) to {set.Name}";
		}

		// Временно!!! Чтобы работало делаем срез на конец месяца
		public string AddPerformerToSet(string[] args)
		{
			return PerformerRegistration(args);
		}

		public string PerformerRegistration(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException("Invalid performer provided");
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}


			var performer = this.stage.GetPerformer(performerName);
			var set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

			return $"Added {performer.Name} to {set.Name}";
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}

       

        
    }
}