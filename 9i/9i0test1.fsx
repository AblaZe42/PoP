type drone (start_ : float*float, dest_ : float*float, speed_ : float) =
    let mutable position  = start_
    let destination = dest_
    let mutable speed = speed_
    /// <summary>Gets posittion of drone</summary>
    /// <returns>position: float*float</returns>
    member this.pos =
        position
    /// <summary>Gets destination of drone</summary>
    /// <returns>destination: float*float</returns>
    member this.des =
        destination
    /// <summary>Gets speed of drone</summary>
    /// <returns>speed: float</returns>
    member this.spe = 
        speed
    /// <summary>Moves the drone speed closer to destination</summary>
    /// <returns>position: float*float</returns>   
    member this.fly =
        let route = ((fst destination) - (fst position), (snd destination) - (snd position))
        let routeLength = sqrt(((fst route) ** 2) + ((snd route) ** 2))
        let timeFly = routeLength / (speed) 
        let moverPrTurn = ((fst route) / timeFly), ((snd route) / timeFly)
        position <- ((fst position) + fst (moverPrTurn)), ((snd position) + snd (moverPrTurn))
        if routeLength <= speed
        then
            position <- destination
            position
        else
            position
    /// <summary>Checks if drone have reached it's destinatnion</summary>
    /// <returns>true or false: bool</returns> 
    member this.atDestination =
        if destination = position
        then true
        else false

type airSpace () = 
    static let mutable droneList = []
    /// <summary>returns dronelist</summary>
    /// <returns>dornelist: drone list</returns> 
    member this.drones = 
        droneList
    /// <summary>Calculate the distance between two drones</summary>
    /// <param name = "drone1">The first drone </param>
    /// <param name = "drone2">The second drone </param>
    /// <returns>dronedistance: float</returns> 
    member this.dronesDist (drone1: drone, drone2: drone) =
        let a = drone1.pos
        let b = drone2.pos
        let dronesDistance = sqrt((((fst a) - (fst b))**2.) + (((snd a) - (snd b))**2.))
        dronesDistance
    /// <summary>Adds a new drone two droneList</summary>
    /// <param name = "a">the new drones: start position  </param>
    /// <param name = "b">the new drones: destination </param>
    /// <param name = "c">the new drones: speed </param>
    /// <returns>dornelist: drone list</returns> 
    member this.AddDrone(a, b, c) =
        let addedDrone = [drone (a, b, c)]
        droneList <- addedDrone @ droneList
    /// <summary>Moves the drones speed closer to destination</summary>
    /// <returns>list of all the drones new posistions</returns>   
    member this.flyDrones =
        droneList |> List.map (fun x -> x.fly) 
    /// <summary>Cheks if two drones are less than 500 cm from each others</summary>
    /// <returns>returns a list of colided drones</returns>   
    member this.collide =
        let dronesInAir = 
            this.drones |> List.filter (fun x -> x.atDestination = false) //Filters out drones at destination
        let pairedDrones = 
            (List.allPairs dronesInAir dronesInAir) |> List.filter (fun x -> fst x <> snd x)
        let collided = 
            pairedDrones |> List.filter (fun e -> this.dronesDist e < 500)
            |> List.map (fun (x,y) -> [x;y]) |> List.concat |> List.distinct 
        droneList <- droneList |> List.except (collided) //removes colided drones
        collided

type Assert () =
    /// <summary>Compares the relationship between a and b</summary>
    /// <param name = "str">what should be comared and how </param>
    /// <param name = "a">fst element for comparising </param>
    /// <param name = "b">snd element for comparising </param>
    /// <param name = "f"> the operater used for comparising </param>
    /// <returns>unit</returns> 
    static member info (s: string) (a: 'a) (b: 'a) (f: 'a->'b->bool) =
        let i = 
            if (f a b) then "Pass" else "fail"
        printfn "%A: %A" s i

let airSpace1 = airSpace()
//Drone1 and Drone2 Both reach their destination
airSpace1.AddDrone((0.,0.),(500.,0.), 100.) //Destination reached aafter 5 seconds
airSpace1.AddDrone((1000.,0.),(500.,0.), 200.) //Destination reached after 3 seconds

//Drone3 and Drone4 Colliedes after 6 seconds
airSpace1.AddDrone((2000.,0.),(2500.,1000.), 100.) //Collides after 6 seconds
airSpace1.AddDrone((3000.,0.),(2500.,1000.), 100.) //Collides after 6 secconds

airSpace1.AddDrone((4000.,0.),(1000.,1000.), 300.)
airSpace1.AddDrone((5000.,0.),(1000.,1000.), 300.)
airSpace1.AddDrone((6000.,0.),(1000.,1000.), 300.)
airSpace1.AddDrone((7000.,0.),(1000.,1000.), 300.)
airSpace1.AddDrone((8000.,0.),(1000.,1000.), 300.)
airSpace1.AddDrone((9000.,0.),(1000.,1000.), 300.)
airSpace1.AddDrone((10000.,0.),(1000.,1000.), 300.)

printfn "Drones test"
printfn "1 sec: DronePos: %A" (airSpace1.flyDrones) //+1 sec
(airSpace1.flyDrones) // +1 sec
(airSpace1.flyDrones) // +1 sec
printfn "sec 3: Drones reached destination: %A" (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length
(airSpace1.flyDrones) // +1 sec
(airSpace1.flyDrones) // +1 sec
printfn "sec 5: Drones reached destination: %A" (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length
(airSpace1.flyDrones) //+1 sec
printfn "sec 6: Drones collided: %A" ((airSpace1.collide).Length)
(airSpace1.flyDrones) //+1 sec

printfn ""
printfn "Assert test"
Assert.info "Are drones index 0 and 1 in collsion range?" (airSpace1.dronesDist ((airSpace1.drones[0]),(airSpace1.drones[1]))) 500 (<)

printfn ""
printfn "Drones fly"
printfn "Sec 7: Drones collided: %A, Drones atDestination in total: %A" ((airSpace1.collide).Length) (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length
printfn "Sec 7: Drones inAir: %A" ((airSpace1.drones.Length) - (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length)
(airSpace1.flyDrones) //+1 sec
printfn "Sec 8: Drones collided: %A, Drones atDestination in total: %A" ((airSpace1.collide).Length) (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length
printfn "Sec 8: Drones inAir: %A" ((airSpace1.drones.Length) - (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length)
(airSpace1.flyDrones) //+1 sec
printfn "Sec 9: Drones collided: %A, Drones atDestination in total: %A" ((airSpace1.collide).Length) (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length
printfn "Sec 9: Drones inAir: %A" ((airSpace1.drones.Length) - (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length)
(airSpace1.flyDrones) //+1 sec
printfn "Sec 10: Drones collided: %A, Drones atDestination in total: %A" ((airSpace1.collide).Length) (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length
printfn "Sec 10: Drones inAir: %A" ((airSpace1.drones.Length) - (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length)
(airSpace1.flyDrones) //+1 sec
(airSpace1.flyDrones) //+1 sec
(airSpace1.flyDrones) //+1 sec
(airSpace1.flyDrones) //+1 sec
(airSpace1.flyDrones) //+1 sec
printfn "Sec 15: Drones collided: %A, Drones atDestination in total: %A" ((airSpace1.collide).Length) (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length
printfn "Sec 15: Drones inAir: %A" ((airSpace1.drones.Length) - (airSpace1.drones |> List.filter (fun e -> e.atDestination = true)).Length)