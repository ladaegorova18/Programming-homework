module EvenNumbers.Tests

open NUnit.Framework
open FsUnit
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
let filterTest list count = filterCount list |> should equal count

[<TestCaseSource("testCases")>]
[<Test>]
let foldTest list count = foldCount list |> should equal count

[<TestCaseSource("testCases")>]
[<Test>]
let mapTest list count = mapCount list |> should equal count