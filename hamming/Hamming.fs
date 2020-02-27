module Hamming

let distance (strand1: string) (strand2: string): int option =
    match strand1.Length - strand2.Length with
    | 0 ->
        strand2
        |> Seq.zip strand1
        |> Seq.sumBy (fun (a, b) ->
            if a = b then 0 else 1)
        |> Some
    | _ -> None
