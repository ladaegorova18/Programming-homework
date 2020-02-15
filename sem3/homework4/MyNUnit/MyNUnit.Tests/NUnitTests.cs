using NUnit.Framework;
using System.IO;
using System.Linq;

namespace MyNUnit.Tests
{
    /// <summary>
    /// main testing class 
    /// </summary>
    [TestFixture]
    public class NUnitTests
    {
        private readonly string path = Directory.GetCurrentDirectory() + "\\sem3\\homework4\\MyNUnit\\Tests";

        [SetUp]
        public void SetUp()
        {
            TestingClass.TestInformation = new System.Collections.Concurrent.ConcurrentBag<TestInfo>();
        }

        [Test]
        public void SuccessfulTestingTest()
        {
            TestingClass.Process(path + "/SuccessfulTesting");
            var successCount = TestingClass.TestInformation.Where(x => x.Crashed == false).ToList().Count;
            Assert.AreEqual(4, successCount);
        }

        [Test]
        public void EmptyTestsTest()
        {
            TestingClass.Process(path + "/EmptyTests");
            Assert.AreEqual(4, TestingClass.TestInformation.Count);
        }

        [Test]
        public void ExceptionsTest()
        {
            TestingClass.Process(path + "/ExceptionTests");
            var successCount = TestingClass.TestInformation.Where(x => !x.Crashed).ToList().Count;
            Assert.AreEqual(4, successCount);
        }

        [Test]
        public void ParametersTest()
        {
            TestingClass.Process(path + "/ParametersTests/bin");
            var successTests = TestingClass.TestInformation.Where(x => !x.Crashed).ToList();
            Assert.AreEqual(1, successTests.Count);
        }

        [Test]
        public void IgnoreAttributeTest()
        {
            TestingClass.Process(path + "/IgnoreAttributeTest");
            var ignoredTests = TestingClass.TestInformation.Where(x => !x.Ignored).ToList();
            Assert.IsTrue(ignoredTests.Where(x => (x.IgnoreReason).CompareTo("TestCase") == 0) != null);
            Assert.IsTrue(ignoredTests.Where(x => (x.IgnoreReason).CompareTo("SecondTestCase") == 0) != null);
        }
    }
}
