using MyNUnit.AttributesLibrary;

namespace AfterAttributeTests
{
    public class Tests
    {
        public static bool Line { get; set; }

        [Test]
        public void MainTest()
        {
            Line = false;
        }

        [After]
        public static void AfterTest()
        {
            Line = true;
        }

        [AfterClass]
        public static void AfterAttributeTest()
        {
            Line = true;
        }
    }
}
