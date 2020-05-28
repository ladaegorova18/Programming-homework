module MapTree

/// tree of nodes with values and empty nodes
type Tree<'a> =
    | Node of 'a * Tree<'a> * Tree<'a> 
    | Empty

/// applies function to every tree's node and returns new tree
let rec mapTree func tree =
    match tree with
    | Empty -> Empty
    | Node(x, l, r) -> Node(func x, mapTree func l, mapTree func r)