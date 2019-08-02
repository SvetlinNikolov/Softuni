
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WarriorNameIsSetCorrectly()
        {
            Warrior pesho = new Warrior("Literraly Kitler", 1, 1942);

            Assert.AreEqual("Literraly Kitler", pesho.Name);
        }

        [Test]
        public void WarriorNameThrowsExceptionIfNullOrEmpty()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior pesho = new Warrior("           ", 1, 1942);
            });
        }

        [Test]
        public void DamageIsSetCorrectly()
        {
            Warrior pesho = new Warrior("Pesho", 1, 1942);

            Assert.AreEqual(1, pesho.Damage);

        }


        [Test]
        public void DamageIsThrowsExceptionIfZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior pesho = new Warrior("Pesho", -1, 1942);
            });
        }

        [Test]
        public void HpIsSetCorrectly()
        {
            Warrior pesho = new Warrior("Pesho", 15, 1942);

            Assert.AreEqual(1942, pesho.HP);
        }

        [Test]
        public void HpThrowsExceptionIfNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior pesho = new Warrior("Pesho", 15, -1);
            });
        }


        [Test]
        public void WarriorAtackWorksAsIntended()
        {
            Warrior pesho = new Warrior("Pesho", 20, 100);
            Warrior gosho = new Warrior("Gosho", 15, 50);

            int expectedPeshoHp = 85;
            int expectedGoshoHp = 30;

            pesho.Attack(gosho);

            Assert.AreEqual(expectedPeshoHp, pesho.HP);
            Assert.AreEqual(expectedGoshoHp, gosho.HP);
        }

       

        [Test]
        public void WarriorShouldNotBeAbleToAtackIfHpIsLessThan30()
        {
            Warrior pesho = new Warrior("Pesho", 20, 10);
            Warrior gosho = new Warrior("Gosho", 15, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                pesho.Attack(gosho);
            });
        }

        [Test]
        public void WarriorsCannotAtackOtherWarriorThatHasLessThan30Hp()
        {
            Warrior pesho = new Warrior("Pesho", 20, 50);
            Warrior gosho = new Warrior("Gosho", 15, 29);

            Assert.Throws<InvalidOperationException>(() =>
            {
                pesho.Attack(gosho);
            });
        }

        [Test]
        public void WarriorsCannotAtackStrongerWarriorThanThem()
        {
            Warrior pesho = new Warrior("Pesho", 20, 50);
            Warrior gosho = new Warrior("Gosho", 1000, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                pesho.Attack(gosho);
            });
        }


        [Test]
        public void IfWarriorKillsOtherWarriorTheKilledWarriorShouldHaveZeroHp()
        {
            Warrior pesho = new Warrior("Pesho", 60, 50);
            Warrior gosho = new Warrior("Gosho", 30, 50);

            pesho.Attack(gosho);

            Assert.AreEqual(0, gosho.HP);
        }
    }
}