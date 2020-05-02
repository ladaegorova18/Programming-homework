module Menu

open System
open Options

/// Приветственный текст
let mainText() =
    Console.WriteLine("Добро пожаловать в телефонный справочник! Нажмите:");
    Console.WriteLine("1, чтобы выйти");
    Console.WriteLine("2, чтобы добавить запись (имя и телефон)");
    Console.WriteLine("3, чтобы найти телефон по имени");
    Console.WriteLine("4, чтобы найти имя по телефону");
    Console.WriteLine("5, чтобы вывести всё текущее содержимое базы");
    Console.WriteLine("6, сохранить текущие данные в файл");
    Console.WriteLine("7, считать данные из файла");

/// Главное меню
let mainMenu() =
    let rec options seq = 
        mainText();
        let key = Console.ReadKey().KeyChar;
        Console.WriteLine();
        match key with
        | '1' -> quit();
        | '2' -> options(adding(seq));
        | '3' -> options(findPhoneByName(seq));
        | '4' -> options(findNameByPhone(seq));
        | '5' -> options(printBase(seq));
        | '6' -> options(saveToFile(seq));
        | '7' -> options(readFromFile(seq));
        | _ -> options(reset(seq));
    options Seq.empty

