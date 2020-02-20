module FactorialNumber

let factorial x = 
    let rec recFactorial x i acc =
        if x < 0 then None 
        else if i = x + 1 then Some(acc) 
        else recFactorial x (i + 1) (acc * i) 
    (recFactorial x 1 1).Value