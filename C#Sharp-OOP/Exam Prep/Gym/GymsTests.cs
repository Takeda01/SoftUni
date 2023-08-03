using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void Name_Throws_Exception_If_Is_Null_Or_Empty(string name)
        {
            Assert.That(() =>
            {
                Gym gym = new Gym(name, 10);
            },
            Throws.Exception.TypeOf<ArgumentNullException>());  
        
        }

        [Test]
        public void Capacity_Is_Invalid_Below_Zero()
        {
            Assert.That(() =>
            {
                Gym gym = new Gym("Zona", -2);
            },
            Throws.Exception.TypeOf<ArgumentException>());
        }
        [Test]
        public void Cannot_Add_Athlete_If_TheGym_Is_Full()
        {
            Assert.That(() =>
            {
                Athlete athlete = new Athlete("John");
                Athlete athlet2 = new Athlete("Robert");
                Gym gym = new Gym("Zona", 1);
                gym.AddAthlete(athlete);
                gym.AddAthlete(athlet2);
            },
            Throws.Exception.TypeOf<InvalidOperationException>());  
        }
        [Test]
        public void Cannot_Remove_Unexisting_Athlete()
        {
            Assert.That(() =>
            {
                Athlete athlete = new Athlete("John");
                Athlete athlet2 = new Athlete("Robert");
                Gym gym = new Gym("Zona", 1);
                gym.AddAthlete(athlet2);
                gym.RemoveAthlete("John");

            },
            Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void Injure_Works_If_The_Athlethe_Exists()
        {
            Athlete athlete = new Athlete("John");
            Athlete athlet2 = new Athlete("Robert");
            Gym gym = new Gym("Zona", 1);
            gym.AddAthlete(athlet2);
            Assert.That(() =>
            {
              
                gym.InjureAthlete("John");

            },
            Throws.Exception.TypeOf<InvalidOperationException>());
            gym.InjureAthlete("Robert");
            Assert.AreEqual(athlet2.IsInjured, true);
        }
           
        [Test]
        public void Report_Works()
        {
            Gym gym = new Gym("Zona", 5);
            Athlete athlete = new Athlete("John");
            Athlete athlet2 = new Athlete("Robert");
        
                gym.AddAthlete(athlete);
                gym.AddAthlete(athlet2);
            Assert.AreEqual(gym.Report(), $"Active athletes at {gym.Name}: John, Robert");
            

        }
        [Test]
        public void Ctor_Works_Like_The_People()
        {
            Assert.That(() =>
            {
                Gym gym = new Gym("Zona", 5);
            },
            Throws.Nothing);
          
        }
        [Test]
        public void Gettters_Return_Values()
        {
            Gym gym = new Gym("Zona", 5);
            Assert.AreEqual(gym.Name, "Zona");
            Assert.AreEqual(gym.Capacity, 5);
        }
        [Test]
        public void The_Counter_Counts_Like_The_People()
        {
            Gym gym = new Gym("Zona", 5);
            Athlete athlete = new Athlete("John");
            Athlete athlet2 = new Athlete("Robert");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlet2);
            Assert.AreEqual(gym.Count, 2);  
        }
        [Test]
        public void Remove_Actually_Removes_From_The_Collection()
        {

            Gym gym = new Gym("Zona", 5);
            Athlete athlete = new Athlete("John");
            Athlete athlet2 = new Athlete("Robert");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlet2);
            gym.RemoveAthlete("John");

            Assert.That(() =>
                {
                gym.InjureAthlete("John");
            },
       Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void Injure_Method_Returns_My_Athlete()
        {
            Gym gym = new Gym("Zona", 5);
            Athlete athlete = new Athlete("John");
            Athlete athlet2 = new Athlete("Robert");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlet2);

            Assert.AreEqual(athlete, gym.InjureAthlete("John"));
        }
    }
}
