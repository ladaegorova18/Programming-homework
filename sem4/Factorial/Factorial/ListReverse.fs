module ListReverse

let listReverse list = 
    let rec accReverse list acc =
        match list with 
        | [] -> []
        | [x] -> x :: acc
        | head :: tail -> accReverse tail (head :: acc)
    accReverse list []