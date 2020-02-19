module FactorialNumber

let rec factorial x = 
 if x < 0 then -1 
 else if x = 0 then 1 
 else factorial(x - 1) * x