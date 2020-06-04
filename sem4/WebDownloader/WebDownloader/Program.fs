open System

open Downloader

/// Вводим адрес с консоли и скачиваем все страницы, на которые ссылается страница по этому адресу
[<EntryPoint>]
let main argv =
    printfn "Введите адрес:"
    let address = Console.ReadLine()
    let content = address |> fetchAsync |> Async.RunSynchronously

    let links = findLinks content.Value
    do printfn "This page has %d links" <| links.Length

    let result = getAllPages content
    List.iter (fun x -> printfn "%s" x) result
    0