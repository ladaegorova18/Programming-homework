module ListReverse

//let rec listReverse list acc =
// if (list = []) then acc
// else if (list = [x]) x :: acc
// else listReverse list.Tail (list.Tail :: acc)

let rec listReverse list acc = 
 match list with 
 | [] -> []
 | [x] -> x :: acc
 | head :: tail -> listReverse tail (head :: acc)