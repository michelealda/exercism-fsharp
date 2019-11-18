module ParallelLetterFrequency

open System

let calculateFrequencyAsync (xs: string) =
    async {
        return xs.ToLowerInvariant()
               |> Seq.filter (Char.IsLetter)
               |> Seq.groupBy id
               |> Seq.map (fun (k, s) -> (k, Seq.length s))
    }

let frequency (texts: string list) =
    texts
    |> List.map calculateFrequencyAsync
    |> Async.Parallel
    |> Async.RunSynchronously
    |> Seq.concat
    |> Seq.fold (fun acc (c, x) ->
        match Map.tryFind c acc with
        | Some k -> acc.Add(c, k + x)
        | None -> acc.Add(c, x)) Map.empty
 