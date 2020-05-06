module Menu

open System
open Options
open System.IO

/// Печатает пару
let print seq =
    let printTuple tuple =
        match tuple with 
        | (name, phoneNumber) -> printfn "Имя: %A Номер телефона: %A" name phoneNumber
    Seq.iter printTuple seq

/// Выход из справочника
let quit() =
    Console.WriteLine("До свидания!")

/// Считывание записей для добавления
let adding seq =
    Console.WriteLine("Это меню добавления записи.")
    Console.WriteLine("Введите имя:")
    let name = Console.ReadLine()
    Console.WriteLine("Введите номер телефона:")
    let phoneNumber = Console.ReadLine()
    let newSeq = addingData (name, phoneNumber) seq
    Console.WriteLine("Запись добавлена!")
    newSeq 
    
/// Найти телефоны в справочнике по именам
let findPhoneByName seq =
    Console.WriteLine("Чтобы найти телефон по имени, введите имя:")
    let name = Console.ReadLine()
    print <| findingByName name seq
    seq

/// Найти имя в справочнике по телефону 
let findNameByPhone seq =
    Console.WriteLine("Чтобы найти имя по телефону, введите телефон:")
    let phone = Console.ReadLine()
    print <| findingByPhone phone seq
    seq

/// Вывести все записи
let printBase seq =
    print seq
    seq

/// Сохранить записи в файл
let saveToFile seq =
    Console.WriteLine("Введите название файла:")
    let input = Console.ReadLine()
    savingToFile input seq
    Console.WriteLine("Данные записаны!")
    seq

/// Считать записи из файла в справочник
let readFromFile seq =
    Console.WriteLine("Введите название файла:")
    let file = Console.ReadLine()
    match File.Exists(file) with
    | false ->
        Console.WriteLine("Файл не найден!")
        seq
    | true ->
        readingFromFile file seq
    
/// Еще попытка при неправильном вводе символа
let reset seq = 
    Console.WriteLine("Попробуйте снова :)")
    seq

/// Приветственный текст
let mainText() =
    Console.WriteLine("Добро пожаловать в телефонный справочник! Нажмите:")
    Console.WriteLine("1, чтобы выйти")
    Console.WriteLine("2, чтобы добавить запись (имя и телефон)")
    Console.WriteLine("3, чтобы найти телефон по имени")
    Console.WriteLine("4, чтобы найти имя по телефону")
    Console.WriteLine("5, чтобы вывести всё текущее содержимое базы")
    Console.WriteLine("6, сохранить текущие данные в файл")
    Console.WriteLine("7, считать данные из файла")
    
/// Главное меню
let mainMenu() =
    let rec options seq = 
        mainText()
        let key = Console.ReadKey().KeyChar
        Console.WriteLine()
        match key with
        | '1' -> quit()
        | '2' -> options(adding(seq))
        | '3' -> options(findPhoneByName(seq))
        | '4' -> options(findNameByPhone(seq))
        | '5' -> options(printBase(seq))
        | '6' -> options(saveToFile(seq))
        | '7' -> options(readFromFile(seq))
        | _ -> options(reset(seq))
    options Seq.empty

