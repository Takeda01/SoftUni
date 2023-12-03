using Formula1.Models.Contracts;

using System;
using System.Collections.Generic;

namespace Formula1.Models.Races
{
    public class Race:IRace
    {
        private string racename;
        private int numberoflaps;
        private bool takeplace = false;
        private ICollection<IPilot> pilots;

        public ICollection<IPilot> Pilots => this.pilots;

        public Race(string raceName, int numberOfLaps)
        {
          this.RaceName = raceName;
          this.NumberOfLaps = numberOfLaps;
          pilots = new List<IPilot>();    

        }
        public string RaceName
        {
            get => this.racename;
           private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }
                this.racename = value;
            }
        }
        public bool TookPlace
        {
            get => this.takeplace;
              set
              {
                this.takeplace = value;
              }
        } 
        public int NumberOfLaps
        {
            get => this.numberoflaps;
           private  set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }
                this.numberoflaps = value;
            }
        }





    

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string n = "No";
            if (TookPlace == true)
            {
                n = "Yes";
            }

            return $"The {this.RaceName } race has:" + Environment.NewLine +
           $"Participants: {this.Pilots.Count}" + Environment.NewLine +
           $"Number of laps: { this.NumberOfLaps}" + Environment.NewLine +
           $"Took place: {n}";

        }
    }
}
