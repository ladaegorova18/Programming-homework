using MyNUnit.AttributesLibrary;

namespace BeforeAttributeTests
{
    public class Tests
    {
        public static int Value { get; set; } = 0;

        [Before]
        public static void BeforeTest()
        {
            ++Value;
        }

        [BeforeClass]
        public static void BeforeAttributeTest()
        {
            Value += 2;
        }

        [Test]
        public void MainTest()
        {
            ++Value;
        }
    }
}
