type drone (start : float*float, dest : float*float, speed : float) =
    let mutable position  = start
    let destination = dest
    let mutable speed = speed
    member this.fly =
        let route = ((fst destination) - (fst position), (snd destination) - (snd position))
        let routeLength = sqrt(((fst route) ** 2) + ((snd route) ** 2))
        let timeFly = routeLength / (speed/100.) 
        let moverPrTurn = ((fst route) / timeFly), ((snd route) / timeFly)
        position <- ((fst position) + fst (moverPrTurn)), ((snd position) + snd (moverPrTurn))
        if fst route <= fst moverPrTurn
        then
            position <- destination
            position
        else
            position
    member this.aDestination =
        if destination = position
        then true
        else false

let drone1 = drone((5.,5.),(10.,10.), 100.)
printfn "%A" (drone1.fly)
printfn "%A" (drone1.fly)
printfn "%A" (drone1.fly)
printfn "%A" (drone1.fly)
printfn "%A" (drone1.fly)
printfn "%A" (drone1.fly)
printfn "%A" (drone1.fly)
printfn "%A" (drone1.fly)
