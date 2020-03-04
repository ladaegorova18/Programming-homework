module Factorial.Tests

open NUnit.Framework
open FactorialNumber

[<TestCase(120, 5)>]
[<TestCase(1, 1)>]
[<TestCase(1, 0)>]
[<TestCase(720, 6)>]
[<TestCase(24, 4)>]
[<Test>]
let factorialTest (result, number) =
    Assert.AreEqual(result, factorial number)
