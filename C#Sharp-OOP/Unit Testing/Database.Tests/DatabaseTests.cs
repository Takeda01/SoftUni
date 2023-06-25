namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void Capacity_Should_Be_Exactly_Sixteen_Integers()
        {
            Database database = new Database();
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);


        }
        [Test]
        public void Cpacity_Cannot_Be_Longer()
        {
            Assert.That(() =>
            {


                Database d = new Database();
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
                d.Add(1);
            },
            Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void Remove_Only_Last_Index_Element()
        {
            Assert.That(() =>
            {
                var d = new Database();

                d.Remove();

            },
            Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void Fetch_Return_Array()
        {
            Database database = new Database();
            database.Add(1);
            database.Add(2);

            Assert.That(database.Fetch() is Array);


        }
        [Test]
        public void Ctor_Accepts_Only_Integers()
        {
            Assert.That(() =>
            {

                Database database = new Database(2, 1, 4, 15, 32);
            },
            Throws.Nothing);


        }
       [TestCase(new int[] {})]
        [TestCase(new int[] {1})]
        [TestCase(new int[] {1,2,3})]
        [TestCase(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16})]
        public void Constructor_Should_Add_Less_Than_Sixteen_Elements(int[] ElementsToAdd)
        {
            Database d = new Database(ElementsToAdd);
            int[] actualData = d.Fetch();
            int[] expectedData = ElementsToAdd;


            int actualCount = d.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData,
                "Database ctro should intialise field correctly!");

            Assert.AreEqual(expectedCount, actualCount, 
                "Constructor should set initial value for count field! ");
        }
        [Test]
        public void CtorReturnsZero()
        {
            Database db = new Database();
            int actualCount = db.Count;
            int expected = 0;
            Assert.AreEqual(expected, actualCount);
        }
    
      

    }
}
