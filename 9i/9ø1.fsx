type student () =
    let mutable studentName = "Default"
    //Members
    member this.setValue (newValue : string) : unit =
        studentName <- newValue
    member this.getValue () : string = studentName

let student1 = student ()
printfn "%A" (student1.getValue ())
student1.setValue ("Jens")
printfn "%A" (student1.getValue ())