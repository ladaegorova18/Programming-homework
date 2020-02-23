module FilterCount

// returns count of even numbers in list using list.filter
let filterCount list = 
    List.length <| List.filter (fun x -> abs(x) % 2 = 0) list


