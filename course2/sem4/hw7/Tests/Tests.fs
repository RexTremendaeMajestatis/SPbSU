module Tests

open System
open Xunit
open hw7.task1
open hw7.task2

[<Fact>]
let ``Rounding test1``() =
    let actual = 
        RoundingBuilder(3) {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }
    let expected =  0.048
    Assert.Equal(expected, actual)

[<Fact>]
let ``Rounding test2``() =
    let actual = 
        RoundingBuilder(2) {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }
    let expected =  0.05
    Assert.Equal(expected, actual)

[<Fact>]
let ``Rounding test3``() =
    let actual = 
        RoundingBuilder(1) {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }
    let expected =  0.1
    Assert.Equal(expected, actual)

[<Fact>]
let ``Calculating test1``() = 
    let actual =
        CalculatingBuilder() {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
        }
    let expected = Some(3)
    Assert.Equal(actual, expected)

[<Fact>]
let ``Calculating test2``() = 
    let actual =
        CalculatingBuilder() {
            let! x = "1"
            let! y = "�"
            let z = x + y
            return z
        }
    let expected = None
    Assert.Equal(actual, expected)

