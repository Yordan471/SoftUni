using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        Dummy dummy;
        int dummyHealth;
        int dummyExp;

        [SetUp]
        public void SetUp()
        {
            dummyHealth = 100;
            dummyExp = 10;
            dummy = new(dummyHealth, dummyExp);
        }

        [Test]
        public void TestDummyConstructor()
        {
            Assert.That(dummy.Health, Is.EqualTo(dummyHealth), "Dummy Health points are different then the one set from the constructor");
        }


    }
}