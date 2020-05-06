module Calculate

open System

/// try to convert string to int number
let convert s = 
    match Int32.TryParse(s: string) with
    | true, a -> Some a
    | _ -> None

/// calculates expressions as strings
type Calculate() =
    member this.Bind(s, f) =
        match convert s with
        | Some a -> f a
        | None -> None
    member this.Return(x) = 
        Some x
        