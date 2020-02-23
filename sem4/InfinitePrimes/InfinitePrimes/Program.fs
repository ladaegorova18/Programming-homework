// Learn more about F# at http://fsharp.org

let matcher n =
    let rec check i =
        i > n / 2 || ((n % i <> 0) && check (i + 1))
    match n with
    | _ when n < 2 -> false
    | _ -> check 2

[<EntryPoint>]
let main argv =
    printfn "%A" <| matcher 6
    printfn "Hello World from F#!"
    0 // return an integer exit code
