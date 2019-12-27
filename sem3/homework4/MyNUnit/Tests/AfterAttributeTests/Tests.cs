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
        public void AfterTest()
        {
            Line += " world";
        }

        [AfterAttribute]
        public void AfterAttributeTest()
        {
            Line += "!";
        }
    }
}
