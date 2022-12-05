module CatList
open DiffList

type 'a catlist =
    | Empty
    | Single of 'a
    | Append of 'a catlist * 'a catlist


let nil = Empty
let single (elm:'a) : 'a catlist =
    failwith "Not Implemented"    

let append (xs : 'a catlist) (ys : 'a catlist) : 'a catlist =
    failwith "Not Implemented"    
let cons (elm : 'a) (xs : 'a catlist) : 'a catlist =
    failwith "Not Implemented"

let snoc (xs : 'a catlist) (elm : 'a) : 'a catlist =
    failwith "Not Implemented"

let fold (cf:('a -> 'a -> 'a),(e:'a)) (f:('b->'a)) (xs:'b catlist) : 'a =
    failwith "Not Implemented"

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
