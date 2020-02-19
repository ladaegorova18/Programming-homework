module Fibonacci

let rec fibonacci x = 
 if x < 0 then -1
 else if x = 0 then 1 
 else if x = 1 then 1
 else fibonacci(x - 1) + fibonacci(x - 2)