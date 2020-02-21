open ListOfPows

[<EntryPoint>]
let main argv =
    let res = listOfPows 4 6
    printf "%s" (res.Length.ToString())
    printfn "%A" (res.ToString())
    printfn "%d" (res.Item(4))
    printfn "Hello World from F#!"
    0 // return an integer exit code
