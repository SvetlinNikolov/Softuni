using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [SetUp]
      
        //        Create a class DummyTests
        //Create the following tests:
        // Dummy loses health if attacked
        // Dead Dummy throws exception if attacked
        // Dead Dummy can give XP
        // Alive Dummy can&#39;t give XP

        [Test]
        public void DummyLosesHealthIfAtacked()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(dummy.Health < 10);
        }
        [Test]
        public void DummyThrowsExceptionWhenKilled()
        {
            //Arrange
            Dummy dummy = new Dummy(0, 10);

            //Assert

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
        }

        [Test]
        public void DeadDummyCannotGiveExperience()
        {
            //Arrange
            Dummy dummy = new Dummy(-1, 10);

            //Assert
            Assert.DoesNotThrow(() => dummy.GiveExperience());
        }

        [Test]
        public void AliveDummyCannotGiveExperience()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(),"pss");
           
        }
    }
}
