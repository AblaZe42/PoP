module CatList
open DiffList

//Type specification
type 'a catlist =
    | Empty
    | Single of 'a
    | Append of 'a catlist * 'a catlist

let nil = Empty

let single (elm:'a) : 'a catlist =
    Single elm

let append (xs : 'a catlist) (ys : 'a catlist) : 'a catlist =
    Append (xs, ys)

let cons (elm : 'a) (xs : 'a catlist) : 'a catlist =
    append (single elm) xs

let snoc (xs : 'a catlist) (elm : 'a) : 'a catlist =
    append xs (single elm)

let fold (cf:('a -> 'a -> 'a),(e:'a)) (f:('b->'a)) (xs:'b catlist) : 'a =
    let rec g xs =
        match xs with
        | Empty -> e
        | Single x -> f x        
        | Append (ys,zs) -> cf (g ys) (g zs)
    g xs

let length (xs : 'a catlist) = fold ((+), 0) (fun _ -> 1) xs
let sum (xs : 'a catlist) = fold ((+), 0) (fun t -> t) xs 

let fromCatList (xs : 'a catlist) : 'a list =
    let rec f t =
        match t with
            Empty -> []
            | Single t -> t :: []
            | Append (x,y) -> f x @ f y
    f xs    

let toCatList (xs : 'a list) : 'a catlist =
    List.foldBack cons xs Empty

let item (int:int) (xs : 'a catlist) : 'a =
    let rec f int xs =
        match xs with
            Empty -> 
                failwith "Fail: Empty"
            | Single n when int = 0 -> 
                n
            | Append (x1, x2) -> 
                let l = length x1
                if int < l
                then f int x1 
                else f (int - l) x2
            |_-> 
                failwith "Fail: Wildcard"
    f int xs


let insert (i:int) (elm:'a) (xs:'a catlist) : 'a catlist =
    let rec u i (xs: 'a catlist) =
        if i=0 then (cons elm xs)
        elif i = length xs then snoc xs elm
        else
            match xs with
                | Append (ys, zs) ->
                    if i <(length (ys)) then
                        Append (u i (ys), (zs))
                    else
                        Append (ys, u(i-length (ys)) zs)
                |_-> failwith "fejl"
    u i xs

let delete (int:int) (xs:'a catlist) : 'a catlist =
    let rec f int xs =
        match xs with
            Single elm when int = 0 -> nil
            | Append (x, y) ->
                if int < (length (x)) 
                then Append (f int (x), (x))
                else Append (x, f (int-(length x))y)
            |_-> 
                failwith "Fail: Wildcard"
    f int xs