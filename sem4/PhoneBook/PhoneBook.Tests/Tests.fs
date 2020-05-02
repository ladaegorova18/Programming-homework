module PhoneBook.Tests

open NUnit.Framework
open Options

[<Test>]
let ``Adding test`` () = 
    let data = addingData ("Sovenok", "2520") Seq.empty
    Assert.IsTrue(Seq.contains ("Sovenok", "2520") data)

[<Test>]
let ``Read from file test`` () = 
    let data = readingFromFile "test.txt" Seq.empty
    Assert.IsTrue(Seq.contains ("olya", "12345") data)

[<Test>]
let ``Find name by phone test`` () =
    let seq = Seq.empty |> addingData ("John Lennon", "744-444") |> addingData ("Brad Pitt", "992-433");
    let data = findingByPhone "744-444" seq
    Assert.IsTrue(Seq.contains ("John Lennon", "744-444") data)
    Assert.AreEqual(1, Seq.length data)

[<Test>]
let ``Find phone by name test`` () =
    let seq = Seq.empty |> addingData ("John Lennon", "744-444") |> addingData ("Brad Pitt", "992-433");
    let data = findingByName "Brad Pitt" seq
    Assert.IsTrue(Seq.contains ("Brad Pitt", "992-433") data)
    Assert.AreEqual(1, Seq.length data)