module ParseTree.Tests

open NUnit.Framework
open Parse
open FsUnit
open FsCheck

let testCases =
    [
        Sum(Int(3), Int(4)), 7 /// 3 + 4
        Sum(Multiply(Int(2), Int(5)), Int(8)), 18 /// 2 * 5 + 8
        Subtract(Multiply(Int(100), Int(-4)), Int(80)), -480 /// 100 * (-4) - 80
    ] |> List.map (fun (tree, result) -> TestCaseData(tree, result))

[<TestCaseSource("testCases")>]
[<Test>]
let ``Parse tree result should be equal expression result custom tests`` tree result = parseTree tree |> should equal result

/// FsCheck tests
let ``Sum test`` x y = parseTree (Sum(Int(x), Int(y))) |> should equal (x + y)
let ``Multiplication test`` x y = parseTree (Multiply(Int(x), Int(y))) |> should equal (x * y)
let ``Subtraction test`` x y = parseTree (Subtract(Int(x), Int(y))) |> should equal (x - y)
let ``Division test`` x y = if y <> 0 then parseTree (Divide(Int(x), Int(y))) |> should equal (x / y)
let ``Divide by zero test`` x = (fun () -> parseTree (Divide(Int(x), Int(0))) |> ignore) |> should throw typeof<System.DivideByZeroException>  

[<Test>]
let fsCheckSumTest () = Check.QuickThrowOnFailure ``Sum test``

[<Test>]
let fsCheckMultiplyTest () = Check.QuickThrowOnFailure ``Multiplication test``

[<Test>]
let fsCheckSubtractionTest () = Check.QuickThrowOnFailure ``Subtraction test``

[<Test>]
let fsCheckDivisionTest () = Check.QuickThrowOnFailure ``Division test``

[<Test>]
let fsCheckDivideByZeroTest () = Check.QuickThrowOnFailure ``Divide by zero test``
