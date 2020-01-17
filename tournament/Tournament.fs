module Tournament

type Entry =
    { team: string
      mp: int
      w: int
      d: int
      l: int
      p: int }

let toPoints (s: string) =
    match s.Split([| ';' |]) with
    | [| a; b; "win" |] ->
        [ (a, 3)
          (b, 0) ]
    | [| a; b; "loss" |] ->
        [ (a, 0)
          (b, 3) ]
    | [| a; b; "draw" |] ->
        [ (a, 1)
          (b, 1) ]
    | _ -> []

let sumBy p =
    List.sumBy (fun (_, x) ->
        if x = p then 1 else 0)

let countPoints list =
    { team =
          list
          |> List.head
          |> fst
      mp = List.length list
      w = sumBy 3 list
      d = sumBy 1 list
      l = sumBy 0 list
      p = List.sumBy snd list }


let formatEntry e = sprintf "%-30s | %2i | %2i | %2i | %2i | %2i" e.team e.mp e.w e.d e.l e.p

let tally input =
    [ "Team                           | MP |  W |  D |  L |  P" ] @ (input
                                                                     |> List.collect toPoints
                                                                     |> List.groupBy fst
                                                                     |> List.map (snd >> countPoints)
                                                                     |> List.sortBy (fun e -> (-e.p, -e.mp, e.team))
                                                                     |> List.map formatEntry)
