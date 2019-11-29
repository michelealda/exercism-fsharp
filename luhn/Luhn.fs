module Luhn

open System

let validate xs =
    xs
    |> Seq.filter (Char.IsWhiteSpace >> not)
    |> fun s ->
        if Seq.forall (Char.IsDigit) s then Some s
        else None
    |> Option.bind (fun s ->
        match Seq.length s with
        | 0
        | 1 -> None
        | _ -> Some s)

let calculate xs =
    xs
    |> Seq.rev
    |> Seq.mapi (fun i x ->
        match (i % 2, x * 2) with
        | (1, v) when v > 9 -> v - 9
        | (1, v) -> v
        | (_, _) -> x)

let valid number =
    number
    |> validate
    |> Option.map (Seq.map (string >> int))
    |> Option.map calculate
    |> Option.map Seq.sum
    |> function
    | Some x -> x % 10 = 0
    | None -> false
