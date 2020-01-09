module ScaleGenerator

let sharp = [ "A"; "A#"; "B"; "C"; "C#"; "D"; "D#"; "E"; "F"; "F#"; "G"; "G#" ]
let flat = [ "A"; "Bb"; "B"; "C"; "Db"; "D"; "Eb"; "E"; "F"; "Gb"; "G"; "Ab" ]

let pickScale (tonic: string) =
    match tonic with
    | "C"
    | "a" -> sharp
    | "G"
    | "D"
    | "A"
    | "E"
    | "B"
    | "F#"
    | "e"
    | "b"
    | "f#"
    | "c#"
    | "g#"
    | "d#" -> sharp
    | _ -> flat

let findPitch (tonic: string) scale =
    List.findIndex (fun (x: string) -> tonic.ToUpperInvariant() = x.ToUpperInvariant()) scale

let interval (intervals: string) tonic =
    let scale = pickScale tonic
    let i = findPitch tonic scale

    intervals
    |> Seq.fold (fun (x, pitches) step ->
        let index =
            match step with
            | 'M' -> (x + 2) % 12
            | 'm' -> (x + 1) % 12
            | 'A' -> (x + 3) % 12
            | _ -> x
        (index, pitches @ [ (scale.[index]) ])) (i, [ scale.[i] ])
    |> snd
    |> List.take (intervals.Length)


let chromatic tonic = interval "mmmmmmmmmmmm" tonic
