module HtmlCount.Tests

open NUnit.Framework
open FsUnit
open Downloader

[<Test>]
let ``real address test`` () =
    let address = "https://github.com/"
    let content = address |> fetchAsync |> Async.RunSynchronously
    let result = getAllPages content
    result.Length |> should greaterThan 0
    result.[0] |> should not' (equal "None")

[<Test>]
let ``wrong address test`` () =
    let address = "invalid url"
    let content = address |> fetchAsync |> Async.RunSynchronously
    let result = getAllPages content
    result.[0] |> should equal "None"
    result.Length |> should equal 1
