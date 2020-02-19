module ListOfPows

let listOfPows n m = 
 if n < 0 || m < 0 then []
 else List.init m (fun i -> pown 2 (n + i))
