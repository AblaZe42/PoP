module CatList
open DiffList

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

// length is not required for assignment but is a nifty helper function
let length (xs : 'a catlist) = fold ((+), 0) (fun _ -> 1) xs

let fromCatList (xs : 'a catlist) : 'a list =
    failwith "Not Implemented"

let toCatList (xs : 'a list) : 'a catlist =
    failwith "Not Implemented"

let item (i:int) (xs : 'a catlist) : 'a =
    failwith "Not Implemented"

let insert (i:int) (elm:'a) (xs:'a catlist) : 'a catlist =
    failwith "Not Implemented"

let delete (i:int) (xs:'a catlist) : 'a catlist =
    failwith "Not Implemented"