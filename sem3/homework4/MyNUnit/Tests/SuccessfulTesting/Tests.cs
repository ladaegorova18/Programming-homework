using MyNUnit.AttributesLibrary;

namespace SuccessfulTesting
{
    /// <summary>
    /// successful short methods tests
    /// </summary>
    public class Tests
    {
        [Test]
        public void CountTest()
        {
            var x = 5 + 3;
        }

        [Test]
        public void SecondCountTest()
        {
            var a = 1;
            var b = 33;
        }
    }
}
