module ArmstrongNumbers

let isArmstrongNumber (number: int): bool = 
    let xs = number 
            |> string
            |> (fun s -> s.ToCharArray())
            // convert from the ascii code to the int value
            |> Seq.map (fun c -> int c - int '0') 
                        
    xs        
    |> Seq.sumBy (fun x -> Seq.length xs |> pown x )
    |> (=) number
