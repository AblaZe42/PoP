type car (fuelEconomy : int) =
    let mutable fuel = 0
    member this.addGas (fuelIncrease) =
        fuel <- fuel + fuelIncrease
    member this.gasLeft
        with get() = fuel
    member this.drive (distance) =
        fuel <- fuel - fuelEconomy * distance / 100

printfn "Test car"
let something = car(2)
printfn "gasLeft: %A" (something.gasLeft)
printfn "addGas (10)"
something.addGas (10)
printfn "gasLeft: %A" (something.gasLeft)
something.drive (100)
printfn "gasLeft: %A" (something.gasLeft)

type Assert =
    static member test  (argument : string) (a:int) (b:int) =
        let mutable check = ""
        if a = b 
        then
            check <- "Pass"
        else
            check <- "fail"
        printfn "%A:  %s" check argument

printfn ""
printfn "test Assert"
let car1 = car(10)
printfn "gasLeft: %A" (car1.gasLeft)
car1.addGas (100)
Assert.test "gassLeft () - Full ?" car1.gasLeft 100
car1.drive (50)
Assert.test "gassLeft () - Full ?" car1.gasLeft 100