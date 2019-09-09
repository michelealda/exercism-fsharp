module Dominoes

let removeAt index list =
    list |> List.indexed |> List.filter (fun (i, _) -> i <> index) |> List.map snd

let combine (a, b) (c, d) =
    if a = c then (b, d)
    else if a = d then (b, c)
    else if b = c then (a, d)
    else (a, c)

let proc (a,b) tail =
    let x = List.tryFindIndex (fun (c, d) -> a = c || a = d) tail
    match x with
    | None -> None
    | Some i -> 
        let item = List.item i tail
        let rest = removeAt i tail
        let newHead = combine (a, b) item
        Some ([newHead]@rest)

let rec canChain (input: (int*int) list) : bool =
    match input with
    | [] -> true
    | [(a,b)] -> a = b
    | (a, b)::t -> proc (a,b) t 
                    |> function
                        | Some l -> canChain l
                        | None -> false
        
            

