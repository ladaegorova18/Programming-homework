module ListReverse.Tests

open NUnit.Framework
open ListReverse

let testCases =
    [
        [1; 2; 3], [3; 2; 1]
        [1; 1; 1; 2], [2; 1; 1; 1]
        [9; 99; 999], [999; 99; 9]
    ] |> List.map (fun (ls, res) -> TestCaseData(ls, res))

[<TestCaseSource("testCases")>]
[<Test>]
let listReverseTest (list: int List, result: int List) =
 let revList = listReverse list []
 Assert.IsTrue(result.Equals(revList))