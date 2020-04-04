module Fibonacci

let fibonacci x = 
    let rec recFibonacci x acc1 acc2 i =
        if x < 0 then None
        else if i = x + 1 then Some(acc1)
        else recFibonacci x acc2 (acc1 + acc2) (i + 1)
    (recFibonacci x 0 1 0).Value