type person (na : string, ad : string, nu : string) = 
    let mutable name = na
    let mutable adress = ad
    let mutable number = nu
    member this.getName =
        name
    member this.getAdress =
        adress
    member this.getNumber =
        number

type costumer (mail: bool, na : string, ad : string, nu : string) =
    inherit person (na, ad, nu)
    static let mutable nextAvailableID = 0
    let mutable onMailList = mail 
    let ID = nextAvailableID
    do nextAvailableID <- nextAvailableID + 1
    member this.id =
        ID
    member this.mailing = onMailList 
    member this.getName = na
    member this.getAdress = ad
    member this.getNumber = nu

let n = costumer (true, "Jens", "adresse1", "12345678")
let x = costumer (false, "Palle", "adresse2", "23456789")
printfn "%A %A %A" n.getName n.id n.mailing
printfn "%A %A %A" x.getName x.id x.mailing