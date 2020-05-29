module LocalNetwork.Tests

open NUnit.Framework
open FsUnit
open Network

let testCases = 
    [
        array2D [[0; 1; 0];
        [1; 0; 1];
        [0; 1; 0]], [Computer(Linux); Computer(Linux); Computer(Linux)], false

        array2D [[0; 1; 0];
        [1; 0; 1];
        [0; 1; 0]], [Computer(Windows); Computer(Windows); Computer(Windows)], true
    ] |> List.map (fun (matrix, systems, result) -> TestCaseData(matrix, systems, result))
    
[<Test>]
[<TestCaseSource("testCases")>]
let firstTest matrix systems result =
    let network = LocalNet(Matrix(matrix), systems)
    network.Infect()
    network.Start()
    List.exists (fun (x: Computer) -> x.Infected = false) (network.Computers) |> should be result

//[<Test>]
//let radicalCasesTest () = 
//    let computers = List.map (fun (x: OS) -> Computer(x)) [Linux; Linux]
//    let network = LocalNet(Matrix(array2D [ [ 1; 1]; [1; 1] ]), computers)
//    network.Infect()
//    network.Start()
//    List.exists (fun (x: Computer) -> x.Infected = false) (network.Computers) |> should be True


//[<Test>]
//let AnotherRadicalCasesTest () = 
//    let computers = List.map (fun (x: OS) -> Computer(x)) [Windows; Windows]
//    let network = LocalNet(Matrix(array2D [ [ 1; 1]; [1; 1] ]), computers)
//    network.Infect()
//    network.Start()
//    List.exists (fun (x: Computer) -> x.Infected = false) (network.Computers) |> should be False
