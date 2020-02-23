module FoldCount

// returns count of even numbers in list using list.fold
let foldCount list = 
    List.fold (fun acc x -> abs((x + 1) % 2) + acc) 0 list
