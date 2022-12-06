type student () =
    let mutable studentName = "Default"
    //Members
    member this.value
        with get () = studentName
        and set (n : string) = studentName <- n

let student1 = student ()
printfn "%A" (student1.value)
student1.value <- "Jens"
printfn "%A" (student1.value)