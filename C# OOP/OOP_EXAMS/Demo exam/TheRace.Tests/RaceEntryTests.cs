using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry racers;
        private UnitMotorcycle motorcycle;
        private UnitRider rider;

        [SetUp]
        public void Setup()
        {
            this.racers = new RaceEntry();
            this.motorcycle = new UnitMotorcycle("Honda", 60, 125);
            this.rider = new UnitRider("Pesho", this.motorcycle);
        }



        [Test]
        public void CounterTest()
        {
            int expectedCounter = 2;
            this.racers.AddRider(rider);
            this.racers.AddRider(new UnitRider("asdasd", motorcycle));

            Assert.AreEqual(expectedCounter, this.racers.Counter);
        }

        [Test]
        public void AddRiderThrowsExIfRiderIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.racers.AddRider(null));
        }

        [Test]
        public void AddRiderThrowsExIfRacersContainsNameThatIsAlreadyAdded()
        {
            this.racers.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
            this.racers.AddRider(new UnitRider("Pesho", motorcycle)));
        }

        [Test]

        public void AddRiderReturnsCorrectMessageWhenAddingRider()
        {
            string expectedMessage = "Rider Pesho added in race.";

            Assert.AreEqual(expectedMessage, this.racers.AddRider(rider));
        }

        [Test]
        public void CalculateAverageHorsePowerThrowsExIfLessThanMinParticipants()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.racers.CalculateAverageHorsePower()
            , message: "The race cannot start with less than 2 participants.");
        }

        [Test]
        public void CalculateAverageHorsePowercalculatesCorrectly()
        {
            RaceEntry racers = new RaceEntry();
            UnitRider random = new UnitRider("Goshkata", new UnitMotorcycle("yamaha", 100, 123));

            racers.AddRider(rider);
            racers.AddRider(random);

            double expectedAverageHp = (random.Motorcycle.HorsePower + rider.Motorcycle.HorsePower) / 2;

            Assert.AreEqual(expectedAverageHp, racers.CalculateAverageHorsePower());
        }

        [Test]
        public void ReallyRandomTest()
        {
            Assert.AreEqual(0, this.racers.Counter);
        }

        [Test]
        public void TestIfAddMethodWorks()
        {
            Assert.AreEqual("Rider Pesho added in race.", this.racers.AddRider(this.rider));
            Assert.AreEqual(1, this.racers.Counter);
        }

        [Test]
        public void TestIfAddMethodThrowsErrorIfRiderIsNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.racers.AddRider(null);
            });
        }

        [Test]
        public void TestIfAddMethodThrowsErrorIfRiderExists()
        {
            this.racers.AddRider(rider);

            var someRider = new UnitRider("Pesho", this.motorcycle);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.racers.AddRider(someRider);
            });
        }

        [Test]
        public void TestAverageHorsePower()
        {
            var gosho = new UnitRider("Gosho", this.motorcycle);

            this.racers.AddRider(gosho);
            this.racers.AddRider(this.rider);

            Assert.AreEqual(60, this.racers.CalculateAverageHorsePower());
        }

        [Test]
        public void TestIfAverageHorsePowerThrowsErrorIfLessThanMinRiders()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.racers.CalculateAverageHorsePower();
            });
        }
    }
}