open Calculate

// main program
[<EntryPoint>]
let main argv =
    let calculate = new Calculate()
    let result = calculate {
        let! x = "-1"
        let! y = "2"
        let z = x + y
        return z
    }
    printfn "%A" result
    0 // return an integer exit code
