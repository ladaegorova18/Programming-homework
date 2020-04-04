module Stack

// Stack to collect char values
type MyStack =
    | MyStack of char * MyStack
    | Empty
    with 
     member stack.Top  =
         match stack with
         | MyStack(hd, _) -> hd
         | Empty -> invalidOp "stack is empty!"

     member stack.Push element = MyStack(element, stack)

     member stack.Pop =
         match stack with 
             | MyStack(_, tl) -> tl
             | Empty -> invalidOp "stack is empty!"

     member stack.EmptyStack =
         match stack with
         | MyStack(hd, _)-> false
         | Empty -> true
