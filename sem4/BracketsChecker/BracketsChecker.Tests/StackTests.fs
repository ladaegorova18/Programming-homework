module Tests.StackTests

open NUnit.Framework
open Stack
open FsUnit

[<Test>]
let ``emptyTest``() = 
    let stack = MyStack.Empty
    stack.EmptyStack |> should be True

[<Test>]
let ``not empty test``() = 
    let stack = MyStack.Empty
    let secondStack = stack.Push('(')
    secondStack.EmptyStack |> should be False

[<Test>]
let ``first empty then not empty test``() = 
    let stack = MyStack.Empty
    let secondStack = stack.Push('(')
    let thirdStack = secondStack.Pop
    thirdStack.EmptyStack |> should be True
