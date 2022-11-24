module Cat
open System.IO

let readBytes (fs:FileStream) : byte[] =
    let len = fs.Length |> int32
    let (arr : byte[]) = Array.init (fs.Length |> int) (fun _ -> 0uy)
    let readBytes = fs.Read(arr, 0, len)
    arr

let readFile (filename:string) : byte[] =
    try
        File.OpenRead filename |> readBytes
    with
        _ -> raise (System.IO.FileNotFoundException())

let readFiles (filenames : string list) : byte[] option list =
    List.map (fun x -> try readFile x |> Some with _ -> None) filenames


let writeBytes (bytes : byte[]) (fs:FileStream) =
    printfn "Writing %d bytes to filestream" (Array.length bytes)
    printfn "CanWrite: %A" fs.CanWrite
    fs.Write(bytes, 0, Array.length bytes)
    fs.Flush()


let writeFile (bytes: byte[]) (filename:string) =
    try
        File.Open(filename, FileMode.Create) |> writeBytes bytes
        0
    with
        _ ->
            sprintf "cat: Could not open or create file \"%s\"" filename
            |> System.Console.Error.WriteLine
            1


let cat (filenames : string[]) =
    match Array.length filenames with
        | 0 ->
            System.Console.Error.WriteLine "cat: no input files"
            0
        | 1 ->
            writeFile [||] filenames.[0]
        | len ->
            printfn "with len=%d" len
            let infiles = filenames.[..len-2]
            let outfile = filenames.[len-1]
            printfn "Infiles: %A" infiles
            printfn "Outfile: %s" outfile
            let fileContents =
                List.ofArray infiles
                |> readFiles
            printfn "fileCOntents: %A" fileContents
            if List.exists ((=) None) fileContents then
                let mutable exitStatus = 0
                List.iteri (fun i x ->
                                if x = None
                                then
                                    exitStatus <- exitStatus + 1
                                    sprintf "cat: The file %s does not exist or is not readable." filenames.[i]
                                    |> System.Console.Error.WriteLine
                                else ()
                           ) fileContents
                exitStatus
            else
                fileContents
                |> List.map Option.get
                |> (fun x -> printfn "%A" x; x)
                |> Array.ofList
                |> (fun x -> printfn "%A" x; x)                
                |> Array.concat
                |> (fun x -> printfn "%A" x; x)                
                |> writeFile <| outfile
