module FirstPosition.Tests

open NUnit.Framework
open FirstNumberPosition

let testCases =
    [
        3, 0, [4; 3; 3], 1
        5, 0, [1; 2; 3; 4], -1
        1, 0, [1; 2; 3], 0
        -111, 0, [42; -111], 1
        4, 0, [3; 3; 4; 4; 1], 2
    ] |> List.map (fun (n, i, ls, pos) -> TestCaseData(n, i, ls, pos))

[<TestCaseSource("testCases")>]
[<Test>]
let firstPositionTest (number: int, index: int, list: int List, position: int) =
 let result = firstNumberPosition number index list
 Assert.AreEqual(position, result)
