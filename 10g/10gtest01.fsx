#r "nuget:DIKU.Canvas, 1.0.1"
open Canvas

// -- Types -- //
type Color =
    | Yellow
    | Cyan
    | Blue
    | Orange
    | Red
    | Green
    | Purple
    | White

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
        |Some White -> Canvas.white
        |_ -> Canvas.black

// -- Tetrimino -- //
type position = int*int
type tetromino (A: bool[,], C: Color, O:position) = 
    let mutable a = A
    let mutable o = O
    let mutable c = C
    member this.image
        with get () = a 
        and set (n) = a <- n
    member this.color
        with get () = c
        and set (n) = c <- n
    member this.height =
        Array2D.length2 this.image
    member this.width =
        Array2D.length1 this.image
    member this.pos
        with get () = o
        and set (n) = o <- n
    member this.clone () =
        let x = tetromino (A, C, O)
        x.image <- a
        x.color <- c
        x.pos <- o
        x
    member this.rotateRight () =
        let x = this.clone ()
        let a = x.image
        let w = Array2D.length1 this.image //i
        let h = Array2D.length2 this.image //j
        printfn "%A" (w, h)
        let b = Array2D.create h w false
        for i in 0..h-1 do //   0..1
            for j in 0..w-1 do // 0..2
                b.[i,j] <- a.[w-1-j,i] // 3-1-1, 1
        x.image <- b
        x
    override this.ToString() =
        sprintf "%A %A %A " a o c

// -- Pices -- //
type square (offset : int*int) =
    inherit tetromino (array2D [ [ true; true ]; [ true; true ] ], Yellow, (offset))

type straight (offset : int*int) =
    inherit tetromino ( (array2D [[true; true; true; true]]), Cyan, (offset) )

type t (offset : int*int) =
    inherit tetromino ( (array2D [[true; true; true]; [false; true; false]]), Purple, (offset) )

type l (offset:position, b:bool) = 
    inherit tetromino (array2D ([[true;true];[true;true];[true;true]]), Orange, offset)
    do
        if b = true then 
            base.image [1,0] <- false
            base.image [1,1] <- false
        else 
            base.image [1,1] <- false
            base.image [1,2] <- false 
            base.color <- Blue

type z (offset:position, b:bool) = 
    inherit tetromino (array2D([[true;true;true];[true;true;true]]), Red, offset)
    do
        if b = true then
            base.image [0,0] <- false
            base.image [2,1] <- false
        else 
            base.image [2,0] <- false
            base.image [0,1] <- false
            base.color <- Green


// -- Board -- //
type board ( w_ : int , h_ : int ) =
    let w = w_
    let h = h_
    let _board = Array2D.create w h (Some White)
    // do _board.[1 ,0] <- Some Green
    member this.width 
        with get () = w
    member this.height 
        with get () = h
    member this.board 
        with get () = _board
    member this.newPiece () =
        let rnd = System.Random ()
        let r = rnd.Next 7
        match r with
            | 1 -> Some (square (0,5))
            | 2 -> Some (straight (0,5))
            | 3 -> Some (t (0,5))
            | 4 -> Some (l ((0,5), true))
            | 5 -> Some (l ((0,5), true))
            | 6 -> Some (z ((0,5), true))
            | 7 -> Some (z ((0,5), true))
            |_-> None  
    override this.ToString () =
        sprintf "%A" this.board

type state = board
let draw ( w : int ) ( h : int ) ( s : state ) =
    let C = create w h
    let V = s.board |> Array2D.iteri (fun i j v -> do setFillBox C (fromValue v) ((i*30), (j*30)) (((i*30)+30),((j*30)+30))) 
    C

// -- Test -- //
let bo = board (5,5)
printfn "%A" bo

let b = board (10 , 20)
// printfn "%A" (b.board)
let C = draw 300 600 b
do show C " testing "

// type board ( w : int , h : int ) =
//     let _board = Array2D.create w h None
//     do _board.[1 ,0] <- Some Green
//     member this.width = w
//     member this.height = h
//     member this.board with get () = _board
