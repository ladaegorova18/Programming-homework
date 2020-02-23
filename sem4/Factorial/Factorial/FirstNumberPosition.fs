module FirstNumberPosition

let firstNumberPosition n ls = 
    let rec recPosition i = 
        match ls with
        | [] -> None
        | head :: tail when n = head -> Some(i)
        | _ -> recPosition (i + 1)
    recPosition 0
