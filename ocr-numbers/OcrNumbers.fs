module OcrNumbers
open System

let convertNumber (f: string) (s: string) (t: string) =
    match f + s + t with
    | " _ | ||_|" -> Some "0"
    | "     |  |" -> Some "1"
    | " _  _||_ " -> Some "2"
    | " _  _| _|" -> Some "3"
    | "   |_|  |" -> Some "4"
    | " _ |_  _|" -> Some "5"
    | " _ |_ |_|" -> Some "6"
    | " _   |  |" -> Some "7"
    | " _ |_||_|" -> Some "8"
    | " _ |_| _|" -> Some "9"
    | _ when s.Length <> 9 -> Some "?"
    | _ -> None

let aggregate mapper joiner ls =
    ls
    |> Seq.fold (fun a i -> match a, (mapper i)  with
                                | Some "", Some y -> Some y 
                                | Some x, Some y -> Some (joiner x y)
                                | _, None -> None
                                | None, _ -> None) (Some "")

let splitLine line =
    line |> Seq.chunkBySize 3 |> Seq.map String

let convertNumbers (f: string) (s: string) (t: string) =
    Seq.zip3 (splitLine f) (splitLine s) (splitLine t)
    |> aggregate (fun (x,y,z) -> convertNumber x y z) (+)

let convertLine (line : string list) = 
    match line with
    | [first;second;third;fourth] -> 
        if String.IsNullOrWhiteSpace fourth && fourth.Length % 3 = 0
        then convertNumbers first second third
        else None
    | [] 
    | _ -> None

let convert (input: string list) =
    input
    |> List.chunkBySize 4
    |> aggregate convertLine (fun x y -> x + ","+ y)
    
    