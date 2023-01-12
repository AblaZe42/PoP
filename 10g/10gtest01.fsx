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
        |_ -> Canvas.white

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

(*
// -- Board -- //
type board ( w_ : int , h_ : int ) =
    let w = w_
    let h = h_
    let _board = Array2D.create w h None
    do _board.[4 ,0] <- Some Green
    member this.width 
        with get () = w
    member this.height 
        with get () = h
    member this.board 
        with get () = _board
    member this.newPiece () : tetromino option =
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
        // match brik med slice i samme dimmenstion
    member this.put (t : tetromino) =
        let offsetT = t.pos
        let w1 = Array2D.length1 t.image
        let h1 = Array2D.length2 t.image
        let a = ((fst offsetT), (fst offsetT) + w1-1 ) 
        let b = ((snd offsetT), (snd offsetT) + h1-1 ) 
        this.board[(fst a) .. (snd a), (fst b) .. (snd b)]
        
        

    override this.ToString () =
        sprintf "%A" this.board


type state = board
let draw ( w : int ) ( h : int ) ( s : state ) =
    let C = create w h
    let V = s.board |> Array2D.iteri (fun i j v -> do setFillBox C (fromValue v) ((i*30), (j*30)) (((i*30)+30),((j*30)+30))) 
    C

// -- Test -- //
let bo = board (10,20)
let something = t(4,0)
printfn "%A" bo
printfn "Slice %A" (bo.put (something))

let b = board (10 , 20)
// printfn "%A" (b.board)
let C = draw 300 600 b
do show C " testing "

type board ( w : int , h : int ) =
    let _board = Array2D.create w h None
    do _board.[1 ,0] <- Some Green
    member this.width = w
    member this.height = h
    member this.board with get () = _board
*)


type Board(w,h) =
    let mutable brd = Array2D.init h w (fun x y -> None)
    let mutable activePiece:tetromino= straight(0,0)
    let randomTetromino(o):tetromino =
        let n()=(new System.Random()).Next(7)
        match n() with
            |0-> z(o, true)
            |1-> z(o, false)
            |2-> straight(o)
            |3-> l(o, true)
            |4->square(o)
            |5->t(o)
            |6->l(o, false)
            |_-> straight(o)
    do 
        let x=randomTetromino(0,(int(w/2)-1))
        let o=(0,(int(w/2)-1))
        for r=0 to x.height-1 do
            for k=0 to x.width-1 do
                if ((x.image).[r,k])=true then
                    brd.[fst(o)+r,snd(o)+k]<- Some (x.color)
                    printfn "Setting color" 
                else printfn "nothing"
        activePiece<-x
    override this.ToString() : string= sprintf "%A" brd
    member this.newPiece(): tetromino option= 
        let x=randomTetromino (0,(int(w/2)-1))
        let o=x.pos
        let mutable space=true 
        for r=0 to x.height-1 do
            for k=0 to x.width-1 do
                if (not(brd.[fst(o)+r,snd(o)+k]=None))&&(x.image.[r,k]) then space<-false else ()
        if space=true then
            printfn"%A" x.image
            for r=0 to x.height-1 do
                for k=0 to x.width-1 do
                    if ((x.image).[r,k])=true then
                        brd.[fst(o)+r,snd(o)+k]<- Some (x.color)
                        printfn "Setting color" 
                    else printfn "nothing"
            activePiece<-x
            Some(x)
        else None
    member this.put ( t : tetromino) :bool= 
        let mutable space=true 
        if snd(t.pos)+t.width>w then t.pos<-(fst(t.pos),(w-t.width))
        elif snd(t.pos)<0 then t.pos<-(fst(t.pos),0)
        else ()
        if fst(t.pos)+t.height>h then space<-false
        else ()
        if space then
            for r=0 to t.height-1 do
                for k=0 to t.width-1 do
                    if not(brd[fst(t.pos)+r,snd(t.pos)+k]=None )&&(t.image[r,k]) then space<-false else ()
        else ()
        if space then
            for r=0 to t.height-1 do
                for k=0 to t.width-1 do
                    if (t.image[r,k]) then
                        brd[fst(t.pos)+r,snd(t.pos)+k]<- Some (t.color)
                    else ()
            activePiece<-t
            true
        else false
    member this.take() :tetromino option=
        let o=activePiece.pos
        for r=0 to activePiece.height-1 do
            for k=0 to activePiece.width-1 do
                    if (activePiece.image[r,k]) then
                        brd[fst(o)+r,snd(o)+k]<- None
                    else ()
        Some(activePiece)
    member this.board : Color option [,]= brd
    member this.heigth: int=h
    member this.width: int=w

type State=Board
let toCanvasColor (C:Color) =
    match C with
        | Red -> fromRgb (255,0,0)
        | Green -> fromRgb (0,255,0)
        | Blue -> fromRgb (0,0,255)
        | Yellow -> fromRgb (255,255,0)
        | Cyan -> fromRgb (0,255,255)
        | Purple -> fromRgb (255,0,255)
        | Orange -> fromRgb (255,87,51)

let draw (w:int) (h:int) (s:State) : Canvas.canvas =
    let C = create w h
    let clmn= (s.width)
    let rws=(s.heigth)
    let boxw=w/clmn
    let boxh=h/rws
    for r=0 to (rws-1) do
        for k=0 to (clmn-1) do
            match (s.board).[r,k] with
                |None -> () 
                |Some color -> setFillBox C (toCanvasColor color) (boxw*k,boxh*r) (boxw*(k+1),boxh*(r+1))
    C

type Assert ()=
    static member test (str) (a) (b) (f:'a->'b->bool)=
        let result = if (f a b)=true then "Pass" else "Fail"
        printfn"%s:%s" str result


let react (s: State) (k: key) : State option=
    match getKey k with 
        |Space -> 
            let ap=s.take().Value
            ap.rotateRight()
            if s.put(ap) then Some(s)
            else 
                ap.rotateRight();ap.rotateRight();ap.rotateRight();s.put(ap)
                Some(s)
            
            
        |DownArrow -> 
            let ap=(s.take()).Value
            ap.pos<-(fst(ap.pos)+1,snd(ap.pos))
            if s.put(ap) then
                Some(s)
            else 
                ap.pos<-(fst(ap.pos)-1,snd(ap.pos))
                s.put(ap)
                s.newPiece()
                Some(s)
        |LeftArrow -> 
            let ap=(s.take()).Value
            ap.pos<-(fst(ap.pos)+1,snd(ap.pos)-1)
            if s.put(ap) then
                Some(s)
            else 
                printfn "nope"
                ap.pos<-(fst(ap.pos)-1,snd(ap.pos)+1)
                s.put(ap)
                s.newPiece()
                Some(s)
        |RightArrow ->
            let ap=(s.take()).Value
            ap.pos<-(fst(ap.pos)+1,snd(ap.pos)+1)
            if s.put(ap) then
                Some(s)
            else 
                printfn "nope"
                ap.pos<-(fst(ap.pos)-1,snd(ap.pos)-1)
                s.put(ap)
                s.newPiece()
                Some(s)
        |_->Some (s)

runApp " Tetris " 300 600 draw react ( Board (10 , 20) )