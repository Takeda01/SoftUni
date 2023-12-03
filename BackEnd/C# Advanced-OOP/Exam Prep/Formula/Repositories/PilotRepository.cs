using Formula1.Models.Contracts;
using Formula1.Models.Pilots;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        


        private ICollection<IPilot> models;
        public PilotRepository()
        {
            models = new List<IPilot>();    
        }
        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)this.models;


        public void Add(IPilot model)
        {
           this.models.Add(model);
        }

       

        public IPilot FindByName(string name)
        {
            foreach (var pilot in this.models)
            {
                if (pilot.FullName == name)
                {
                    
                    return pilot;
                }

            }

            return null;
        }

        public bool Remove(IPilot model)
        {
            if (this.models.Contains(model))
            {
               
                this.models.Remove(model);
                return true;
            }
            return false;
        }

      

      
    }


}
