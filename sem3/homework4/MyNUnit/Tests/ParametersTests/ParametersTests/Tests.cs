using AttributesLibrary;

namespace ParametersTests
{
    public class Tests
    {
        [Test]
        public void OneParameterTest(int value) { }

        [Test]
        public void TwoParametersTest(int value, string line) { }

        [Test]
        public void ZeroParametersTest() { }
    }
}
