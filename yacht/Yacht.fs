module Yacht

type Category =
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Dice =
    | One
    | Two
    | Three
    | Four
    | Five
    | Six

let mapToInt dice =
    match dice with
    | One -> 1
    | Two -> 2
    | Three -> 3
    | Four -> 4
    | Five -> 5
    | Six -> 6

let group (dices: Dice list) =
    dices
    |> List.map mapToInt
    |> List.groupBy id
    |> List.map (fun (id, list) -> (id, List.length list))
    |> List.sortByDescending snd

let count dice grouped =
    grouped
    |> List.tryFind (fun (k, _) -> k = dice)
    |> function
    | Some(x, count) -> x * count
    | None -> 0

let straight list groups =
    list
    |> List.except (List.map fst groups)
    |> fun r ->
        if List.isEmpty r then 30 else 0

let score category dices =
    dices
    |> group
    |> fun g ->
        match category with
        | Ones -> count 1 g
        | Twos -> count 2 g
        | Threes -> count 3 g
        | Fours -> count 4 g
        | Fives -> count 5 g
        | Sixes -> count 6 g
        | FullHouse ->
            match g with
            | [ (a, b); (c, d) ] when b = 3 -> a * b + c * d
            | _ -> 0
        | FourOfAKind ->
            match g with
            | (a, b) :: _ when b >= 4 -> a * 4
            | _ -> 0
        | LittleStraight -> straight [ 1 .. 5 ] g
        | BigStraight -> straight [ 2 .. 6 ] g
        | Choice -> g |> List.sumBy (fun (a, b) -> a * b)
        | Yacht ->
            if List.length g = 1 then 50 else 0
        | _ -> 0
