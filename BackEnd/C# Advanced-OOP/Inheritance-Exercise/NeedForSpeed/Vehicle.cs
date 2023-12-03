using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        private int horsePower;
        private double fuel;
       

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }
        public virtual double FuelConsumption
        {
            get => DefaultFuelConsumption;
        }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }

    }
}
