﻿using AttributesLibrary;
using System;

namespace ExceptionTests
{
    public class Tests
    {
        [TestAttribute(Expected = typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            var b = 0;
            var x = 4 / b;
        }

        [TestAttribute(Expected = typeof(IndexOutOfRangeException))]
        public void IndexOutOfRangeTest()
        {
            var array = new int[] { 1, 3, 5 };
            var index = -1;
            var k = array[index];
        }
    }
}
