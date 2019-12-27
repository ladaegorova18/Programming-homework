using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MyNUnit.Tests
{
    [TestFixture]
    public class NUnitTests
    {
        private readonly string path = "Tests";

        [SetUp]
        public void SetUp()
        {
            TestingClass.testInformation = new System.Collections.Concurrent.ConcurrentBag<TestInfo>();
        }

        [Test]
        public void SuccessfulTestingTest()
        {
            var tester = new TestingClass(path + "/SuccessfulTesting");
            tester.Process();
            var successCount = TestingClass.testInformation.Where(x => x.Crashed == false).ToList().Count;
            Assert.AreEqual(4, successCount);
        }

        [Test]
        public void EmptyTestsTest()
        {
            var tester = new TestingClass(path + "/EmptyTests");
            tester.Process();
            Assert.AreEqual(4, TestingClass.testInformation.Count);
        }

        [Test]
        public void ExceptionsTest()
        {
            var tester = new TestingClass(path + "/ExceptionTests");
            tester.Process();

        }

        [Test]
        public void ParametersTest()
        {
            var tester = new TestingClass(path + "/ParametersTests");
            tester.Process();
            var successTests = TestingClass.testInformation.Where(x => x.Crashed == false).ToList();
            Assert.AreEqual(2, GetTestsCount(successTests, 0));
            Assert.AreEqual(2, GetTestsCount(successTests, 1));
            Assert.AreEqual(2, GetTestsCount(successTests, 2));
        }

        private static int GetTestsCount(List<TestInfo> successTests, int parametersCount)
        {
            return successTests.Where(x => x.Parameters == parametersCount).ToList().Count;
        }

        [Test]
        public void AfterAttributeTest()
        {
            var tester = new TestingClass(path + "/IgnoreAttributeTest");
            tester.Process();
            Assert.AreEqual("Hello, world!", AfterAttributeTests.Tests.Line);

        }

        [Test]
        public void BeforeAttributeTest()
        {
            var tester = new TestingClass(path + "/IgnoreAttributeTest");
            tester.Process();
            Assert.AreEqual(4, BeforeAttributeTests.Tests.Value);
        }

        [Test]
        public void IgnoreAttributeTest()
        {
            var tester = new TestingClass(path + "/IgnoreAttributeTest");
            tester.Process();
            var ignoredTests = TestingClass.testInformation.Where(x => x.Ignored = true).ToList();
            Assert.IsTrue(ignoredTests.Where(x => (x.IgnoreReason).CompareTo("TestCase") == 0) != null);
            Assert.IsTrue(ignoredTests.Where(x => (x.IgnoreReason).CompareTo("SecondTestCase") == 0) != null);
        }
    }
}
