type student ( n : string ) =
    let mutable _name = n
    member this.name
        with get () = _name
        and set (m) = _name <- m
    member this.clone () = student (this.name)
    override this.ToString () = _name

let a = student ("Jon") 
let b = a
let c = b.clone ()
b.name <- "Mads" // objects acts like arrays
printfn "a=%A\nb =%A\nc =%A" a b c //objects changes before print

