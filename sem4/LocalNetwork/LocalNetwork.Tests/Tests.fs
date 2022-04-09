module LocalNetwork.Tests

open NUnit.Framework
open FsUnit
open FsCheck
open Computer
open Network

[<Test>]
let ``there are uninfected computers test`` () = 
    let computers =  List.map (fun (x: OS) -> Computer(x)) [Linux; Linux; Linux]
    let network = LocalNet(Matrix(array2D [[0; 1; 0];
                                            [1; 0; 1];
                                            [0; 1; 0]]), computers)
    network.InfectOneRandomComputer()
    network.Start()
    List.exists (fun (x: Computer) -> x.Infected = false) (network.Computers) |> should be True

[<Test>]
let ``Risk is 1 and there is BFS test`` () =
    let computers = List.init 7 (fun unit -> Computer(Windows)) 
    let network = LocalNet(Matrix(array2D [ [0; 1; 1; 1; 0; 0; 0];
                                            [1; 0; 0; 0; 1; 1; 0];
                                            [1; 0; 0; 0; 0; 0; 1];
                                            [1; 0; 0; 0; 0; 0; 0];
                                            [0; 1; 0; 0; 0; 0; 0];
                                            [0; 1; 0; 0; 0; 0; 0];
                                            [0; 0; 1; 0; 0; 0; 0];]), computers)   ///          1
    let checkInfected index = network.Computers.[index - 1].Infected               ///        2   3
    for i in 2 .. computers.Length do checkInfected i |> should be False           ///      5  6    7  
                                                                                   ///    network scheme
    network.InfectDefinite 1 /// заражаем компьютер номер 1
    network.Turn() 

    for i in 2 .. 4 do checkInfected i |> should be True  /// на первом шаге заражаем компьютеры 2-4
    for i in 5 .. 7 do checkInfected i |> should be False

    network.Turn() /// на втором все остальные
    List.exists (fun (x: Computer) -> x.Infected = false) (network.Computers) |> should be False
    
let rnd = new System.Random(1)

let ``Risk is 0.5 and all computers will be infected test`` (n: int) =
    if (n <> 0) then
        let absN = System.Math.Abs(n)
        let matrix = Array2D.create absN absN 1
        let computers = List.init absN (fun unit -> Computer(DOS))
        let network = LocalNet(Matrix(matrix), computers)
        network.InfectOneRandomComputer()
        while (List.exists (fun (x: Computer) -> x.Infected = false) network.Computers) do
            network.Turn()
        List.exists (fun (x: Computer) -> x.Infected = false) (network.Computers) |> should be False

[<Test>]
let ``FsChecking risk is 50% test`` () = Check.QuickThrowOnFailure ``Risk is 0.5 and all computers will be infected test``

        
    