using MyNUnit.AttributesLibrary;

namespace ParametersTests
{
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
