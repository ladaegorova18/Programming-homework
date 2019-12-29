using MyNUnit.AttributesLibrary;

namespace BeforeAttributeTests
{
    /// <summary>
    /// Test for BeforeAttribute and BeforeClassAttribute
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Value to check changing
        /// </summary>
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
