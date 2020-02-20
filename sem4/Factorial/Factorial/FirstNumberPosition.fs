module FirstNumberPosition

let firstNumberPosition n ls = 
    let rec recPosition n i ls = 
        if (i = List.length(ls) || ls = []) then None
        else if (ls.Item(i) = n) then Some(i)
        else recPosition n (i + 1) ls
    recPosition n 0 ls