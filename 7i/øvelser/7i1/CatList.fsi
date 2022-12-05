module CatList

type 'a catlist =
    | Empty
    | Single of 'a
    | Append of 'a catlist * 'a catlist

val nil : 'a catlist
val single : 'a -> 'a catlist
val append : 'a catlist -> 'a catlist -> 'a catlist
val cons : 'a -> 'a catlist -> 'a catlist
val snoc : 'a catlist -> 'a -> 'a catlist

val fold : (('a -> 'a -> 'a) * 'a) -> ('b -> 'a) -> 'b catlist -> 'a
val fromCatList : 'a catlist -> 'a list
val toCatList : 'a list -> 'a catlist
val item : int -> 'a catlist -> 'a
val insert : int -> 'a -> 'a catlist -> 'a catlist
val delete : int -> 'a catlist -> 'a catlist
