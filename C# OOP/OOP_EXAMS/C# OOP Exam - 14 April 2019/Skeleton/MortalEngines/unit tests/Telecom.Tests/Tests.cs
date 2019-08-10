namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [Test]
        public void ConstructorWorksCorrectly()
        {
            string make = "Motorolla";
            string model = "G8";

            Phone phone = new Phone(make, model);

            Assert.AreEqual(make, phone.Make);
            Assert.AreEqual(model, phone.Model);
        }

        [Test]
        public void MakeThrowsExIfNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(null, "G8");
            });
        }

        [Test]
        public void ModelThrowsExIfNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone("Nokia", null);
            });
        }

        [Test]
        public void TestCountWorksCorrectly()
        {
            int expectedCount = 2;

            Phone nokia = new Phone("Nokia", "8");

            nokia.AddContact("pesho", "087644911");
            nokia.AddContact("gosoh", "567890");

            Assert.AreEqual(expectedCount, nokia.Count);
        }

        [Test]
        public void AddContactThrowsExIfPersonAlreadyExists()
        {
            int expectedCount = 2;

            Phone nokia = new Phone("Nokia", "8");

            nokia.AddContact("pesho", "087644911");

            Assert.Throws<InvalidOperationException>(() =>
            {
                nokia.AddContact("pesho", "087644911");
            },message: "Person already exists!");
        }

        [Test]
        public void CallingReturnCorrectMessage()
        {
            string nameTocall = "pesho";

            Phone nokia = new Phone("Nokia", "8");

            nokia.AddContact("pesho", "087644911");

            string expectedMessage = $"Calling {nameTocall} - {"087644911"}...";

            Assert.AreEqual(expectedMessage, nokia.Call(nameTocall));
        }
        [Test]
        public void CallingNotAddedPersonThrowsEx()
        {
            Phone nokia = new Phone("Nokia", "8");


            Assert.Throws<InvalidOperationException>(() =>
            nokia.Call("InvalidPerson"), message: "Person doesn't exists!");
        }
    }
}