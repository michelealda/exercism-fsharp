module LargestSeriesProduct

open System

let generate n (xs: string) =
    List.init (Seq.length xs - n + 1) (fun i -> xs.[i..i + n - 1])
    |> List.map (fun s ->
        s
        |> Seq.map (string >> int)
        |> Seq.reduce (*))
    |> List.max

let validateInput input =
    match Seq.tryFind (Char.IsDigit >> not) input with
    | Some _ -> None
    | None -> Some input

let validateSeriesLenght n validatedInput =
    match n with
    | 0 -> Some 1
    | x when x < 0 -> None
    | x when x > Seq.length validatedInput -> None
    | x ->
        validatedInput
        |> generate x
        |> Some

let largestProduct input seriesLength: int option =
    validateInput input |> Option.bind (validateSeriesLenght seriesLength)
