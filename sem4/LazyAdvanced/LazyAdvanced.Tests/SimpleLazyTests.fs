module LazyAdvanced.SimpleLazyTests

open NUnit.Framework
open FsUnit

open LazyFactory

[<Test>]
let ``one thread simple test``() =
    let simpleLazy = LazyFactory<float>.CreateSingleThreadedLazy(fun unit -> 0.1)
    simpleLazy.Get() |> should equal 0.1

[<Test>]
let ``one thread null test``() =
    let simpleLazy = LazyFactory<string>.CreateSingleThreadedLazy(fun unit -> null)
    simpleLazy.Get() |> should equal null

[<Test>]
let ``one thread None test``() =
    let simpleLazy = LazyFactory<int option>.CreateSingleThreadedLazy(fun unit -> None)
    simpleLazy.Get() |> should equal None