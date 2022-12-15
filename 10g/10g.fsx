#r "nuget:DIKU.Canvas, 1.0.1"
open Canvas

type square (offset : int*int) =
    member this.image = 
        [[true; true]; [true; true]]

type straight (offset : int*int) =
    member this.image = 
        [[true; true; true; true]]

type t (offset : int*int) =
    [[true; true; true]; [false; true; false]]

type l (offset : int*int) (m: bool) =
    member this.image =
        if m = false
        then
            [[true; false; false]; [true; true; true]]
        else
            [[false; false; true]; [true; true; true]]

type z (offset : int*int) (m:bool) =
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
printfn "%A" (b.board)
let C = draw 300 600 b
do show C " testing "