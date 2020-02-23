module InfinitePrimes.Tests

open NUnit.Framework
open CreateSeq

let testCases =
    [
        2, 0
        3, 1
        5, 2
        7, 3
        11, 4
        13, 5
    ] |> List.map (fun (number, pos) -> TestCaseData(number, pos))

[<TestCaseSource("testCases")>]
[<Test>]
let infinitePrimesTest number pos =
    let sequence = createSeq
    Assert.AreEqual(number, Seq.item(pos) sequence)