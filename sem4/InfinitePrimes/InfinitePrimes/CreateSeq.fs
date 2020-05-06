module CreateSeq

open System

/// checks if number n is prime
let isPrime n =
    let rec check i =
        i > (int)(Math.Sqrt((float)n)) || ((n % i <> 0) && check (i + 1))
    match n with
    | _ when n < 2 -> false
    | _ -> check 2

/// creates a sequence of prime numbers
let createSeq = Seq.initInfinite id |> Seq.filter isPrime