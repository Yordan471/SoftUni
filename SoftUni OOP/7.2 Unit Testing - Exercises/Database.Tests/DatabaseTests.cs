namespace Database.Tests
{
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database data;

        [SetUp]

        public void Setup()
        {
            this.data = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void Test_DBConstructor(int[] testArray)
        {
            data = new Database(testArray);

            int[] expecterResult = testArray;
            int[] actualResult = data.Fetch();

            CollectionAssert.AreEqual(expecterResult, actualResult, "We get incorrect information in data");

            int expectedCount = testArray.Length;
            int actualCount = actualResult.Length;

            Assert.That(expectedCount, Is.EqualTo(actualCount), "Count isn't correct");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]

        public void Test_Propery_CountGetter(int[] testArray)
        {
            data = new Database(testArray);

            int expecterCount = testArray.Length;
            int actualCount = data.Count;

            Assert.That(expecterCount, Is.EqualTo(actualCount), "Wrong actual count, check Count Getter, or DB Constructor");
        }

        [TestCase(new int() ,1 , 2, -1)]

        public void Test_IfMethodAdd_AddsElement(int element)
        {
            data.Add(element);
            int expectedAddedElement = element;
            int actualAddedElement = 
            Assert.That()
        }
    }
}
