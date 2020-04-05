module Calculate

open System

// try to convert string to int number
let convert s = 
    let mutable result = 0
    match Int32.TryParse((s: string), &result) with
    | true -> Some(result)
    | false -> None

// calculates expressions as strings
type Calculate() =
    member this.Bind(s, f) =
        match convert s with
        | None -> None
        | Some a -> f a
    member this.Return(x) = 
        Some x
        