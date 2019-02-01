module Clock

let create hours minutes = 
    (60*hours) + minutes
    |> (fun totalMinutes -> 1440+(totalMinutes%1440))
    |> (fun x -> ((x/60)%24, x%60))
    

let add minutes clock =
    clock 
    |> (fun (h,m) -> (h, m+minutes))
    ||> create

let subtract minutes clock = add (-minutes) clock

let display clock = clock ||> sprintf "%02i:%02i" 
