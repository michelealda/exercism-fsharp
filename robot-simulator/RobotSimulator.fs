module RobotSimulator

type Direction = 
      North 
    | East 
    | South 
    | West

type Position = int * int
type Robot = { direction: Direction; position: Position }

let create direction position = {direction = direction; position = position}

let rotateRight robot =
    let newDirection = 
        match robot.direction with
        | North -> East
        | East -> South
        | South -> West
        | West -> North
    {robot with direction=newDirection }

let rotateLeft robot =
    let newDirection = 
        match robot.direction with
        | North -> West
        | West -> South
        | South -> East
        | East -> North        
    {robot with direction=newDirection }

let advance robot =
    let newPosition = 
        match robot.direction with
        | North -> (fun (x, y) -> (x, y+1))
        | East -> (fun (x,y) -> (x+1, y))
        | South -> (fun (x,y) -> (x, y-1))
        | West -> (fun (x,y) -> (x-1, y))
    {robot with position = newPosition robot.position}

let move instructions robot = 
    instructions
    |> Seq.fold (fun r c -> match c with 
                            | 'A' -> advance r
                            | 'R' -> rotateRight r
                            | 'L' -> rotateLeft r
                            | _ -> r) robot
