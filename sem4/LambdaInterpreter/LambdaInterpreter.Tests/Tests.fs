module LambdaInterpreter.Tests

open NUnit.Framework
open Reduction
open FsUnit

[<Test>]
let ``One variable reduction``() = betaReduction (Variable('x')) |> should equal <| Variable('x')

[<Test>]
let ``Substitution to abstraction test``() = 
    betaReduction (Application(LambdaAbstraction('x', Variable('y')), Variable('z'))) |> should equal <| Variable('y')

[<Test>]
let ``Application of two variables test``() = 
    betaReduction (Application(Variable('a'), Variable('b'))) |> should equal <| (Application(Variable('a'), Variable('b')))

[<Test>]
let ``Real formula test``() =
    betaReduction (Application(LambdaAbstraction('x', Application(LambdaAbstraction('y', Variable('y')), Variable('x'))), Variable('a'))) |> should equal <| Variable('a')

[<Test>]
let ``Substitution test``() =
    betaReduction 
        (Application
            (LambdaAbstraction
                ('x', Application
                    (LambdaAbstraction('x', Variable('z')), Variable('z'))), 
                        Variable('a'))) |> should equal <| Variable('z')
