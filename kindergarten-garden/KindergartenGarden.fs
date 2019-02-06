module KindergartenGarden

type Plant = 
      Violets = 'V' 
    | Radishes ='R'
    | Clover = 'C'
    | Grass = 'G'

let Students = ["Alice"; "Bob"; "Charlie"; 
 "David"; "Eve"; "Fred"; "Ginny";
 "Harriet"; "Ileana"; "Joseph"; 
 "Kincaid"; "Larry" ]

let sliceGardens (index :int) (gardens: string[])  =
    gardens
    |> Seq.fold (fun acc g -> acc + (g.[(index*2)..(index*2)+1])) ""
    
let plants (diagram: string) (student:string) = 
    match Seq.tryFindIndex ((=) student) Students with
    | Some x -> diagram.Split [|'\n'|]
                |> sliceGardens x
                |> Seq.map (LanguagePrimitives.EnumOfValue)
                |> List.ofSeq
    | None -> List.empty<Plant>
    

    