module PhoneBook.Tests

open NUnit.Framework
open FsUnit
open Options

[<Test>]
let ``Adding test`` () = 
    let data = addingData ("Sovenok", "2520") Seq.empty
    data |> should contain ("Sovenok", "2520")

[<Test>]
let ``Read from file test`` () = 
    let data = readingFromFile "test.txt" Seq.empty
    data |> should contain ("olya", "12345")

[<Test>]
let ``Find name by phone test`` () =
    let seq = Seq.empty |> addingData ("John Lennon", "744-444") |> addingData ("Brad Pitt", "992-433");
    let data = findingByPhone "744-444" seq
    Seq.contains ("John Lennon", "744-444") data |> should be True
    Seq.length data |> should equal 1

[<Test>]
let ``Find phone by name test`` () =
    let seq = Seq.empty |> addingData ("John Lennon", "744-444") |> addingData ("Brad Pitt", "992-433");
    let data = findingByName "Brad Pitt" seq
    Seq.contains ("Brad Pitt", "992-433") data |> should be True
    Seq.length data |> should equal 1