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
    network.Infect()
    network.Start()
    List.exists (fun (x: Computer) -> x.Infected = false) (network.Computers) |> should be True

[<Test>]
let ``Risk is 1 and there is BFS test`` () =
    let computers = List.map (fun (x: OS) -> Computer(x)) [Windows; Windows; Windows]
    let network = LocalNet(Matrix(array2D [[0; 1; 1];
                                            [1; 0; 1];
                                            [1; 1; 0]]), computers)
    network.Infect()
    network.Turn()
    List.exists (fun (x: Computer) -> x.Infected = false) (network.Computers) |> should be False
    
let rnd = new System.Random(1)

let ``Risk is 0.5 and all computers will be infected test`` (n: int)  =
    let absN = System.Math.Abs(n)
    let matrix = Array2D.create n n 1
    let computers = List.init n (fun unit -> Computer(Ubuntu))
    let network = LocalNet(Matrix(matrix), computers)
    network.Infect()
    while (List.exists (fun (x: Computer) -> x.Infected = false) network.Computers) do
        network.Turn()
    List.exists (fun (x: Computer) -> x.Infected = false) (network.Computers) |> should be False

[<Test>]
let ``FsChecking risk is 50% test`` () = Check.QuickThrowOnFailure ``Risk is 1 and there is BFS test``

        
    