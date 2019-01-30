module SumOfMultiples

let isMultiple (numbers: int list, v: int): bool =
    numbers
    |> List.filter (fun x -> x <> 0)
    |> List.fold (fun acc n -> (v%n = 0) || acc) false

let sum (numbers: int list) (upperBound: int): int =
    [0 ..upperBound-1]
    |> List.filter (fun x -> isMultiple(numbers, x))
    |> List.sum
