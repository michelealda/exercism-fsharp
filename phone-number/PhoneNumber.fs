module PhoneNumber

open System

let checkLetters xs =
    match Seq.tryFind Char.IsLetter xs with
    | Some _ -> Error "letters not permitted"
    | None -> Ok xs

let checkPunctuations xs =
    match Seq.tryFind Char.IsPunctuation xs with
    | Some _ -> Error "punctuations not permitted"
    | None -> Ok xs


let removeValidCharacters xs =
    Seq.fold (fun acc c ->
        if Seq.contains c [ '('; ')'; '.'; '+'; ' '; '-' ] then acc
        else (Seq.append acc [ c ])) Seq.empty xs
    |> Ok


let validateLenght xs =
    match (Seq.length xs, Seq.head xs) with
    | (10, _) -> Ok xs
    | (11, '1') ->
        xs
        |> Seq.tail
        |> Ok
    | (11, _) -> Error "11 digits must start with 1"
    | (x, _) when x < 10 -> Error "incorrect number of digits"
    | _ -> Error "more than 11 digits"

let validateAreaCode xs =
    match Seq.head xs with
    | '0' -> Error "area code cannot start with zero"
    | '1' -> Error "area code cannot start with one"
    | _ -> Ok xs

let validateExchangeCode xs =
    match Seq.item 3 xs with
    | '0' -> Error "exchange code cannot start with zero"
    | '1' -> Error "exchange code cannot start with one"
    | _ -> Ok xs


let mapToResult xs =
    xs
    |> Array.ofSeq
    |> String
    |> uint64
    |> Ok

let clean (s: string): Result<uint64, string> =
    s
    |> removeValidCharacters
    |> Result.bind checkLetters
    |> Result.bind checkPunctuations
    |> Result.bind validateLenght
    |> Result.bind validateAreaCode
    |> Result.bind validateExchangeCode
    |> Result.bind mapToResult
 