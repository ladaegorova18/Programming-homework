module Parse

/// type of arithmetic expression 
type Expression =
    | Int of int
    | Sum of Expression * Expression
    | Multiply of Expression * Expression
    | Subtract of Expression * Expression
    | Divide of Expression * Expression

/// parsing expression tree
let rec parseTree expression =
    match expression with
    | Int x -> x
    | Sum(x, y) -> parseTree x + parseTree y
    | Multiply(x, y) -> parseTree x * parseTree y
    | Subtract(x, y) -> parseTree x - parseTree y
    | Divide(x, y) -> parseTree x / parseTree y
