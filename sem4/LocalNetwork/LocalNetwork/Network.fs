module Network

open Computer

/// Тип для ввода матриц смежности
type Matrix (values: int[,]) =
    member matrix.Size = values.[*, 0].Length
    member matrix.Squared  =
        let rows = values.[*, 0].Length
        let cols = values.[0, *].Length
        rows = cols
    member matrix.Item (i, j) = values.[i, j]
    member matrix.Symmetric =
        let mutable symmetric = true
        for i in 0 .. matrix.Size - 1 do
            for j in 0 .. matrix.Size - 1 do
                if (values.[i, j] = values.[j, i]) then symmetric <- false
        symmetric

/// Сама локальная сеть с компьютерами
type LocalNet (m: Matrix, computers: Computer list) =
    let condition infected = if infected then "заражён" else "не заражён"
    let getComputer index = List.item index computers
    let infectedByIndex index = (getComputer index).Infected
    let rnd = new System.Random()
    let step = 3
    let turns = 100
    
    /// Компьютеры в сети
    member net.Computers with get () = computers

    /// Вывод состояния сети на экран
    member net.Print () =
        for i in 0 .. m.Size - 1 do
            for j in 0 .. m.Size - 1 do
                printf "%i " <| m.Item (j, i)
            printfn ""
        printfn ""
        for i in 0 .. m.Size - 1 do
            printfn "Компьютер %i %s" i (condition <| infectedByIndex i)
    
    /// Очередной ход: попытка заразить другие компьютеры
    member net.Turn () =
        for i in 0 .. computers.Length - 1 do
            if infectedByIndex i then do
                for j in 0 .. computers.Length - 1 do
                    if (not <| infectedByIndex j) && m.Item(i, j) = 1 then
                        let procent = rnd.Next(100)
                        if ((float)procent / 100.0) < (getComputer j).Risk then (getComputer j).Infected <- true
    
    /// Заражаем первый случайный компьютер
    member net.Infect () =
        let index = rnd.Next(0, computers.Length - 1)
        (getComputer index).Infected <- true
        printfn "Компьютер %i был заражён" index

    /// Начало цикла работы сети
    member net.Start () =
        let rec recTurns acc =
            if List.exists (fun (x: Computer) -> not <| x.Infected) computers && acc < turns then 
                printfn "Ход %i" acc
                net.Turn()
                if (acc % step = 0) then net.Print()
                recTurns (acc + 1)
            elif acc < turns then 
                printfn "Все компьютеры в сети заражены!"
                net.Print()
            else 
                printfn "В сети остались здоровые компьютеры!"
                net.Print()
        recTurns 0