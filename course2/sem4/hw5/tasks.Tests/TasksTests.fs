module Tests

open NUnit.Framework
open tasks.task1
open tasks.task2
open tasks.task3
open FsCheck

let records = [record("Pavel", "89213636398"); record("Sergey", "89213457665")]
let stringRecords = ["Sergey 89213457665"; "Pavel 89213636398"]

[<Test>]
let ``Save & load test`` () = 
    save "db.txt" records (*creates file here: hw5\tasks.Tests\bin\Debug\netcoreapp2.0*)
    let actual = load "db.txt"
    let expected = records
    Assert.AreEqual(expected.ToString(), actual.ToString())

[<Test>]
let ``Records to string tets`` () = 
    let actual  = recordsToString records
    let expected = stringRecords
    Assert.AreEqual(actual, expected)

[<Test>]
let ``Strings to records`` () = 
    let actual = recordsFromString stringRecords
    let expected = records
    Assert.AreEqual(actual.ToString(), expected.ToString())

[<Test>]
let ``Brackets test1`` () = 
    let s =  "((((((((()()()()())))((((((((()))"
    let expected = false
    let actual = check s
    Assert.AreEqual(expected, actual)

[<Test>]
let ``Brackets test2`` () = 
    let s = "(��������)[�����]{�������������}"
    let expected = true
    let actual = check s
    Assert.AreEqual(expected, actual)

[<Test>]
let ``Brackets test3`` () = 
    let s = "�������� ����� �������������"
    let expected = true
    let actual = check s
    Assert.AreEqual(expected, actual)

[<Test>]
let ``Brackets test4`` () = 
    let s = ""
    let expected = true
    let actual = check s
    Assert.AreEqual(expected, actual)

[<Test>]
let ``Add record test`` () = 
    let actual = addRecord ("Victor") ("89214332287") records
    let expected = "Victor 89214332287"
    Assert.AreEqual(actual.[0].ToString(), expected)

[<Test>]
let ``Find phone number by name`` () = 
    let actual = findByName "Pavel" records
    let expected = "89213636398"
    Assert.AreEqual(actual, expected)

[<Test>]
let ``Find name by phone number`` () = 
    let actual = findByNumber "89213457665" records
    let expected = "Sergey"
    Assert.AreEqual(actual, expected)

[<Test>]
let ``functionsTest1`` () = 
    Check.Quick (fun x y -> func'1 x y = func'0 x y)

[<Test>]
let ``functionsTest2`` () = 
    Check.Quick (fun x y -> func'2 x y = func'0 x y)

[<Test>]
let ``functionsTest3`` () = 
    Check.Quick (fun x y -> func'3 x y = func'0 x y)

[<Test>]
let ``functionsTest4`` () = 
    Check.Quick (fun x y -> func'4 x y = func'0 x y)

[<Test>]
let ``functionsTest5`` () = 
    Check.Quick (fun x y -> func'5 x y = func'0 x y)
