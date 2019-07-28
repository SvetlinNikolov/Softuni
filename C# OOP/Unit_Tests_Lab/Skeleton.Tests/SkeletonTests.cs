
namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SkeletonTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAtack()
        {
            Axe axe = new Axe(10,10);

            Dummy dummy = new Dummy(10,10);
            
            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints);
        }
    }
}
