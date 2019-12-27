using MyNUnit.AttributesLibrary;

namespace BeforeAttributeTests
{
    public class Tests
    {
        public static int Value { get; set; } = 0;

        [Before]
        public void BeforeTest()
        {
            ++Value;
        }

        [BeforeAttribute]
        public void BeforeAttributeTest()
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
