module Meetup

open System

type Week =
    | First
    | Second
    | Third
    | Fourth
    | Last
    | Teenth

let meetup year month week dayOfWeek: DateTime =
    let finder (ds: DateTime seq) = ds |> Seq.find (fun d -> d.DayOfWeek = dayOfWeek)

    let findFn =
        match week with
        | First -> Seq.take 7 >> finder
        | Second ->
            Seq.skip 7
            >> Seq.take 7
            >> finder
        | Third ->
            Seq.skip 14
            >> Seq.take 7
            >> finder
        | Fourth ->
            Seq.skip 21
            >> Seq.take 7
            >> finder
        | Last -> Seq.rev >> finder
        | Teenth -> Seq.filter (fun d -> d.Day >= 13 && d.Day <= 19) >> finder

    DateTime(year, month, 1)
    |> Seq.unfold (fun (d: DateTime) ->
        if d.Month = month then Some(d, d.AddDays(1.0))
        else None)
    |> findFn
 