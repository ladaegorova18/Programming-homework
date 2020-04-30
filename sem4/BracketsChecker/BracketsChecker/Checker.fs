module Checker

open Stack

// Checks a bracket balance in line
let oneTypeBracketsChecker (openBracket, closeBracket, equals, line) =
    let rec recChecker lineToCheck (stack : MyStack) =
        match lineToCheck with
        | [] -> stack.EmptyStack
        | x :: tail -> 
            if (equals openBracket x) then
                recChecker tail (stack.Push x)
            elif not stack.EmptyStack
                && equals closeBracket x && equals stack.Top openBracket then
                    recChecker tail stack.Pop
            else if (not (equals closeBracket x || equals openBracket x)) then
                recChecker tail stack
            else false
    recChecker (Seq.toList(line)) Empty

// Checks a bracket balance for all bracket types 
let bracketsChecker line =
    oneTypeBracketsChecker ('{', '}', (=), line) &&
    oneTypeBracketsChecker ('(', ')', (=), line) &&
    oneTypeBracketsChecker ('[', ']', (=), line) 

