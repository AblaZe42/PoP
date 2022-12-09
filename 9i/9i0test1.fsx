type drone (start : float*float, dest : float*float, speed : float) =
    let mutable position  = start
    let destination = dest
    let mutable speed = speed
    member this.pos =
        position
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
    member this.atDestination =
        if destination = position
        then true
        else false

type airSpace (drones) = 
    let mutable drones = []
    let mutable droneNumber = 1
    member drone.dist (drone1: float*float, drone2: float*float) = 
        ((((fst drone2) - (fst drone1))**2.) + (((snd drone2) - (snd drone1))**2.))
    member this.AddDrone(a, b, c) =
        let x = [drone(a, b, c)]
        drones <- drones @ x
    member this.flyDrones =
        drones |> List.map (fun x -> x.fly) 
    member this.Collide()
        

let airSpace1 = airSpace()
airSpace1.AddDrone((5.,5.),(10.,10.), 100.)
airSpace1.AddDrone((4.,4.),(14.,14.), 100.)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)
printfn "%A" (airSpace1.flyDrones)

// printfn "   "
// printfn "droneTest"
// let drone1 = drone((0.,50.),(50.,50.), 100.)
// printfn "%A" (drone1.fly)
// printfn "%A" (drone1.fly)
// printfn "%A" (drone1.fly)
// printfn "%A" (drone1.fly)
// printfn "%A" (drone1.fly)
// printfn "%A" (drone1.fly)
// printfn "%A" (drone1.fly)

// printfn "%A" (drone1.atDestination)
