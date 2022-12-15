type employee (na : string) = 
    let mutable name = na
    static let mutable nextNumber = 1
    static member getNumber =
        let mutable number = nextNumber
        do nextNumber <- nextNumber + 1
        number
    member this.getName =
        name

type productionWorker (na : string, sf : int, pr: int) =
    inherit employee (na)
    let mutable shiftNumber = sf
    let mutable payRate = pr
    member this.getPayRate =
        payRate
    member this.getNumber_ =
        employee.getNumber
    member this.getShiftNumber =
        shiftNumber

let a = productionWorker("Jens", 1, 4)
let b = productionWorker("Jonas", 2, 4)
let c = productionWorker("Jannic", 1, 4)
printfn "%A %A" a.getShiftNumber a.getNumber_
printfn "%A %A" b.getShiftNumber b.getNumber_
printfn "%A %A" c.getShiftNumber c.getNumber_