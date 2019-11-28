module IsbnVerifier

open System

let cleanChars xs = Seq.filter (fun c -> c = 'X' || Char.IsDigit c) xs

let validateLenght xs =
    if Seq.length xs <> 10 then None
    else Some xs

let sumIsbn xs =
    xs
    |> Seq.mapi (fun i c ->
        match (10 - i, c) with
        | (1, 'X') -> Some 10
        | (_, 'X') -> None
        | (i, c) ->
            c
            |> string
            |> int
            |> (*) i
            |> Some)
    |> Seq.fold (fun acc o -> Option.map2 (+) acc o) (Some 0)

let isValid (isbn: string) =
    isbn
    |> cleanChars
    |> validateLenght
    |> Option.bind sumIsbn
    |> function
    | Some sum -> (sum % 11) = 0
    | None -> false
 