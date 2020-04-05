open System

open Counter

[<EntryPoint>]
let main argv =
    let rounding = new RoundingBuilder();
    let result = rounding 3 {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }
    printfn "%f" result
    0 
