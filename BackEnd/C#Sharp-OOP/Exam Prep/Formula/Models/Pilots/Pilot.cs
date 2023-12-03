using Formula1.Models.Contracts;


using System;



namespace Formula1.Models.Pilots
{
    public class Pilot : IPilot
    {
        private string fullname;
        private bool canrace = false;
        private IFormulaOneCar car;
        public Pilot(string fullName)
        {
            this.FullName = fullName;
        }
        public string FullName
        {
            get => this.fullname;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }
                this.fullname = value;
            }
        }

        public IFormulaOneCar Car 
            {
            get => this.car;    
           private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot car can not be null.");
                }
                this.car = value;
            }
            }

        public int NumberOfWins { get; set; }
        

        public bool CanRace
        {
            get => this.canrace;
          private  set
            {
                this.canrace = value;
            }
        }
            
       

        public void AddCar(IFormulaOneCar car)
        {
          this.Car = car;
          this.CanRace = true;

        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot { this.FullName } has { this.NumberOfWins } wins.";
        }
    }
}
