using FestivalManager.Constants;
using FestivalManager.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FestivalManager.Entities.Sets
{
    public abstract class Set : ISet
    {
        private readonly List<IPerformer> performers;
        private readonly List<ISong> songs;
      

        public string Name { get; private set; }

        public Set(string name, TimeSpan maxDuraction)
        {
            this.Name = name;
            this.MaxDuration = maxDuraction;
            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public TimeSpan MaxDuration { get; private set; }

        public TimeSpan ActualDuration => new TimeSpan(this.songs.Sum(s => s.Duration.Ticks));

        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public IReadOnlyCollection<ISong> Songs => this.songs;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            if (song.Duration + ActualDuration > MaxDuration)
            {
                throw new InvalidOperationException(Costants.SongOverTheLimit);
            }

            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            if (!this.Performers.Any())
            {
                return false;
            }

            if (!this.Songs.Any())
            {
                return false;
            }

            var allPerformersHaveInstruments = this.Performers.All(p => p.Instruments.Any());

            if (!allPerformersHaveInstruments)
            {
                return false;
            }

            var allPerformersHaveFunctioningInstruments = this.performers.All(p => p.Instruments.Any(i => !i.IsBroken));

            if (!allPerformersHaveFunctioningInstruments)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(string.Join(", ", this.Performers));

            foreach (var song in this.Songs)
            {
                sb.AppendLine($"-- {song}");
            }

            var result = sb.ToString();
            return result;
        }
    }
}
