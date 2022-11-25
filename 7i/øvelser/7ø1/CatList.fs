module CatList
open DiffList

type 'a catlist =
    | Empty
    | Single of 'a
    | Append of 'a catlist * 'a catlist

let nil = Empty

//Take a element of any type and converts it into 'a catlist
let single (elm:'a) : 'a catlist =
    Single elm

//Adds two catlist into one catlist
let append (xs : 'a catlist) (ys : 'a catlist) : 'a catlist =
    Append (xs, ys)

//Creeates new catlist: append(single elm, 'a catalist)
let cons (elm : 'a) (xs : 'a catlist) : 'a catlist =
    append (single elm) xs

//Creeates new catlist: append('a catalist, single elm)
let snoc (xs : 'a catlist) (elm : 'a) : 'a catlist =
    append xs (single elm)

//
let fold (cf:('a -> 'a -> 'a),(e:'a)) (f:('b->'a)) (xs:'b catlist) : 'a =
    let rec g xs =
        match xs with
        | Empty -> e
        | Single x -> f x        
        | Append (ys,zs) -> cf (g ys) (g zs)
    g xs

// length is not required for assignment but is a nifty helper function
let length (xs : 'a catlist) = fold ((+), 0) (fun _ -> 1) xs

let sum = ((+), 0) 

let fromCatList (xs : 'a catlist) : 'a list =
    let rec f t =
        match t with
            Empty -> []
            | Single t -> t :: []
            | Append (x,y) -> f x @ f y
    f xs    

let lst = append nil nil
lst

// let toCatList (xs : 'a list) : 'a catlist =
//     failwith "Not Implemented"

let toCatList (xs : 'a list) : 'a catlist =
     let rec f t =
         match t with
             [] -> rst
             | [t] -> single t
     f xs

let item (i:int) (xs : 'a catlist) : 'a =
    failwith "Not Implemented"

let insert (i:int) (elm:'a) (xs:'a catlist) : 'a catlist =
    failwith "Not Implemented"

let delete (i:int) (xs:'a catlist) : 'a catlist =
    failwith "Not Implemented"

// TEST
let cat1 : 'a catlist = append(single 1) (nil) |> append nil
let cat2 : 'a catlist = cat1 |> cons 3
let cat3 : 'a catlist = snoc cat1 3
printfn "%A" cat1
printfn "%A" cat2
printfn "%A" cat3

printfn "%A" (length cat3)

let cat4 = fromCatList cat2
printfn "%A" cat4

let lst1 : 'a list = [1; 2; 3; 3; 5]

let test (xs: 'a list) =
    lst |> cons xs[1]

printfn "%A" (test lst1)

printfn "toCatList: %A" (toCatList lst1)