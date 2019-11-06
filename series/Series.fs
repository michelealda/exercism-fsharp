module Series

open System

let slices (str: string) length =
    match length with
    | x when x <= 0 || x > Seq.length str -> None
    | x ->
        str
        |> Seq.windowed x
        |> Seq.map (String.Concat)
        |> Seq.toList
        |> Some
