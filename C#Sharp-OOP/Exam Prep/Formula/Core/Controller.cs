namespace Formula1.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Repositories.Contracts;
    using Models.Contracts;
    
    using Utilities;
    using Repositories;
    using Formula1.Models.FormulaOneCars;
    using Formula1.Models.Pilots;
    using Formula1.Models.Races;

    public class Controller : IController
    {
        private readonly IRepository<IPilot> pilotRepository;
        private readonly IRepository<IRace> raceRepository;
        private readonly IRepository<IFormulaOneCar> carRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.Models.FirstOrDefault(x => x.FullName == pilotName);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            else
            {
                IFormulaOneCar car = carRepository.Models.FirstOrDefault(x => x.Model == carModel);
                if (car == null)
                {
                    throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
                }
                pilot.AddCar(car);
                carRepository.Remove(car);
                return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
            }
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.Models.FirstOrDefault(x => x.RaceName == raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            IPilot pilot = pilotRepository.Models.FirstOrDefault(x => x.FullName == pilotFullName);
            if (pilot == null || pilot.CanRace == false || race.Pilots.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type == "Ferrari")
            {
                if (carRepository.Models.Any(c => c.Model == model))
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
                }
                IFormulaOneCar car = new Ferrari(model, horsepower, engineDisplacement);
                this.carRepository.Add(car);
                return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);

            }
            else if (type == "Williams")
            {
                if (carRepository.Models.Any(c => c.Model == model))
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
                }
                IFormulaOneCar car = new Williams(model, horsepower, engineDisplacement);
                this.carRepository.Add(car);
                return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.Any(p => p.FullName == fullName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.Models.Any(p => p.RaceName == raceName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            IRace race = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(race);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()//razlichno
        {
            List<IPilot> pilots = pilotRepository.Models.OrderByDescending(p => p.NumberOfWins).ToList();
            return String.Join(Environment.NewLine, pilots);
        }

        public string RaceReport()//razlichno tova e pipnatoo
        {
            var sb = new StringBuilder();
            List<IRace> list = raceRepository.Models.Where(r => r.TookPlace == true).ToList();
            foreach (var race in list)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.Models.FirstOrDefault(x => x.RaceName == raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
            List<IPilot> pilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList(); //FirstBug
            race.TookPlace = true;
            pilots[0].WinRace();
            var sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, pilots[0].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, pilots[1].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, pilots[2].FullName, raceName));
            return sb.ToString().Trim();
            //return $"Pilot {pilots[0].FullName} wins the {raceName} race." + Environment.NewLine +
            //$"Pilot {pilots[1].FullName} is second in the {raceName} race." + Environment.NewLine +
            //$"Pilot {pilots[2].FullName} is third in the {raceName} race.";

        }
    }
}