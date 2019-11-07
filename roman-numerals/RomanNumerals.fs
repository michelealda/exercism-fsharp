module RomanNumerals

open System

let one = "I"
let five = "V"
let ten = "X"
let fifty = "L"
let hundred = "C"
let fiveHundred = "D"
let thousand = "M"

let translate divisor a b c (n, s) =
    let v =
        match n / divisor with
        | 1 -> a
        | 2 -> a + a
        | 3 -> a + a + a
        | 4 -> a + b
        | 5 -> b
        | 6 -> b + a
        | 7 -> b + a + a
        | 8 -> b + a + a + a
        | 9 -> a + c
        | _ -> ""
    (n % divisor, s + v)

let units = translate 1 one five ten
let decimals = translate 10 ten fifty hundred
let hundreds = translate 100 hundred fiveHundred thousand
let thousands = translate 1000 thousand "" ""

let roman arabicNumeral =
    [ thousands; hundreds; decimals; units ]
    |> List.fold (|>) (arabicNumeral, "")
    |> snd
