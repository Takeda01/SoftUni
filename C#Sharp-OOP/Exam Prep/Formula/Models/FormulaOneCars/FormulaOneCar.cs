using Formula1.Models.Contracts;
using System;


namespace Formula1Car
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double enginedisplacement;

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;

        }

        public string Model
        {
            get => this.model;
           private set
            {
                if( string.IsNullOrWhiteSpace(value) || value.Length < 3 ) 
                {
                    throw new ArgumentException($"Invalid car model: {value}.");

                }
                this.model = value;
            }
        }

        public int Horsepower
        {
            get => this.horsepower;
           private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException($"Invalid car horsepower: {value}.");
                }
                this.horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get => this.enginedisplacement;
           private set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException($"Invalid car engine displacement: {value}.");
                }
                this.enginedisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            double score = this.EngineDisplacement / this.Horsepower * laps;
            return score;
        }
    }
}
