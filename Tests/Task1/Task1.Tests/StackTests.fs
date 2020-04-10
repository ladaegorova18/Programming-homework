module StackTests

open NUnit.Framework
open Stack
open FsUnit

[<Test>]
let ``emptyTest`` = 
    let stack = new MyStack<int>()
    stack.Empty

[<Test>]
let ``not empty test`` = 
    let stack = new MyStack<int>()
    stack.Push(6)
    stack.Empty |> should be False

[<Test>]
let ``first empty then not empty test`` = 
    let stack = new MyStack<int>()
    stack.Push(6)
    stack.TryPop() |> ignore
    stack.Empty |> should be True



