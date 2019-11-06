module PascalsTriangle

let generateNext xs =
    xs
    |> List.mapi (fun i k ->
        match i with
        | 0 -> 1
        | j -> xs.[j - 1] + k)
    |> fun ys -> ys @ [ 1 ]

let rows numberOfRows: int list list =
    match numberOfRows with
    | 0 -> []
    | _ ->
        List.fold (fun acc _ ->
            let next =
                acc
                |> List.last
                |> generateNext
            acc @ [ next ]) [ [ 1 ] ] [ 2 .. numberOfRows ]
 