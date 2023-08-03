using Formula1.Models.Contracts;
using Formula1.Models.Races;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> races;
        public RaceRepository()
        {
            races = new List<IRace>();  
        }
        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)this.races;
    
        public void Add(IRace model)
        {
          this.races.Add(model);
        }

        public IRace FindByName(string name)
        {
            foreach (var race in this.races)
            {
                if (race.RaceName == name)
                {
                   
                    return race;
                }

            }

            return null;
        }

        public bool Remove(IRace model)
        {
            if (this.races.Contains(model))
            {
                this.races.Remove(model);
                return true;
            }
            return false;
        }
    }
}
