module MapForTrees.Tests

open NUnit.Framework
open MapTree
open FsUnit

// test cases for TreeMap tests
let testCases =
    [
        (fun x -> x + 1), Node(5, Node(3, Tree.Empty, Tree.Empty), Tree.Empty), 
        Node(6, Node(4, Tree.Empty, Tree.Empty), Tree.Empty)

        (fun x -> x * 3), Tree.Empty, Tree.Empty

        (fun x -> x * 0), Node(400, Node(-400, Tree.Empty, Tree.Empty), Node(9, Tree.Empty, Tree.Empty)), 
        Node(0, Node(0, Tree.Empty, Tree.Empty), Node(0, Tree.Empty, Tree.Empty))

    ] |> List.map (fun (func, tree, resultTree) -> TestCaseData(func, tree, resultTree))

[<TestCaseSource("testCases")>]
[<Test>]
let treeMapTest (func: (int -> int), tree: Tree<int>, resultTree: Tree<int>) = mapTree func tree |> should equal resultTree

let tree = (Node("Ultimate", Node("Question", Node("Of life", Tree.Empty, Tree.Empty), Tree.Empty), Tree.Empty))
let answer = (Node(8, Node(8, Node(7, Tree.Empty, Tree.Empty), Tree.Empty), Tree.Empty))

[<Test>]
let stringTreeMapTest () = mapTree (fun (x: string) -> x.Length) tree |> should equal answer