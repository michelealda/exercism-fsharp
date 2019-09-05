module Anagram
open System

let toKey x = 
    x 
    |> Seq.map Char.ToLower 
    |> Seq.sort
    |> Seq.toArray 
    |> String

let findAnagrams (sources: string list) (target: string) = 
    let wordKey = toKey target
    sources
    |> List.filter (toKey >> (=) wordKey)
    |> List.filter (fun s -> s.ToLower() <> target.ToLower())
    