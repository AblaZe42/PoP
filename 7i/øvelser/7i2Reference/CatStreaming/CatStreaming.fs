module CatStreaming
open System.IO


let readBytes (count:int) (buffer:byte[]) (fs:FileStream) : int =
    fs.Read(buffer, 0 ,count)

// RECOMMENDED BUT OPTIONAL:
//     Implement this function if you want to
//     If you remove it, remember to remove it from CatStreaming.fsi as well
let writeBytes (count:int) (buffer:byte[]) (fs:FileStream) : unit =
    fs.Write(buffer, 0, count) 

// RECOMMENDED BUT OPTIONAL:
//     Implement this function if you want to
//     If you remove it, remember to remove it from CatStreaming.fsi as well
let readAndWriteBytes (buffersize:int) (buffer:byte[]) (ifs:FileStream) (ofs:FileStream) =
    let rec inner () =
        let readBytes = readBytes buffersize buffer ifs
        match readBytes with
            | 0 -> ifs.Close(); ofs.Flush()
            | _ ->
                writeBytes readBytes buffer ofs |> inner
    inner () 

// RECOMMENDED BUT OPTIONAL:
//     Implement this function if you want to
//     If you remove it, remember to remove it from CatStreaming.fsi as well
let openFileRead (filename:string) : FileStream =
    try
        File.OpenRead filename
    with
        _ -> raise (System.IO.FileNotFoundException())

// RECOMMENDED BUT OPTIONAL:
//     Implement this function if you want to
//     If you remove it, remember to remove it from CatStreaming.fsi as well
let openFilesRead (filenames : string list) : FileStream option list =
    List.map (fun filename -> try openFileRead filename |> Some with _ -> None) filenames

// RECOMMENDED BUT OPTIONAL:
//     Implement this function if you want to
//     If you remove it, remember to remove it from CatStreaming.fsi as well
let openFileWrite (filename:string) : FileStream option =
    try
        File.Open(filename, FileMode.Create) |> Some
    with
        _ ->
            sprintf "cat: Could not create or truncate file \"%s\" " filename
            |> System.Console.Error.WriteLine
            None

let countAndOutputErrors (errors : int) (filename:string) (filestream: FileStream Option) =
    match filestream with
        |None ->
            sprintf "fail: \"%s\" does not exist" filename
            |> System.Console.Error.WriteLine
            errors + 1
        | Some _ -> errors


// REQUIRED: Your implemenation *must* include this function
let catWithBufferSize (buffersize:int) (filenames:string[]) : int =
    let len = 3
    let buffer = Array.init buffersize (fun _ -> 0uy)
    let infiles = filenames.[..len-2] |> List.ofArray
    let outfile = filenames.[len-1]
    let inputFileStreams = openFilesRead infiles
    let outputFileStream = openFileWrite outfile
    let ofs = Option.get(outputFileStream)
    List.map Option.get inputFileStreams
    |> List.map (fun inputfile -> readAndWriteBytes buffersize buffer inputfile ofs)

    ofs.Close()
    0 // exit status
            
            
// REQUIRED: Your implementation *must* include this function
let cat = catWithBufferSize 32

