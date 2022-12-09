type drone (start : float*float, dest : float*float, speed : float) =
    let mutable position  = start
    let destination = dest
    let mutable speed = speed
    ///
    let mutable test1 = 0.

    let route = ((fst destination) - (fst position), (snd destination) - (snd position))
    let routeLength = sqrt(((fst route) ** 2) + ((snd route) ** 2))
    let timeFly = routeLength / (speed/100.) 
    let moverPrTurn = ((fst route) / timeFly), ((snd route) / timeFly)
    ///
    member this.fly =
        let routeFly = ((fst destination) - (fst position), (snd destination) - (snd position)) 
        let routeLengthFly = sqrt(((fst routeFly) ** 2) + ((snd routeFly) ** 2))
        position <- ((fst position) + fst (moverPrTurn)), ((snd position) + snd (moverPrTurn))
        test1 <- routeLengthFly
    member this.test
        with get() = position

let drone1 = drone((5.,5.),(10.,10.), 100.)
printfn "%A" (drone1.test)
drone1.fly
drone1.fly
drone1.fly
drone1.fly
drone1.fly
drone1.fly
drone1.fly
printfn "%A" (drone1.test)