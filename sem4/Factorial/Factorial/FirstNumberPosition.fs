module FirstNumberPosition

let firstNumberPosition n ls = 
    let rec recPosition i ls = 
        match ls with
        | [] -> None
        | head :: tail when n = head -> Some(i)
        | head :: tail -> recPosition (i + 1) tail
    recPosition 0 ls
