module Options

open System
open System.IO

// Печатает пару
let print tuple =
    match tuple with 
    | (name, phoneNumber) -> printfn "Имя: %A Номер телефона: %A" name phoneNumber

// Выход из справочника
let quit() =
    Console.WriteLine("До свидания!");
    Environment.Exit(0);

// Еще попытка при неправильном вводе символа
let reset seq = 
    Console.WriteLine("Попробуйте снова :)");
    seq

// Добавление без повторения записей
let addingData pair seq = //Seq.append seq pair
    match Seq.contains pair seq with
        | false -> Seq.append seq [pair]
        | true -> seq

// Считывание записей для добавления
let adding seq =
    Console.WriteLine("Это меню добавления записи.");
    Console.WriteLine("Введите имя:");
    let name = Console.ReadLine();
    Console.WriteLine("Введите номер телефона:");
    let phoneNumber = Console.ReadLine();
    let newSeq = addingData (name, phoneNumber) seq
    Console.WriteLine("Запись добавлена!");
    newSeq

// Поиск в базе по имени
let findingByName name seq = (Seq.filter (fun x -> fst x = name) seq)
    
// Найти телефоны в справочнике по именам
let findPhoneByName seq =
    Console.WriteLine("Чтобы найти телефон по имени, введите имя:");
    let name = Console.ReadLine();
    Seq.iter print (findingByName name seq)
    seq

// Поиск в базе по телефону
let findingByPhone phone seq = (Seq.filter (fun x -> snd x = phone) seq)
    
 //Найти имя в справочнике по телефону 
let findNameByPhone seq =
    Console.WriteLine("Чтобы найти имя по телефону, введите телефон:");
    let phone = Console.ReadLine();
    Seq.iter print (findingByPhone phone seq)
    seq

// Вывести все записи
let printBase seq =
    Seq.iter print seq
    seq

// Сохранить записи в файл
let saveToFile seq =
    Console.WriteLine("Введите название файла:");
    let input = Console.ReadLine();
    let path = Path.Combine(Directory.GetCurrentDirectory(), input);
    let toWrite = Seq.toArray (seq |> Seq.map (fun x -> fst x + "\t" + snd x));
    File.WriteAllLines (path, toWrite);
    Console.WriteLine("Данные записаны!");
    seq
    
// Чтение из файла
let readingFromFile file seq =
    let content = IO.File.ReadLines(file) |> Seq.filter(fun x -> x |> System.String.IsNullOrWhiteSpace |> not) 
                    |> Seq.map(fun x -> x.Split([|'\t'|], System.StringSplitOptions.RemoveEmptyEntries)) 
                    |> Seq.map(fun x -> (x.[0], x.[1]));
    let newSeq = Seq.append seq content
    newSeq

// Считать записи из файла в справочник
let readFromFile seq =
    Console.WriteLine("Введите название файла:");
    let file = Console.ReadLine();
    match File.Exists(file) with
    | false ->
        Console.WriteLine("Файл не найден!");
        seq
    | true ->
        readingFromFile file seq