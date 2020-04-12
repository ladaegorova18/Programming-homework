module MapMultiple

/// takes list and number and multiples all elements to number
let mapMultiple1 x l = List.map (fun y -> y * x) l

let mapMultiple2 (x: int) (l: int list) = List.map (fun y -> y * x) l

let mapMultiple3 x: int list -> int list = List.map (fun y -> y * x)

let mapMultiple4 x: int list -> int list = List.map ((*) x)

let mapMultiple5: int -> int list -> int list = List.map << (*)