using AttributesLibrary;
using System.Collections.Generic;

namespace BeforeAttributeTests
{
    public class Tests
    {
        private int value = 0;
        private List<string> list;

        [Before]
        public void FirstBeforeAttributeTest()
        {
            value = 3;
        }

        [Before]
        public void SecondBeforeAttributeTest()
        {
            list = new List<string>();
        }
    }
}
