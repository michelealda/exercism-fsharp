module PigLatin

let isVowel c = List.contains c [ 'a'; 'e'; 'i'; 'o'; 'u' ]

let rec rule input =
    match input with
    | c :: _ when isVowel c -> input @ [ 'a'; 'y' ]
    | 'x' :: 'r' :: _ -> input @ [ 'a'; 'y' ]
    | 'y' :: 't' :: _ -> input @ [ 'a'; 'y' ]
    | [ 'y'; c ] -> input @ [ 'a'; 'y' ]
    | 'q' :: 'u' :: rest -> rest @ [ 'q'; 'u'; 'a'; 'y' ]
    | c :: rest -> rule (rest @ [ c ])
    | _ -> input

let translateWord input =
    input
    |> rule
    |> List.fold (fun acc c -> acc + (string c)) ""

let translate (input: string) =
    input.Split(' ')
    |> Array.map (Seq.toList >> translateWord)
    |> String.concat " "
