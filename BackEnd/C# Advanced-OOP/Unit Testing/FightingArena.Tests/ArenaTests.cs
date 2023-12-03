namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Already_Enrolled_Warrior()
        {
            Assert.That(() =>
            {
                var arena = new Arena();
                var warrior = new Warrior("Steve", 40, 100);
                arena.Enroll(warrior);
                arena.Enroll(warrior);
            },
            Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void No_Fight_If_One_Of_The_Warriors_Is_Not_Enrolled()
        {
            Assert.That(() =>
            {
                var arena = new Arena();
                var warrior = new Warrior("Steve", 40, 100);
                var secondguy = new Warrior("Hans", 30, 80);
                arena.Enroll(warrior);
                arena.Fight("Steve", "Hans");
            },
            Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void Ctor_Is_Ok()
        {
            var arena = new Arena();
           
           
            
        }
        [Test]
        public void Count_Works_Fine()
        {
            var arena = new Arena();
            var warrior = new Warrior("Steve", 40, 100);
            var secondguy = new Warrior("Hans", 30, 80);
            arena.Enroll(warrior);
            arena.Enroll(secondguy);
            Assert.AreEqual(2, arena.Count);
        }
    }
}
