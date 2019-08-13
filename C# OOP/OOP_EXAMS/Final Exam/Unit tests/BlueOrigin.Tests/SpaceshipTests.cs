namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        [Test]
        public void ConstructorTest()
        {
            string expectedName = "Gosho";
            int expectedCapacity = 15;
            Spaceship spaceship = new Spaceship(expectedName, expectedCapacity);

            Assert.AreEqual(expectedName, spaceship.Name);
            Assert.AreEqual(expectedCapacity, spaceship.Capacity);
        }
        [Test]
        public void CountTest()
        {
            string expectedName = "Gosho";
            int expectedCapacity = 15;
            int expectedCount = 1;
            Spaceship spaceship = new Spaceship(expectedName, expectedCapacity);
            Astronaut astronaut = new Astronaut("PEsho", 15);
            spaceship.Add(astronaut);

            Assert.AreEqual(expectedCount, spaceship.Count);
        }
        [Test]
        public void NameShouldThrowExIfNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Spaceship spaceship = new Spaceship(null, 12);
            });
        }
        [Test]
        public void CapacityShouldThrowExIfLessThanZero()
        {
            string expectedName = "Gosho";
            Assert.Throws<ArgumentException>(() =>
            {
                Spaceship spaceship = new Spaceship(expectedName, -1);
            });
           
        }
        [Test]
        public void AddThrowsExIfIsEqualToSpaceshipCapacity()
        {
            string expectedName = "Gosho";
            int expectedCapacity = 1;
            Astronaut astronaut = new Astronaut("ivan", 15);
            Astronaut astr2 = new Astronaut("toshev", 14);
            Spaceship spaceship = new Spaceship(expectedName, expectedCapacity);

            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() =>
            {
                spaceship.Add(astr2);
            });
        }
        [Test]
        public void AddingExistingAStronaultShouldThrowEx()
        {
            string expectedName = "Gosho";
            int expectedCapacity = 4;
            Astronaut astr2 = new Astronaut("toshev", 14);
            Astronaut astr3 = new Astronaut("toshev", 14);
            Spaceship spaceship = new Spaceship(expectedName, expectedCapacity);

            spaceship.Add(astr2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                spaceship.Add(astr3);
            });
        }
        [Test]
        public void TestAddingWorkinsCorrectly()
        {
            string expectedName = "Gosho";
            int expectedCount = 1;
            int expectedCapacity = 4;
            Astronaut astr2 = new Astronaut("toshev", 14);
            
            Spaceship spaceship = new Spaceship(expectedName, expectedCapacity);

            spaceship.Add(astr2);

            Assert.AreEqual(expectedCount, spaceship.Count);
        }
        [Test]
        public void RemoveShouldReturnTrueIfAstronaultExists()
        {
            string expectedName = "Gosho";
            bool expectedResult = true;
            int expectedCapacity = 4;
            Astronaut astr2 = new Astronaut("toshev", 14);

            Spaceship spaceship = new Spaceship(expectedName, expectedCapacity);

            spaceship.Add(astr2);
            Assert.AreEqual(expectedResult, spaceship.Remove("toshev"));
        }

        [Test]
        public void RemoveShouldReturnFalseIfAstronaultDoesntExist()
        {
            string expectedName = "Gosho";
            bool expectedResult = false;
            int expectedCapacity = 4;
            Astronaut astr2 = new Astronaut("toshev", 14);

            Spaceship spaceship = new Spaceship(expectedName, expectedCapacity);

            spaceship.Add(astr2);
            Assert.AreEqual(expectedResult, spaceship.Remove("NOT"));
        }
    }
}