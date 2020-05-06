module Options

open System.IO

/// Добавление без повторения записей
let addingData pair seq = 
    match Seq.contains pair seq with
        | false -> Seq.append seq [pair]
        | true -> seq

/// Поиск в базе по имени
let findingByName name seq = Seq.filter (fun x -> fst x = name) seq

/// Поиск в базе по телефону
let findingByPhone phone seq = Seq.filter (fun x -> snd x = phone) seq

/// Сохранить в файл
let savingToFile input seq =
    let path = Path.Combine(Directory.GetCurrentDirectory(), input)
    let toWrite = Seq.toArray seq |> Seq.map (fun x -> fst x + "\t" + snd x)
    File.WriteAllLines (path, toWrite)
    
/// Прочитать из файла
let readingFromFile file seq =
    let content = File.ReadLines(file) |> Seq.filter(fun x -> x |> System.String.IsNullOrWhiteSpace |> not) 
                    |> Seq.map(fun x -> x.Split([|'\t'|], System.StringSplitOptions.RemoveEmptyEntries)) 
                    |> Seq.map(fun x -> (x.[0], x.[1]))
    let newSeq = Seq.append seq content
    newSeq
