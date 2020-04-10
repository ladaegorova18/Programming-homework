module Picture
    
/// Создает пустую строку со звездочками по бокам
let rec centralLine acc line n =
    match acc with
    | value when value = n -> centralLine (acc - 1) "*" n
    | 1 -> (line + "*")
    | _ -> centralLine (acc - 1) (line + " ") n

/// Создает строку из звездочек
let rec starLine acc line = if acc > 0 then starLine (acc - 1) (line + "*") else line

/// Создает квадрат 
let square (n: int) =
    let rec makeStringList acc list =
        match acc with
        | value when value = n -> makeStringList (acc - 1) [(starLine n "")]
        | value when value < 1 -> failwith "Введите неотрицательное число!"
        | 1 -> (list @ [starLine n ""])
        | _ -> makeStringList (acc - 1) (list @ [centralLine n "" n])
    makeStringList n []

/// Печатает квадрат из звездочек нужного размера
let print n =
    let rec recPrint list =
        match list with 
        | [] -> printfn ""
        | [x] -> printfn "%s" list.Head
        | _ -> printfn "%s" list.Head
               recPrint list.Tail
    recPrint (square n)