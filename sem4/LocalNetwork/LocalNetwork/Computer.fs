module Computer

/// Виды операционных систем в сети
type OS =
    | Windows 
    | Linux
    | DOS

/// Сопоставляет индексу ОС
let matchOS index =
    match index with 
    | 1 -> Windows
    | 2 -> Linux
    | _ -> DOS

/// Риск заражения для каждой ОС
let infectionRisk (os: OS) =
    match os with 
    | Windows -> 1.0
    | Linux -> 0.0
    | DOS -> 0.5

/// Компьютер в ОС
type Computer (os: OS) =
    member pc.Risk = infectionRisk os
    member val Infected = false with get, set
    member val InfectedOnThisTurn = false with get, set