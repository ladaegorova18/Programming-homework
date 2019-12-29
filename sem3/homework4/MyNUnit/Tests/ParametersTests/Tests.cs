using MyNUnit.AttributesLibrary;

namespace ParametersTests
{
    /// <summary>
    /// tests with various count of parameters
    /// </summary>
    public class Tests
    {
        [Test]
        public void ZeroParametersTest()
        {
        }

        [Test]
        public void OneParameterTest(int value)
        {
            ++value;
        }

        [Test]
        public void TwoParametersTest(int value, string line)
        {
            ++value;
            line = null;
        }
    }
}
