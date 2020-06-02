module LazyAdvanced.MultiThreadTests

/// Тесты для MultiThreadedLazy и LockFreeLazy

open NUnit.Framework
open FsUnit

open LazyFactory
open System.Threading

[<Test>]
let ``does multi-thread work test``() =
    let mutable result = 0
    let multiLazy = LazyFactory<int>.CreateMultiThreadedLazy(fun unit -> Interlocked.Increment(ref result))
    for i in 1 .. 1000 do
        multiLazy.Get() |> should equal 1

[<Test>]
let ``does lock-free multi-thread work test``() =
    let mutable result = 0
    let multiLazy = LazyFactory<int>.CreateLockFreeLazy(fun unit -> Interlocked.Increment(ref result))
    for i in 1 .. 1000 do
        multiLazy.Get() |> should equal 1

[<Test>]
let ``multi-thread string test``() =
    let multiLazy = LazyFactory<string>.CreateMultiThreadedLazy(fun unit -> "doctor " + "who")
    multiLazy.Get() |> should equal "doctor who"
    