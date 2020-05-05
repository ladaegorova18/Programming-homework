module Counter

open System

/// calculate an expression and round to some decimal places 
type RoundingBuilder(roundTo: int) =
    member this.Bind(x: float, f) = 
        f (Math.Round(x, roundTo))
    member this.Return (f: float) =
        Math.Round(f, roundTo)