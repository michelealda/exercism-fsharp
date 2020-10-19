module DotDsl

type Kind =
    | Attr of (string * string)
    | Node of string * (string * string) list
    | Edge of string * string * (string * string) list

let graph = List.sort

let attr key value = Attr(key, value)

let node key attrs = Node(key, attrs)

let edge left right attrs = Edge(left, right, attrs)

let extract fn = List.choose fn

let attrs graph =
    extract (fun e ->
        match e with
        | Attr _ -> Some e
        | _ -> None) graph

let nodes graph =
    extract (fun e ->
        match e with
        | Node _ -> Some e
        | _ -> None) graph

let edges graph =
    extract (fun e ->
        match e with
        | Edge _ -> Some e
        | _ -> None) graph
