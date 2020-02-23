module EvenNumbers.Tests

open NUnit.Framework
open FoldCount
open FilterCount
open MapCount

let testCases =
    [
        [1..8], 4
        [0; 0; 0; 0; 0; 0; 0; 0; 0; 0], 10
        [1; 3; 5; 7; 9; 11; 13], 0
        [-7..-1], 3
        [-5..5], 5
        [], 0
    ] |> List.map (fun (ls, res) -> TestCaseData(ls, res))

[<TestCaseSource("testCases")>]
[<Test>]
let filterTest list count =
    let result = filterCount list
    Assert.AreEqual(count, result)

[<TestCaseSource("testCases")>]
[<Test>]
let foldTest list count =
    let result = foldCount list
    Assert.AreEqual(count, result)

[<TestCaseSource("testCases")>]
[<Test>]
let mapTest list count =
    let result = mapCount list
    Assert.AreEqual(count, result)