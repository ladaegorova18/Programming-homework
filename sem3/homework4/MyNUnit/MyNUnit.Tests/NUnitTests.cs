using NUnit.Framework;

namespace MyNUnit.Tests
{
    [TestFixture]
    public class NUnitTests
    {
        private readonly string path = "../Tests";

        [Test]
        public void SuccessfulTestingTest()
        {
            var tester = new TestingClass(path + "/SuccessfulTesting/");
            tester.Process();
            Assert.AreEqual(2, tester.testInformation.Count);
        }

        [Test]
        public void EmptyTestsTest()
        {
            var tester = new TestingClass(path + "/EmptyTests/");
            var path2 = path + "/EmptyTests/";
            tester.Process();
        }

        [Test]
        public void ExceptionsTest()
        {
            var tester = new TestingClass(path + "/ExceptionTests/");
            tester.Process();
        }

        [Test]
        public void ParametersTest()
        {
        }
    }
}
