namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage:IStage
	{
		
		public readonly List<ISet> sets;
		public readonly List<ISong> songs;
		public readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

       public  IReadOnlyCollection<ISet> Sets => this.sets;


        public IReadOnlyCollection<ISong> Songs => this.songs;


        public IReadOnlyCollection<IPerformer> Performers => this.performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            return this.Performers.FirstOrDefault(p => p.Name == name);
        }

        public ISet GetSet(string name)
        {
            return this.Sets.FirstOrDefault(s => s.Name == name);
        }

        public ISong GetSong(string name)
        {
            return this.Songs.FirstOrDefault(s => s.Name == name);
        }

        public bool HasPerformer(string name)
        {
            bool IsAnyPerformer = this.Performers.Any(p=> p.Name == name);
            return IsAnyPerformer;
        }

        public bool HasSet(string name)
        {
            bool IsAnySet = this.Sets.Any(s => s.Name == name);
            return IsAnySet;
        }

        public bool HasSong(string name)
        {
            bool IsAnySong = this.Songs.Any(s => s.Name == name);
            return IsAnySong;
        }
    }
}
