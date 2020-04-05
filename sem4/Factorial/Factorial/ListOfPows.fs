module ListOfPows

open ListReverse

let listOfPows n m = 
    let rec recListOfPows acc i currPow = 
        if i < 0 then []
        else if i = 0 then acc
        else recListOfPows (currPow :: acc) (i - 1) (currPow * 2)
    listReverse (recListOfPows [] m (pown 2 n))