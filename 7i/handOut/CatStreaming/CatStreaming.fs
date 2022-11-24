module CatStreaming
open System.IO

// RECOMMENDED BUT OPTIONAL:
//     Implement this function if you want to
//     If you remove it, remember to remove it from CatStreaming.fsi as well
let readBytes (count:int) (buffer:byte[]) (fs:FileStream) : int =
    0 // Replace with a proper implementation

// RECOMMENDED BUT OPTIONAL:
//     Implement this function if you want to
//     If you remove it, remember to remove it from CatStreaming.fsi as well
let writeBytes (count:int) (buffer:byte[]) (fs:FileStream) : unit =
    () // Replace with a proper implementation

// RECOMMENDED BUT OPTIONAL:
//     Implement this function if you want to
//     If you remove it, remember to remove it from CatStreaming.fsi as well
let readAndWriteBytes (buffersize:int) (buffer:byte[]) (ifs:FileStream) (ofs:FileStream) =
    () // Replace with a proper implementation

// RECOMMENDED BUT OPTIONAL:
//     Implement this function if you want to
//     If you remove it, remember to remove it from CatStreaming.fsi as well
let openFileRead (filename:string) : FileStream =
    // Replace with a proper implementation
    failwith "Not implemented yet"

// RECOMMENDED BUT OPTIONAL:
//     Implement this function if you want to
//     If you remove it, remember to remove it from CatStreaming.fsi as well
let openFilesRead (filenames : string list) : FileStream option list =
    [] // Replace with a proper implementation

// RECOMMENDED BUT OPTIONAL:
//     Implement this function if you want to
//     If you remove it, remember to remove it from CatStreaming.fsi as well
let openFileWrite (filename:string) : FileStream option =
    None // Replace with a proper implementation

// REQUIRED: Your implemenation *must* include this function
let catWithBufferSize (buffersize:int) (filenames:string[]) : int =
    0 // Replace with a proper implementation
            
// REQUIRED: Your implementation *must* include this function
let cat : (string[] -> int) =
    // cat should use currying to call catWithBufferSize with a default buffersize of 32
    // Replace below with a proper implementation
    (fun _ -> 0)

