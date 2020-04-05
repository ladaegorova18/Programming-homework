module Counter

open System

// Реализовать Workflow, выполняющий математические вычисления с заданной (как аргумент Builder-а) 
//точностью. Например,
//    rounding 3 {
//        let! a = 2.0 / 12.0
//        let! b = 3.5
//        return a / b
//    }
//должно возвращать 0.048
//*/

type RoundingBuilder(roundTo: int) =
    member this.Bind(x, f) = f x
    member this.Return (f) =
        let some = Some(f)
        Math.Round((some.Value: float), roundTo)
        
