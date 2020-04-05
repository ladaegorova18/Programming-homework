open System

open Counter

// main program
[<EntryPoint>]
let main argv =
    let rounding = new RoundingBuilder(3);
    let result = rounding {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }
    printfn "%f" result
    0 
