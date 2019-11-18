module Ledger

open System
open System.Globalization

type Entry =
    { dat: DateTime
      des: string
      chg: int }

let mkEntry date description change =
    { dat = DateTime.Parse(date, CultureInfo.InvariantCulture)
      des = description
      chg = change }

let (|American|Dutch|) locale =
    if locale = "en-US" then American
    else Dutch

let (|Dollar|Euro|) currency =
    if currency = "USD" then Dollar
    else Euro

let formatDate locale (date: DateTime) =
    match locale with
    | American -> date.ToString("MM\/dd\/yyyy")
    | Dutch -> date.ToString("dd-MM-yyyy")

let formatDescription (s: string) =
    match s.Length with
    | 25 -> s
    | x when x <= 25 -> s.PadRight(25)
    | _ -> s.[0..21] + "..."

let formatChange (locale: string) currency (c: float) =
    let formatValue (l: string) symbol format (value: float) =
        value.ToString("#,#0.00", CultureInfo(l)) |> sprintf format symbol

    let output =
        match currency with
        | Dollar -> "$"
        | Euro -> "€"
        |> formatValue locale

    match (locale, c < 0.0) with
    | (American, true) ->
        c
        |> abs
        |> output "(%s%s)"
    | (American, false) -> c |> output "%s%s "
    | (Dutch, true) -> c |> output "%s %s"
    | (Dutch, false) -> c |> output "%s %s "
    |> fun x -> x.PadLeft(13)

let formatEntry locale currency (e: Entry) =
    (formatDate locale e.dat) + " | " + (formatDescription e.des) + " | "
    + (formatChange locale currency (float e.chg / 100.0))

let formatLedger currency locale entries =

    let header =
        match locale with
        | Dutch -> "Datum      | Omschrijving              | Verandering  "
        | American -> "Date       | Description               | Change       "

    [ header ] @ (entries
                  |> List.sortBy (fun x -> x.dat, x.des, x.chg)
                  |> List.map (formatEntry locale currency))
    |> String.concat "\n"
