module SpecifiedAccuracyTests

open System
open NUnit.Framework
open FsUnit
open FsCheck
open Counter

[<Test>]
let ``should round to 0 digits``() =
    let rounding = new RoundingBuilder(0)
    rounding {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    } |> should equal 0.0

[<Test>]
let ``should round to 3 digits``() =
    let rounding = new RoundingBuilder(3)
    rounding {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    } |> should (equalWithin 0.001) 0.048 

[<Test>]
let ``should round to 5 digits``() =
    let rounding = new RoundingBuilder(5)
    rounding {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    } |> should (equalWithin 0.00001) 0.04762

let roundPI roundTo =
    let createRounding roundTo = new RoundingBuilder(roundTo)
    createRounding(roundTo) {
        return Math.PI
    }

[<Test>]
let ``round PI to 0 digits``() = roundPI 0 |> should equal 3

[<Test>]
let ``round PI to 1 digits``() = roundPI 1 |> should (equalWithin 0.1) 3.1

[<Test>]
let ``round PI to 2 digits``() = roundPI 2 |> should (equalWithin 0.01) 3.15

let checkRound (number1: float) (number2: float) =
    let rand = new Random()
    let precision = rand.Next(0, 15)
    let result = Math.Round(number1 / number2, precision)
    let rounding = new RoundingBuilder(precision)

    rounding {
        let! a = number1
        let! b = number2
        return a / b
    } |> should (equalWithin (Math.Pow(0.1, (float)precision))) result

[<Test>]
let ``Check.Quick testing``() = Check.QuickThrowOnFailure checkRound




