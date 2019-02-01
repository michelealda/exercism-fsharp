module QueenAttack
open System

let create (position: int * int) = 
    let x,y = position  
    (x >= 0 && x < 8) &&
    (y >= 0 && y < 8) 


let canAttack (queen1: int * int) (queen2: int * int) = 
    let r1,c1 = queen1 
    let r2,c2 = queen2
    match (Math.Abs (r1-r2), Math.Abs (c1-c2)) with
    | (0,0) -> false
    | (0,_) 
    | (_,0) -> true
    | (a, b) when a = b -> true
    | (_, __) -> false