module CatList
open DiffList

//Type specification
type 'a catlist =
    | Empty
    | Single of 'a
    | Append of 'a catlist * 'a catlist

let nil = Empty

/// <summary> Take a element of any type and converts it into 'a catlist </summary>
/// <param name = elm> The element that needs to be converted into type: 'a catlist </param>
/// <returns> Returns a catlist </returns>
let single (elm:'a) : 'a catlist =
    Single elm

/// <summary> Creates a tuple of type 'a catlist contaning two catlist </summary>
/// <param name = xs> 'a catlist for first position of tuple </param>
/// <param name = ys> 'a catlist for second position of tuple </param>
/// <returns> Returns a catlist  </returns>
let append (xs : 'a catlist) (ys : 'a catlist) : 'a catlist =
    Append (xs, ys)

/// <summary> creates a tuple of (single of 'a) * 'a catlist </summary>
/// <param name = elm> The element that is added to the first coordinate </param>
/// <param name = xs > The catlist that is added to the second coordinate </param>
/// <returns> Returns a catlist </returns>
let cons (elm : 'a) (xs : 'a catlist) : 'a catlist =
    append (single elm) xs

/// <summary> Creeates new catlist: append('a catalist, single elm) </summary>
/// <param name = xs > The catlist that is added to the first coordinate </param>
/// <param name = elm> The element that is added to the second coordinate </param>
/// <returns> Returns a catlist </returns>
let snoc (xs : 'a catlist) (elm : 'a) : 'a catlist =
    append xs (single elm)

/// <summary> Creeates new catlist: append('a catalist, single elm) </summary>
/// <param name = cf > (The "thing" that is applied)(What Empty is converted to) </param>
/// <param name = f  > How elements should be treated </param>
/// <param name = xs > A list </param>
/// <returns> Returns a generic element: 'a </returns>
let fold (cf:('a -> 'a -> 'a),(e:'a)) (f:('b->'a)) (xs:'b catlist) : 'a =
    let rec g xs =
        match xs with
        | Empty -> e
        | Single x -> f x        
        | Append (ys,zs) -> cf (g ys) (g zs)
    g xs

// length/sum is not required for assignment but is a nifty helper function
let length (xs : 'a catlist) = fold ((+), 0) (fun _ -> 1) xs
let sum (xs : 'a catlist) = fold ((+), 0) (fun t -> t) xs 

/// <summary> Takes a catlist and converts it to 'a list </summary>
/// <param name = xs > A catlistlist </param>
/// <returns> Returns 'a list'</returns>
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
    List.foldBack cons xs Empty

/// <summary> Takes a catlist and converts it to 'a list </summary>
/// <param name = int > the index that item returns </param>
/// <param name = xs > A catlistlist </param>
/// <returns> Returns 'a list'</returns>
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

// COPY/PASTE
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

// COPY/PASTE
let delete (int:int) (xs:'a catlist) : 'a catlist =
    let rec f int xs =
        match xs with
            Single elm when int = 0 -> nil
            | Append (s1, s2) ->
                if int < (length (s1)) 
                then Append (f int (s1), (s2))
                else Append (s1, f (int-(length s1))s2)
            |_-> 
                failwith "Fail: Wildcard"
    f int xs

// TEST
printfn "!-- testCatlist --!"
let cat1 : 'a catlist = append(single 1) (nil) |> append nil
let cat2 : 'a catlist = cat1 |> cons 3
let cat3 : 'a catlist = snoc cat1 3
let lst = [1;2;3]
printfn "cat1: %A" cat1
printfn "cat2: %A" cat2
printfn "cat3: %A" cat3

printfn ""
printfn "!-- testFunctions --!"
printfn "lenght: %A" (length cat3)
printfn "Sum: %A" (sum cat2)

let lst4 = fromCatList cat2
printfn "fromCatList: %A" lst4
printfn "toCatList: %A" (toCatList lst)
printfn "item: %A" (item 0 cat3)

let lst1 : 'a list = [1; 2; 3; 3; 5]

let test (xs: 'a list) =
    lst |> cons xs[1]

printfn "%A" (test lst1)

printfn "toCatList: %A" (toCatList lst1)