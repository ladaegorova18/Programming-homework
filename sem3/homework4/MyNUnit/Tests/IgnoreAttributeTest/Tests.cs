using Attributes;

namespace IgnoreAttributeTest
{
    /// <summary>
    /// ignore attribute tests
    /// </summary>
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
