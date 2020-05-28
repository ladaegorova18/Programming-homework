module Reduction

/// Лямбда-терм, бывает трёх видов
type Term =
    | Variable of char
    | LambdaAbstraction of char * Term
    | Application of Term * Term

/// Свободна переменная в выражении или нет
let rec free expression var =
    match expression with
    | Variable x -> x = var
    | LambdaAbstraction(x, e) -> x <> var && free e var
    | Application(left, right) -> free left var || free right var

/// Замена переменной в выражении
let rec termSubstitution prev newVar expression =
    let variables = ['a'..'z']
    match expression with
    | Variable x when x = prev -> newVar
    | Variable _ -> expression
    | LambdaAbstraction(x, _) when x = prev -> expression
    | LambdaAbstraction(x, exp) when not <| free newVar x -> LambdaAbstraction(x, termSubstitution prev newVar exp)
    | LambdaAbstraction(x, exp) ->
        let newSym = variables |> List.filter (not << free newVar) |> List.head
        LambdaAbstraction(newSym, termSubstitution prev newVar <| termSubstitution x (Variable newSym) exp)
    | Application(left, right) -> Application(termSubstitution prev newVar left, termSubstitution prev newVar right)
    
/// Бета-редукция выражения
let betaReduction (expression: Term) =
    let rec betaReductionRec expression =
        match expression with
        | Variable x -> Variable(x)
        | LambdaAbstraction (var, term) -> 
            LambdaAbstraction (var, term |> betaReductionRec)
        | Application (LambdaAbstraction (var, termLeft), termRight) ->
            termLeft |> termSubstitution var termRight |> betaReductionRec
        | Application (left, right) ->
            let leftReduce = left |> betaReductionRec
            match leftReduce with 
            | LambdaAbstraction(_) -> Application (leftReduce, right) |> betaReductionRec
            | _ -> Application (leftReduce, right |> betaReductionRec)
    betaReductionRec expression