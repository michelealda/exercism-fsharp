module Isogram

open System

let isIsogram str =
    str
    |> Seq.filter Char.IsLetter
    |> Seq.countBy Char.ToLowerInvariant
    |> Seq.forall (fun (_, v) -> v = 1)
