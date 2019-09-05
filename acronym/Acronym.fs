module Acronym
open System

let (|LetterOrDigit|Whitespace|Dash|Other|) c =
    if Char.IsLetterOrDigit c then LetterOrDigit
    else if Char.IsWhiteSpace c then Whitespace
    else if '-' = c then Dash
    else Other

let folder (upper, state) c =
    match c, upper with
    | LetterOrDigit, true -> (false, state@[c |> Char.ToUpper])
    | LetterOrDigit, false -> (false, state)
    | Whitespace, _ 
    | Dash, _ -> (true, state)
    | Other, _ -> (upper, state)

let abbreviate phrase =
    phrase
    |> Seq.fold folder (true, [])
    |> snd 
    |> Array.ofList
    |> String
