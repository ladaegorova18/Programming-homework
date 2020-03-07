module Fibonacci.Tests

open NUnit.Framework
open Fibonacci

[<TestCase(1, 0)>]
[<TestCase(1, 1)>]
[<TestCase(2, 2)>]
[<TestCase(8, 5)>]
[<TestCase(21, 7)>]
[<Test>]
let fibonacciTest (result, number) =
    Assert.AreEqual(result, fibonacci number)
