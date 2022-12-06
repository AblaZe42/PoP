type student (aName : string, n : int) =
    //Members
    member this.name = aName
    member this.n    = n

let student1 = student ("Jens", 0)
let student2 = student ("Jackob", 0)

printfn "%A %A" student1.name student2.name