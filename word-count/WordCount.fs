module WordCount

open System

let (|LetterOrDigit|Split|Skip|) c =
    if Char.IsLetterOrDigit c then LetterOrDigit
    else if c = ''' then LetterOrDigit
    else if Char.IsControl c then Split
    else if Char.IsWhiteSpace c then Split
    else if Char.IsPunctuation c then Split
    else Skip

let appendTo p w =
    if w <> Seq.empty then Seq.append p [ w ]
    else p

let cleanString (phrase: string) =
    phrase
    |> Seq.fold (fun (p, w) c ->
        match c with
        | LetterOrDigit -> (p, Seq.append w [ Char.ToLowerInvariant c ])
        | Split -> (appendTo p w, Seq.empty)
        | Skip -> (p, w)) (Seq.empty, Seq.empty)
    |> fun (p, w) -> appendTo p w
    |> Seq.map (fun s ->
        s
        |> Seq.map string
        |> String.Concat
        |> (fun x -> x.Trim(''')))

let countWords (phrase: string) =
    phrase
    |> cleanString
    |> Seq.groupBy id
    |> Map.ofSeq
    |> Map.map (fun _ v -> Seq.length v)
