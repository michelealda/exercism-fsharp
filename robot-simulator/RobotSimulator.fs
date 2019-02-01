module RobotSimulator

type Direction = 
      North 
    | East 
    | South 
    | West

type Position = int * int
type Robot = { direction: Direction; position: Position }

let create direction position = {direction = direction; position = position}

let rotate robot =
    let newDirection = 
        match robot.direction with
        | North -> East
        | East -> South
        | South -> West
        | West -> North
    {robot with direction=newDirection }

let advance robot =
    let newPosition = 
        match robot.direction with
        | North -> (fun (x, y) -> (x+1, y))
        | East -> (fun (x,y) -> (x, y+1))
        | South -> (fun (x,y) -> (x, y-1))
        | West -> (fun (x,y) -> (x-1, y))
    {robot with position = newPosition robot.position}

let move instructions robot = 
    instructions
    |> Seq.fold (fun r c -> match c with 
                            | 'A' -> advance r
                            | 'R' -> rotate r
                            | _ -> r) robot
