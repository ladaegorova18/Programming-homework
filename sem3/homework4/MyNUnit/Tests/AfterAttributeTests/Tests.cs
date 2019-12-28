using MyNUnit.AttributesLibrary;

namespace AfterAttributeTests
{
    public class Tests
    {
        public static string Line { get; set; } = null;

        [Test]
        public void MainTest()
        {
            Line = "Hello,";
        }

        [After]
        public static void AfterTest()
        {
            Line += " world";
        }

        [AfterClass]
        public static void AfterAttributeTest()
        {
            Line += "!";
        }
    }
}
