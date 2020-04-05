module SpecifiedAccuracyTests

open NUnit.Framework
open Counter

let rounding = new RoundingBuilder(3)

[<Test>]
let ``should round to 3 digits``() =
    rounding {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    } = 0.048



