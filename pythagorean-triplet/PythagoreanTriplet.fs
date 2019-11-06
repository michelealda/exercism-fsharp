module PythagoreanTriplet

let tripletsWithSum sum =
    seq {
        for a in 1 .. (sum / 3) do
            for b in (a + 1) .. (sum / 2) do
                let c = sum - a - b
                if (a * a + b * b = c * c) then yield (a, b, c)
    }
    |> Seq.toList
