module ListOfPows.Tests

open NUnit.Framework
open ListOfPows

[<TestCase(16, 4, 3)>]
[<TestCase(1, 0, 5)>]
[<TestCase(2, 1, 1)>]

[<Test>]
let listOfPowsTest head n m =
 Assert.AreEqual(head, (listOfPows n m).Head)