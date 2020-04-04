open Checker

[<EntryPoint>]
let main argv =
    let line = "[[[()]]]"
    printfn "%A" <| bracketsChecker line
    0 
