using DatabaseProject;
using NUnit.Framework;
using System;

namespace DatabaseTests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
            this.database = new Database(1, 2, 3, 4, 5, 6);
        }

        [Test]
        public void StoringArrayCapacityMustBeLessOrEqualToSixteen()
        {
            Assert.That(true);

        }
    }
}
