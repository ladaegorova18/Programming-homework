module MapForTrees.Tests

open NUnit.Framework
open MapTree
open FsUnit

// test cases for TreeMap tests
let testCases =
    [
        (fun x -> x + 1), Tree.Node(5, Tree.Node(3, Tree.Empty, Tree.Empty), Tree.Empty), Tree.Node(6, Tree.Node(4, Tree.Empty, Tree.Empty), Tree.Empty)

    ] |> List.map (fun (func, tree, resultTree) -> TestCaseData(func, tree, resultTree))

[<TestCaseSource("testCases")>]
[<Test>]
let treeMapTest func tree resultTree = 
    let result = mapTree func tree
    result |> should equal resultTree

[<Test>]
let secondTest x = 
    let result = mapTree (fun x -> x + 1) (Tree.Node(5, Tree.Node(3, Tree.Empty, Tree.Empty), Tree.Empty))
    result |>  should equal (Tree.Node(6, Tree.Node(4, Tree.Empty, Tree.Empty), Tree.Empty))