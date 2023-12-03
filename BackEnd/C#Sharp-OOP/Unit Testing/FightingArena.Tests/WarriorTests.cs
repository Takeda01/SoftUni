namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [TestCase(" ")]
        [TestCase(null)]
        public void Name_Cannot_Be_Null_Or_WhiteSpace(string name)
        {

            Assert.That(() =>
            {
                Warrior warrior = new Warrior(name, 20, 100);
            },
            Throws.Exception.TypeOf<ArgumentException>());
        }
        [TestCase(0)]
        [TestCase(-1)]
        public void Damage_Cannot_Be_Zero_Or_Negative(int damage)
        {

            Assert.That(() =>
            {
                Warrior warrior = new Warrior("Hans", damage, 100);
            },
            Throws.Exception.TypeOf<ArgumentException>());
        }
        [Test]
        public void HP_Cannot_Be_Negative()
        {
            Assert.That(() =>
            {
                Warrior warrior = new Warrior("Hans", 20, -5);
            },
            Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]

        public void Attack_Method_Throws_Exception_When_IS_Invalid()
        {
            
                Warrior warrior = new Warrior("Hans", 20, 25);
                Warrior secondwarrior = new Warrior("John", 30, 10);
            Assert.That(() =>
            {
                warrior.Attack(secondwarrior);
            },
            Throws.Exception.TypeOf<InvalidOperationException>());
             
            Assert.That(() =>
            {
                secondwarrior.Attack(warrior);
            },
             Throws.Exception.TypeOf<InvalidOperationException>());


        }
        [Test]
        public void Getters_Are_OK()
        {
            Warrior warrior = new Warrior("Hans", 20, 60);
            Assert.AreEqual("Hans", warrior.Name);
            Assert.AreEqual(20, warrior.Damage);
            Assert.AreEqual(60, warrior.HP);
        }
        [Test]
        public void Ctor_Works_Fine()
        {
            Warrior warrior = new Warrior("Hans", 20, 60);
            
        }

    }
}