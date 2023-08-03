using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> cars;
        public FormulaOneCarRepository()
        {
            cars = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)this.cars;
       
        public void Add(IFormulaOneCar model)
        {
            var existing = cars.FirstOrDefault(c => c.Model == model.Model);
            if (existing.Model == model.Model)
            {
                throw new ArgumentException($"Formula one car {model.Model} is already created.");

            }
         this.cars.Add(model);  
        }

       

        public IFormulaOneCar FindByName(string name)
        {
            foreach (var caro in this.cars)
            {
                if (caro.Model == name)
                {
                   
                    return caro;
                }
               
            }
         
            return null;
        }

        public bool Remove(IFormulaOneCar model)
        {
            if (this.cars.Contains(model))
            { 
                this.cars.Remove(model);
                return true;
            }
            return false;
        }

    

        
       
    }
}
