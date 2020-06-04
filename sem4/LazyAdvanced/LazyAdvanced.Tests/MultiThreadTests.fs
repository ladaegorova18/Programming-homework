module LazyAdvanced.MultiThreadTests

/// Тесты для MultiThreadedLazy и LockFreeLazy

open NUnit.Framework
open FsUnit

open LazyFactory
open System.Threading

[<Test>]
let ``MultiThreadedLazy work test``() =
    let mutable result = 0
    let multiLazy = LazyFactory<int>.CreateMultiThreadedLazy(fun unit -> Interlocked.Increment(ref result))
    for i in 1 .. 1000 do
        multiLazy.Get() |> should equal 1

[<Test>]
let ``MultiThreadedLazy string test``() =
    let multiLazy = LazyFactory<string>.CreateMultiThreadedLazy(fun unit -> "doctor " + "who")
    multiLazy.Get() |> should equal "doctor who"
    
[<Test>]
let ``LockFreeLazy work test``() =
    let mutable result = 0
    let lockFreeLazy = LazyFactory<int>.CreateLockFreeLazy(fun unit -> Interlocked.Increment(ref result))
    for i in 1 .. 1000 do
        lockFreeLazy.Get() |> should equal 1

[<Test>]
let ``LockFreeLazy string test``() =
    let lockFreeLazy = LazyFactory<string>.CreateLockFreeLazy(fun unit -> "purple " + "unicorn")
    lockFreeLazy.Get() |> should equal "purple unicorn"

[<Test>]
let ``MultiThreadedLazy works with a lot of threads test`` () =
    let multiLazy = LazyFactory<(obj * list<int>)>.CreateMultiThreadedLazy(fun unit -> (new obj(), [1; 2; 3]))
    let result = multiLazy.Get()
    for i in 1 .. 1000 do 
        ThreadPool.QueueUserWorkItem(fun unit -> multiLazy.Get() = result |> should be True) |> ignore

[<Test>]
let ``LockFreeLazy works with a lot of threads test`` () =
    let lockFreeLazy = LazyFactory<(obj * list<int>)>.CreateLockFreeLazy(fun unit -> (new obj(), [1; 2; 3]))
    let result = lockFreeLazy.Get()
    for i in 1 .. 1000 do 
        ThreadPool.QueueUserWorkItem(fun unit -> lockFreeLazy.Get() = result |> should be True) |> ignore