
using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void ConstructorShoudInitializeCollection()
        {
            Person gosho = new Person(1, "Gosho");
            Person pesho = new Person(2, "Pesho");

            database = new ExtendedDatabase.ExtendedDatabase(pesho, gosho);

            Assert.AreEqual(2, database.Count);
        }
        [Test]
        public void AddingAPersonToTheDatabaseShouldIncreaseTheCountOfPeopleInIt()
        {
            Person gosho = new Person(1, "Gosho");

            database.Add(gosho);

            Assert.AreEqual(1, database.Count);

        }

        [Test]
        public void AddingExistingPersonIdShouldThrowException()
        {
            Person gosho = new Person(1, "Gosho");
            Person gosho1 = new Person(1, "Pesho");
            database.Add(gosho);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(gosho1);
            });

        }
        [Test]
        public void AddingExistingPersonUsernameShouldThrowException()
        {
            Person gosho = new Person(1, "Gosho");
            Person gosho1 = new Person(2, "Gosho");
            database.Add(gosho);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(gosho1);
            });

        }

        [Test]
        public void RemoveMethodShouldReduceCountOfPeopleInDatabase()
        {
            Person gosho = new Person(1, "Gosho");
            Person pesho = new Person(2, "Pesho");

            database = new ExtendedDatabase.ExtendedDatabase(gosho, pesho);
            database.Remove();

            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionIfTryingToRemoveFromEmptyDatabase()
        {
            database = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void FindByUsernameShouldReturnCorrectPerson()
        {

            Person pesho = new Person(2, "Pesho");

            database.Add(pesho);

            Person personToFind = database.FindByUsername("Pesho");

            Assert.AreEqual(pesho, personToFind);

        }


        [Test]
        public void FindByUsernameShouldThrowExceptionToNonExistingPerson()
        {

            Person pesho = new Person(2, "Pesho");

            database.Add(pesho);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Person_Not_In_Database");
            });

        }


        [Test]
        public void FindByUsernameShouldThrowExceptionToNullPerson()
        {

            Person pesho = new Person(2, "Pesho");

            database.Add(pesho);

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            });

        }

        [Test]

        public void FindByIdShouldReturnCorrectPerson()
        {
            Person pesho = new Person(2, "Pesho");

            database.Add(pesho);

            Person personToFind = database.FindById(2);

            Assert.AreEqual(pesho, personToFind);
        }

        [Test]

        public void FindByIdShouldThrowExceptionIfPersonDoesNotExist()
        {

            Person pesho = new Person(2, "Pesho");

            database.Add(pesho);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(420);
            });
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfIdIsNegative()
        {

            Person pesho = new Person(2, "Pesho");

            database.Add(pesho);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            });
        }
    }


}
