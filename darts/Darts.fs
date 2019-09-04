module Darts
open System
let score (x: double) (y: double): int = 
    (x * x) + (y * y) 
    |> float 
    |> Math.Sqrt
    |> fun r ->
        if r <= 1.0 then 10
        else if r <= 5.0 then 5
        else if r <= 10.0 then 1
        else 0