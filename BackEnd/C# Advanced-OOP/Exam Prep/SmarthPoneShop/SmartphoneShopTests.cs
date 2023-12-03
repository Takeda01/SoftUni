using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Capacity_Works_Propertly()
        {
           
            Shop shop = new Shop(3);
            Assert.AreEqual(3, shop.Capacity);
            

        }
        [Test]
        public void Negative_Capacity_Throws_Exception()
        {
            Assert.That(() =>
            {
                var shop = new Shop(-1);
            },
            Throws.Exception.TypeOf<ArgumentException>());
        }
        [Test]

        public void AddMethod_Throws_Right_Exceptions()
        {
            Smartphone s = new Smartphone("Samsung", 100);
            Smartphone smartphone = new Smartphone("Nokia", 50);
            Smartphone smartphone1 = new Smartphone("Iphone", 110);

            Shop shop = new Shop(3);
            Assert.That(() =>
            {
                shop.Add(s);
                shop.Add(s);
            },
            Throws.Exception.TypeOf<InvalidOperationException>());

            Assert.That(() =>
            {
                shop.Add(s);
                shop.Add(smartphone);
                shop.Add(smartphone1);
            },
             Throws.Exception.TypeOf<InvalidOperationException>());


        }

        [Test]
        public void RemoveMethod_Throws_Exception_If_Object_is_Null()
        {
            Smartphone smartphone = new Smartphone("S",0);
         
            Shop shop = new Shop(3);
            Assert.That(() =>
            {
           
                shop.Remove("S");

            },
            Throws.Exception.TypeOf<InvalidOperationException>());
           
        }
        [Test]
        public void TestPhone_Throws_Exception_If_A_Phone_Doesnt_Excist()
        {
            Shop shop = new Shop(3);
            Assert.That(() =>
           {

               shop.TestPhone("S", 50);

           },
           Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void TestPhone_Throws_Exception_InCase_Of_Invalid_Battery()
        {
            Shop shop = new Shop(3);
            Smartphone s = new Smartphone("Samsung", 100);
            Assert.That(() =>
            {

                shop.Add(s);
                shop.TestPhone("Samsung", 50);

            },
            Throws.Nothing);

            Assert.That(() =>
           {
                shop.TestPhone("Samsung", 60);
           },
              Throws.Exception.TypeOf<InvalidOperationException>());



        }
        [Test]
        public void Test_Method_Devides_Propertly()
        {
            Shop shop = new Shop(3);
            Smartphone s = new Smartphone("Samsung", 100);
          

                shop.Add(s);
                shop.TestPhone("Samsung", 50);

           Assert.AreEqual(50, s.CurrentBateryCharge);
            
        }
        [Test]
        public void Unexisting_Phone_Cannot_Be_Charged()
        {
            Assert.That(() =>
            {
                var shop = new Shop(3);
                shop.ChargePhone("Samsung"); 


            },
              Throws.Exception.TypeOf<InvalidOperationException>());




        }
        [Test]
        public void Charging_Method_Works()
        {

            var phone = new Smartphone("Samsung", 100);
             Shop shop = new Shop(3);
                shop.Add(phone);
                shop.TestPhone("Samsung", 50);
                shop.ChargePhone("Samsung");
            Assert.AreEqual(phone.CurrentBateryCharge, 100);


           
        }
        [Test]
        public void Count_Counts_Like_The_People()
        {
            var phone = new Smartphone("Samsung", 100);
            var smarthphone = new Smartphone("Nokia", 100);
            Shop shop = new Shop(3);
            shop.Add(phone);
            shop.Add(smarthphone);
            Assert.AreEqual(2,shop.Count);

        }
        [Test]
        public void Remove_Removes_The_Phone()
        {
            Smartphone smartphone = new Smartphone("S", 0);

            Shop shop = new Shop(3);
            Assert.That(() =>
            {
                shop.Add(smartphone);

                shop.Remove("S");
                shop.ChargePhone("S");
            },
            Throws.Exception.TypeOf<InvalidOperationException>());
          
        }
        [Test]
        public void Add_Adds_Phone_To_Collection()
        {
            Smartphone smartphone = new Smartphone("S", 100);

            Shop shop = new Shop(3);
            Assert.That(() =>
            {
                shop.Add(smartphone);


                shop.TestPhone("S", 30);
            },
        Throws.Nothing);
        }


    }
}