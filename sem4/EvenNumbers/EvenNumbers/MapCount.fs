module MapCount

/// returns count of even numbers in list using list.map
let mapCount list =
    List.sum <| List.map (fun x -> abs((x + 1) % 2)) list
    
