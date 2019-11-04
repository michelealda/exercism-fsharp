module BinarySearchTree

type Node =
    { data: int
      left: Node option
      right: Node option }

let left node = node.left

let right node = node.right

let data node = node.data

let createNode x =
    { data = x
      left = None
      right = None }

let rec createTree (tree: Node) x =
    let pushTo node value =
        match node with
        | Some x -> createTree x value
        | None -> createNode value
        |> Some

    if x <= tree.data then { tree with left = pushTo tree.left x }
    else { tree with right = pushTo tree.right x }

let create items =
    match items with
    | [] -> failwith "error"
    | x :: xs -> List.fold createTree (createNode x) xs

let sortedData node =
    let rec traverse =
        function
        | Some x -> (traverse x.left) @ [ x.data ] @ (traverse x.right)
        | None -> []

    node
    |> Some
    |> traverse
