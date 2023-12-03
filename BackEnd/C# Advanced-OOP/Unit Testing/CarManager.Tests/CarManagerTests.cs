namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Without_Refuel_Car_Fuel_Is_Set_Zero()
        {
            var car = new Car("Reihn", "A8", 5.6, 21.1);
            Assert.AreEqual(0, car.FuelAmount);
        }
       
        [Test]
        public void First_Ctor_Works()
        {
            var car = new Car("Reihn","A8",5.6,21.1);
            
        }
        [Test]
        public void If_Make_IsNullOrEmpty_Exeption_Is_Thrown()
        {
            Assert.That(() =>
            {
                var car = new Car("", "A8", 5.6, 21.1);
            },

            Throws.Exception.TypeOf<ArgumentException>());
           
        }
        [Test]
        public void Make_Getter_Returns_Right()
        {
            var car = new Car("Reihn", "A8", 5.6, 21.1);
            Assert.AreEqual("Reihn", car.Make);
        }

        [Test]
        public void If_Model_IsNullOrEmpty_Exeption_Is_Thrown()
        {
            Assert.That(() =>
            {
                var car = new Car("Reihn", "", 5.6, 21.1);
            },

            Throws.Exception.TypeOf<ArgumentException>());

        }
        [Test]
        public void Model_Getter_Returns_Right()
        {
            var car = new Car("Reihn", "A8", 5.6, 21.1);
            Assert.AreEqual("A8", car.Model);
        }


        [TestCase(-2.1)]
        [TestCase(0)]      
        public void Fuel_Consumption_Cannot_Be_Zero_Or_Negative(double consumption)
        {
            Assert.That(() =>
            {
                var car = new Car("Reihn", "A8", consumption, 21.1);
            },

           Throws.Exception.TypeOf<ArgumentException>());
        }
        [Test]
        public void Fuel_Consumption_Getter_Works()
        {
            var car = new Car("Reihn", "A8", 5.6, 21.1);

            Assert.AreEqual(5.6, car.FuelConsumption);
        }



        [TestCase(-2)]
        [TestCase(0)]
        public void FuelCapoacity_Cannot_Be_Less_Or_Zero(double capacity)
        {
            Assert.That(() =>
            {
                var car = new Car("Reihn", "A8", 5.6,capacity);
            },

          Throws.Exception.TypeOf<ArgumentException>());
        }



        [Test]
        public void FuelCapacity_Getter_Works()
        {
            var car = new Car("Reihn", "A8", 5.6, 21.1);
            Assert.AreEqual(21.1,car.FuelCapacity);   
        }



        [TestCase(0)]
        [TestCase(-3)]
        public void Refuel_Throws_Exeption_When_Amount_Is_Incorrect(double amount)
        {
            var car = new Car("Reihn", "A8", 5.6, 21.1);
            Assert.That(() =>
            {
                var car = new Car("Reihn", "A8", 5.6, 21.1);
                car.Refuel(amount);
            },

         Throws.Exception.TypeOf<ArgumentException>());
      

        }

        [Test]
        public void Refuel_Accepts_Capacity_Ammount_if_Higher()
        {
            var car = new Car("Reihn", "A8", 5.6, 21.1);
            car.Refuel(50.34);
            Assert.AreEqual(car.FuelCapacity, 21.1);      
        }

        [Test]
        public void Refuel_Sums_Correctly()
        {
            var car = new Car("Reihn", "A8", 5.6, 21.1);
            double current = car.FuelAmount;
            car.Refuel(5);
            Assert.AreEqual(car.FuelAmount, current + 5);   
        }

        [TestCase(1500)]
        public void Drive_Throws_Exeption(double distance)
        {
            Assert.That(() =>
              {
                var car = new Car("Reihn", "A8", 5.6, 21.1);
               car.Drive(distance);

            },
            Throws.Exception.TypeOf<InvalidOperationException>());



        }
        [Test]
        public void Drive_Can_Work_Correctly()
        {
            var car = new Car("Reihn", "A8", 5.6, 40);
            car.Refuel(80);

            double fuelNeeded = (200 / 100) * car.FuelConsumption; 
            double expected = car.FuelAmount - fuelNeeded;
           
            car.Drive(200);


            Assert.AreEqual(expected,car.FuelAmount);
            
          
        }

    }
}