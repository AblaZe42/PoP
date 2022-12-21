open droneSim
let airSpace0 = airSpace()
airSpace0.addDrone((0. ,0.),    (100. ,0.),     100.)
airSpace0.addDrone((1000. ,0.), (500. ,0.),     200.)
airSpace0.addDrone((2000. ,0.), (2500. ,1000.), 100.)
airSpace0.addDrone((3000. ,0.), (2500. ,1000.), 100.) 
airSpace0.addDrone((4000. ,0.), (1000. ,1000.), 300.)
airSpace0.addDrone((5000. ,0.), (1000. ,1000.), 300.)
airSpace0.addDrone((6000. ,0.), (1000. ,1000.), 300.)
airSpace0.addDrone((7000. ,0.), (1000. ,1000.), 300.)
airSpace0.addDrone((7000. ,0.), (1000. ,1000.), 300.)
airSpace0.addDrone((9000. ,0.), (1000. ,1000.), 300.)
airSpace0.addDrone((9250. ,0.), (1000. ,1000.), 300.)

printfn ""
printfn "Assert test"
Assert.info "is the total number of drones larger after adding a drone?" airSpace0.drones.Length (airSpace0.addDrone((4000.,0.),(1000. ,1000.), 300.)).Length (<)
Assert.info "Does drones stay in same pos after this.fly" airSpace0.drones[9].pos airSpace0.flyDrones[9] (=)
Assert.info "Are drones index 0 and 1 in collsion range?" (airSpace0.dronesDist ((airSpace0.drones[0]),(airSpace0.drones[1]))) 500 (<)
// Assert.info "Have any drones collided?" (airSpace0.collide).Length 0 (>)

printfn ""
printfn "Test run"

printfn "1 sec: drones: %A drones collided: %A" (airSpace0.drones).Length (airSpace0.collide).Length
(airSpace0.flyDrones) // +1 sec
printfn "2 sec: drones: %A drones collided: %A" (airSpace0.drones).Length (airSpace0.collide).Length
(airSpace0.flyDrones) // +1 sec
printfn "3 sec: drones: %A drones collided: %A" (airSpace0.drones).Length (airSpace0.collide).Length
(airSpace0.flyDrones) // +1 sec
printfn "4 sec: drones: %A drones collided: %A" (airSpace0.drones).Length (airSpace0.collide).Length
(airSpace0.flyDrones) // +1 sec
printfn "5 sec: drones: %A drones collided: %A" (airSpace0.drones).Length (airSpace0.collide).Length
(airSpace0.flyDrones) // +1 sec
printfn "6 sec: drones: %A drones collided: %A" (airSpace0.drones).Length (airSpace0.collide).Length
(airSpace0.flyDrones) // +1 sec
printfn "7 sec: drones: %A drones collided: %A" (airSpace0.drones).Length (airSpace0.collide).Length
(airSpace0.flyDrones) // +1 sec
printfn "8 sec: drones: %A drones collided: %A" (airSpace0.drones).Length (airSpace0.collide).Length
(airSpace0.flyDrones) // +1 sec
printfn "9 sec: drones: %A drones collided: %A" (airSpace0.drones).Length (airSpace0.collide).Length
(airSpace0.flyDrones) // +1 sec
printfn "Drones reached distination: %A" (airSpace0.drones |> List.filter (fun x -> x.atDestination = true)).Length

