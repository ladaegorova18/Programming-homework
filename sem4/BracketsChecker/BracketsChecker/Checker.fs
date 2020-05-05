module Checker

open Stack

/// Являются ли два символа открывающей и закрывающей скобками
let balanced first second = 
    first = '(' && second = ')' ||
    first = '{' && second = '}' ||
    first = '[' && second = ']' 

/// Закрывающая скобка или нет
let closeBracket x = 
    x = ')' || x = '}' || x = ']'

/// Checks a bracket balance in line
let bracketsChecker line =
    let rec recChecker lineToCheck (stack : MyStack) =
        match lineToCheck with
        | [] -> stack.EmptyStack
        | x :: tail -> 
            if (x = '(' || x = '{' || x = '[') then recChecker tail (stack.Push x)
            else if (not stack.EmptyStack && balanced stack.Top x) then
                recChecker tail stack.Pop
            else if (closeBracket x) then recChecker tail (stack.Push x)
            else recChecker tail stack
    recChecker (Seq.toList(line)) Empty


