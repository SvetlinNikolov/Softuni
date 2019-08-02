
using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        private string carMake;
        private string carModel;
        private double carFuelConsumtion;
        private double carFuelCapacity;
        private double carFuelAmount;

        [SetUp]
        public void Setup()
        {
            car = new Car("Nissan", "GTR", 20.00, 100.00);
                
            carMake = "Nissan";
            carModel = "GTR";
            carFuelConsumtion = 20.00;
            carFuelCapacity = 100.00;
            carFuelAmount = 0;
        }

        [Test]
        public void TestingIfConstructorWorksAccordingly()
        {

            string carMake = "Nissan";
            string carModel = "GTR";
            double carFuelConsumtion = 20.00;
            double carFuelCapacity = 100.00;
            double carFuelAmount = 0;

            Assert.AreEqual(carMake, car.Make);
            Assert.AreEqual(carModel, car.Model);
            Assert.AreEqual(carFuelConsumtion, car.FuelConsumption);
            Assert.AreEqual(carFuelCapacity, car.FuelCapacity);
            Assert.AreEqual(carFuelAmount, car.FuelAmount);

        }

        [Test]
        public void CarMakePropertySetsValueCorrectly()
        {
            Assert.AreEqual("Nissan", carMake);
        }

        [Test]
        public void CarMakeShouldThrowExceptionIfNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(null, "GTR", 20.00, 100.00);
            });
        }


        [Test]
        public void CarModelShouldSetCorrectly()
        {
            Assert.AreEqual("GTR", carModel);
        }

        [Test]
        public void CarModelShouldThrowExceptionIfNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Nissan", null, 20.00, 100.00);
            });
        }

        [Test]
        public void CarFuelConsumptionShouldSetCorrectly()
        {
            Assert.AreEqual(20, carFuelConsumtion);
        }

        [Test]
        public void FuelConsumptionShouldNotBeZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Nissan", "GTR", 0, 100.00);
            });
        }

        [Test]
        public void FuelAmountShouldSetCorrectly()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void FuelAmountShouldThrowExceptionIfZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-1);
            });
        }

        [Test]
        public void FuelCapacityShouldBeSetCorrectly()
        {
            Assert.AreEqual(100, car.FuelCapacity);
        }

        [Test]
        public void FuelCapacityShouldThrowExceptionIfZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Nissan", "GTR", 20, -1);
            });

        }

        [Test]
        public void RefuelMethodRefuelCorrectly()
        {
            car.Refuel(10);

            Assert.AreEqual(10, car.FuelAmount);

        }

        [Test]
        public void RefuelMethodShouldNotRefuelPastCarTankCapacity()
        {
            car.Refuel(1000);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);

        }

        [Test]
        public void RefuelMethodShouldThrowExceptionIfFuelToRefuelIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });

        }

        [Test]
        public void DriveMethodShouldSetFuelNeededCorrecly()
            {

            
            car.Refuel(100);

            double carInitialFuelAmount = car.FuelAmount;

            double carDrivingDistance = 100;

            double carFuelConsumption = car.FuelConsumption;

            double expectedCarFuelConsumptionForTrip = (carDrivingDistance / 100) * carFuelConsumption;

            car.Drive(carDrivingDistance);

            Assert.AreEqual(carInitialFuelAmount-expectedCarFuelConsumptionForTrip, car.FuelAmount);

        }

        [Test]
        public void DriveMethodShouldThrowExceptionIfFuelIsLessThanNeeded()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(100);
            });
        }
    }
}