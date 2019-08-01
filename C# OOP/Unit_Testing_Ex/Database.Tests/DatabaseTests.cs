
using Database;
using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database data;
        [SetUp]
        public void Setup()
        {
            data = new Database.Database(16, 123, 987);
        }

       
        [Test]
        public void Adding_Element_Should_Add_To_Next_Free_Cell()
        {
           

            data.Add(4);

            int[] dataValues = data.Fetch();

            Assert.AreEqual(4, dataValues[dataValues.Length-1]);
        }
        [Test]
        public void Test_Adding_MoreElements_Than_Array_Capacity_Throws_Ex()
        {
            for (int i = 2; i < 15; i++)
            {
                data.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Add(17);
            });
        }
        
        
        [Test]
        public void Removing_From_Empty_Database_Should_Throw_Ex()
        {
            data = new Database.Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                data.Remove();
            });
        }


        [Test]
        public void Remove_Operation_Should_Reduce_Count_Of_Elements()
        {

            int dataCountElements = data.Count;

            data.Remove();

            Assert.AreEqual(dataCountElements - 1, data.Count);
           
        }


        [Test]
        public void Fetch_Should_Retrieve_Database_Elements_Correctly()
        {

            data = new Database.Database(1, 2, 3);

            int[] dataFetched = data.Fetch();

            int[] expectedElements = new int[]
            {
                1,2,3
            };

            CollectionAssert.AreEqual(expectedElements, dataFetched);

        }

        [Test]
        public void Constuctors_Should_Accept_Integers_Only_And_Store_Them_In_Array()
        {
            Assert.AreEqual(3, data.Count);
        }

    }
}