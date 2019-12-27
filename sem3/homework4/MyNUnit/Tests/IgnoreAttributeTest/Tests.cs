using MyNUnit.AttributesLibrary;

namespace IgnoreAttributeTest
{
    public class Tests
    {
        [Test(Ignore = "TestCase")]
        public void IgnoreTest()
        {
        }

        [Test(Ignore = "SecondTestCase")]
        public void SecondIgnoreTest()
        {
        }
    }
}
