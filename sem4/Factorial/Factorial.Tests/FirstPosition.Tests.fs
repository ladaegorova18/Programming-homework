module FirstPosition.Tests

open NUnit.Framework
open FirstNumberPosition

let testCases =
    [
        3, [4; 3; 3], 1
        1, [1; 2; 3], 0
        -111, [42; -111], 1
        4, [3; 3; 4; 4; 1], 2
    ] |> List.map (fun (n, ls, pos) -> TestCaseData(n, ls, pos))

[<TestCaseSource("testCases")>]
[<Test>]
let firstPositionTest (number: int, list: int List, position) =
    let result = firstNumberPosition number list
    Assert.AreEqual(Some(position), result)

[<Test>]
let noneTest () =
    let result = firstNumberPosition 5 [2; 3; 4]
    Assert.AreEqual(None, result)