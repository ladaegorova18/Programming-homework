module Program

open ListReverse

[<EntryPoint>]
let main argv =
    let revList = listReverse [3; 2; 1] []
    printfn "%s" (revList.ToString());
    0 // return an integer exit code
