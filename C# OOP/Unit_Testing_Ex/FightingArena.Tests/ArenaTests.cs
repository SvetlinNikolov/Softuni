
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void WarriorsEnrollInTheArenaCorrectly()
        {
            Warrior pesho = new Warrior("Pesho", 15, 50);
            arena.Enroll(pesho);

            Assert.That(arena.Count == 1);
        }

        [Test]
        public void AlreadyEnrolledWarriorsShouldNotBeAbleToEnrollAgain()
        {
            Warrior pesho = new Warrior("Pesho", 15, 50);
            arena.Enroll(pesho);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(pesho);
            });
        }


        [Test]
        public void FightingBetweenWarriorsWorksCorrectly()
        {
            Warrior pesho = new Warrior("Pesho", 15, 50);
            Warrior gosho = new Warrior("Gosho", 15, 50);

            arena.Enroll(pesho);
            arena.Enroll(gosho);

            Assert.DoesNotThrow(() =>
            {
                arena.Fight("Pesho", "Gosho");
            });

            Assert.AreEqual(35, pesho.HP);
            Assert.AreEqual(35, gosho.HP);
        }

        [Test]
        public void FightingNotEnrolledWarriorsThrowsException()
        {
            Warrior pesho = new Warrior("Pesho", 15, 50);
            Warrior gosho = new Warrior("Gosho", 15, 50);

            arena.Enroll(pesho);
            //arena.Enroll(gosho); we do not enroll gosho

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", "Gosho");
            });
        }

    }
}
