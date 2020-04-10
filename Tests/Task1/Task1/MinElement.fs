module MinElement

/// Минимальное из двух чисел
let minimal a b = if a < b then a else b

/// Ищет минимальный элемент в списке
let minElement list =
    let minValueElement list = List.fold minimal (List.head list) list
    match list with
    | [] -> failwith "List is empty!"
    | _ -> minValueElement list