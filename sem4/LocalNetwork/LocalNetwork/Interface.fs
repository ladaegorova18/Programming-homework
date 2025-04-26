module Interface

open System
open Computer
open Network

/// Ввод матрицы с консоли
let enterMatrix n =
    let rec recEnter n =
        printfn "Введите матрицу смежности связей между компьютерами:"
        let mutable matrix: int[,] = Array2D.zeroCreate n n
        for j in 0 .. n - 1 do
            let line = List.map (fun (x: string) -> Int32.TryParse(x)) (Array.toList <| Console.ReadLine().Split(' '))
            for i in 0 .. n - 1 do
                if (List.item i line |> fst) then
                    Array2D.set matrix i j (List.item i line |> snd)
        if (Matrix(matrix).IsSquared && Matrix(matrix).Symmetric) then Matrix(matrix)
        else
            printfn "Попробуйте снова!"
            recEnter n
    recEnter n

/// Меню общения с пользователем
let menu () =
    printfn "Это модель локальной сети. Введите число компьютеров:"
    let n = Int32.Parse <| Console.ReadLine()
    let matrix = enterMatrix n

    printfn "Введите данные о компьютерах: операционные системы в виде строки чисел."
    printfn "1 - Windows; 2 - Linux; 3 - DOS"
    printfn "Пример: если в сети 3 компьютера, то ввод должен быть, например, таким: '1 1 2'"
    let line = Array.toList <| Console.ReadLine().Split(' ')
    let computers = List.map (fun (x: string) -> Computer (matchOS <| Int32.Parse(x))) line

    printfn "Нажмите любую клавишу, чтобы начать работу сети"
    Console.ReadLine() |> ignore
    let network = LocalNet(matrix, computers)
    network.Print()
    network.InfectOneRandomComputer()
    network.Start()
