module FirstNumberPosition

let rec firstNumberPosition n i ls = 
 if (i = List.length(ls) || ls = []) then -1
 else if (ls.Item(i) = n) then i
 else firstNumberPosition n (i + 1) ls