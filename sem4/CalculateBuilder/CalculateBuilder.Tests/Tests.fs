module CalculateBuilder.Tests

open NUnit.Framework
open Calculate
open FsUnit
open FsCheck

let calculate = new Calculate()

[<Test>]
let ``should equal Some(3)``() =
    let result = calculate {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    } 
    Assert.AreEqual(result, Some 3)
    
[<Test>]
let ``should equal Some(-2)``() =
    let result = calculate {
        let! x = "-1"
        let! y = "2"
        let z = x * y
        return z
    } 
    Assert.AreEqual(result, Some -2)

[<Test>]
let ``should be None``() =
    let result = calculate {
        let! x = "1"
        let! y = "Ú"
        let z = x + y
        return z
    }
    Assert.IsTrue(result.IsNone)

[<Test>]
let ``should be None too``() =
    let result = calculate {
        let! x = "skazka"
        let! y = "unison"
        let z = x + y
        return z
    } 
    Assert.IsTrue(result.IsNone)

let calc number1 number2 =
    let result = calculate {
        let! x = number1.ToString()
        let! y = number2.ToString()
        let z = x - y
        return z
    }
    Assert.AreEqual(result, Some (number1 - number2))   

let wrongCalc (number: int) =
    let result = calculate {
        let! x = number.ToString()
        let! y = "quarantine"
        let z = x + y
        return z
    }
    Assert.IsTrue(result.IsNone)  

[<Test>]
let ``FsChecking``() = Check.QuickThrowOnFailure calc

[<Test>]
let ``FsChecking with wrong symbol``() = Check.QuickThrowOnFailure wrongCalc

