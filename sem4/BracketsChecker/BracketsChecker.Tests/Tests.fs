module BracketsChecker.Tests

open NUnit.Framework
open Checker
open FsUnit

let testCases = 
    [
    "", true
    "(", false
    "()", true
    "{}", true
    "{]", false
    "[[[]]]", true
    "{test}", true
    "[[[42)]", false
    "(([[{{()}}]]))", true
    "[[", false
    ] |> List.map (fun (line, res) -> TestCaseData(line, res))

[<TestCaseSource("testCases")>]
[<Test>]
let checkerTest line result = bracketsChecker line |> should equal result
