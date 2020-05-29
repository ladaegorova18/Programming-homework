module Interface

open System
open Network

let matchOS index =
    match index with 
    | 1 -> Windows
    | 2 -> Linux
    | _ -> Ubuntu

let menu () =
    printfn "Это модель локальной сети. Введите число компьютеров:"
    let n = Int32.Parse <| Console.ReadLine()
    printfn "Введите матрицу смежности связей между компьютерами:"
    let mutable m: int[,] = Array2D.zeroCreate n n
    for j in 0 .. n - 1 do
        let line = List.map (fun (x: string) -> Int32.Parse(x)) (Array.toList <| Console.ReadLine().Split(' '))
        for i in 0 .. n - 1 do
            Array2D.set m i j (List.item i line)

    printfn "Введите данные о компьютерах: операционные системы в виде строки чисел."
    printfn "1 - Windows; 2 - Linux; 3 - Ubuntu"
    printfn "Пример: если в сети 3 компьютера, то ввод должен быть, например, таким: '1 1 2'"
    let line = Array.toList <| Console.ReadLine().Split(' ')
    let computers = List.map (fun (x: string) -> Computer (matchOS <| Int32.Parse(x))) line
    printfn "Нажмите любую клавишу, чтобы начать работу сети"
    let network = LocalNet(Matrix(m), computers)
    network.Print()
    network.Infect()
    network.Start()