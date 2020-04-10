module ListTests

open NUnit.Framework
open FsUnit
open FsCheck
open MinElement

let testCases =
    [
        [1; 2; 3; 6; 7; 1; 0; -5; 4], -5
        [1; 1; 1; 2; 10; 2; -4; 0], -4
        [9; 99; 999], 9
        [-1; -2; -3; -6; 0], -6
    ] |> List.map (fun (ls, res) -> TestCaseData(ls, res))

[<TestCaseSource("testCases")>]
[<Test>]
let listMinElement (list: int List, result: int) =
    minElement list |> should equal result

let minElementCheck (list: int list) = if list <> [] then minElement list = List.min list else true

[<Test>]
let ``FsChecking``() = Check.QuickThrowOnFailure minElementCheck

[<Test>]
let ``EmptyList``() = (fun () -> minElement [] |> ignore) |> should throw typeof<System.Exception>