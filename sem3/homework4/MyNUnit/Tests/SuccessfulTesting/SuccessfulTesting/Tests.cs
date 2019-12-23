using AttributesLibrary;

namespace SuccessfulTesting
{
    public class Tests
    {
        [TestAttribute]
        public void CountTest()
        {
            var x = 5 + 3;
        }

        [TestAttribute]
        public void SecondCountTest()
        {
            var a = 1;
            var b = 33;
        }
    }
}
