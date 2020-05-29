module Computer

/// Виды операционных систем в сети
type OS =
    | Windows 
    | Linux
    | Ubuntu

/// Сопоставляет индексу ОС
let matchOS index =
    match index with 
    | 1 -> Windows
    | 2 -> Linux
    | _ -> Ubuntu

/// Риск заражения для каждой ОС
let infectionRisk (os: OS) =
    match os with 
    | Windows -> 1.0
    | Linux -> 0.0
    | Ubuntu -> 0.5

/// Компьютер в ОС
type Computer (os: OS) =
    let mutable infected = false
    member pc.Risk = infectionRisk os
    member pc.Infected 
        with get () = infected
        and set value = infected <- value