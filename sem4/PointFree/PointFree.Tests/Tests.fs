module PointFree.Tests

open NUnit.Framework
open MapMultiple
open FsCheck

let mapTest1 number list = mapMultiple1 number list = mapMultiple2 number list
let mapTest2 number list = mapMultiple2 number list = mapMultiple3 number list
let mapTest3 number list = mapMultiple3 number list = mapMultiple4 number list
let mapTest4 number list = mapMultiple4 number list = mapMultiple5 number list

[<Test>]
let ``first and second functions are equal``() = Check.QuickThrowOnFailure mapTest1

[<Test>]
let ``second and third functions are equal``() = Check.QuickThrowOnFailure mapTest2

[<Test>]
let ``third and fourth functions are equal``() = Check.QuickThrowOnFailure mapTest3

[<Test>]
let ``fourth and fifth functions are equal``() = Check.QuickThrowOnFailure mapTest4