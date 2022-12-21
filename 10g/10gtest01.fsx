#r "nuget:DIKU.Canvas, 1.0.1"
open Canvas

// type listType = (bool list * bool list) list

type position = int*int
type tetromino = 
    struct
        val A : bool[,]
        val C : color
        val O : position
        new (a, c, o) =
            {A=a; C=c; O=o}
    end
    member this.image (o) =
        o
    
    
    // new () = 
    //     let a = square (20, 20)
    //     tetromino (a.image, Red, (20, 20))

type square (offset : int*int) =
    // inherit tetromino ()
    member this.image = 
        let a = array2D [ [ true; true ]; [ true; true ] ]
        a
    member this.test =
        "Hello world"

let a = square (20, 20)
printfn "%A" a.test
let a1 = array2D [ [ true; true ]; [ true; true ] ]
let myTetrimono = tetromino (a1, red, (20, 20))
printfn "%A" myTetrimono.image

// type game () =
//     inherit tetromino ()
//     let a  = square (20,20)
//     member this.myTetromino = 
//         new tetromino (a.image, yellow, (5, 10))

// let gamer = game ()
// printfn "%A" gamer.myTetromino

// let a1 = square (20, 200)
// let a : listType = a1.image
// printfn "%A" a




type straight (offset : int*int) =
    member this.image = 
        [[true; true; true; true]]

type t (offset : int*int) =
    member this.image =
        [[true; true; true]; [false; true; false]]

type l (offset : int*int, m: bool) =
    member this.image =
        if m = false
        then
            [[true; false; false]; [true; true; true]]
        else
            [[false; false; true]; [true; true; true]]

type z (offset : int*int, m:bool) =
    member this.image =
        if m = false
        then 
            [[false; true; true]; [true; true; false]]
        else 
            [[true; true; false]; [false; true; true]]

type Color =
    | Yellow
    | Cyan
    | Blue
    | Orange
    | Red
    | Green
    | Purple

let fromValue v =
    let CyanC = fromRgb (0, 255, 255)
    let OrangeC = fromRgb (255, 140, 0)
    let PurpleC = fromRgb (128, 0, 128)
    match v with
        |Some Yellow -> Canvas.yellow
        |Some Cyan -> CyanC
        |Some Blue -> Canvas.blue
        |Some Orange -> OrangeC
        |Some Red -> Canvas.red
        |Some Green -> Canvas.green
        |Some Purple -> PurpleC
        |_-> Canvas.white

type board ( w : int , h : int ) =
    let _board = Array2D . create w h None
    do _board.[1 ,0] <- Some Green
    member this.width = w
    member this.height = h
    member this.board with get () = _board

type state = board
let draw ( w : int ) ( h : int ) ( s : state ) =
    let C = create w h
    let V = s.board |> Array2D.iteri (fun i j v -> do setFillBox C (fromValue v) ((i*30), (j*30)) (((i*30)+30),((j*30)+30))) 
    C
     
// insert your definition of draw here


    

let b = board (10 , 20)
// printfn "%A" (b.board)
let C = draw 300 600 b
do show C " testing "