module Stack

// Stack to collect char values
type MyStack =
    | MyStack of char * MyStack
    | Empty
    with
     // Value in the stack's top
     member stack.Top  =
         match stack with
         | MyStack(hd, _) -> hd
         | Empty -> invalidOp "Stack is empty!"

     // Add value to stack
     member stack.Push element = MyStack(element, stack)

     // Take value from stack
     member stack.Pop =
         match stack with 
             | MyStack(_, tl) -> tl
             | Empty -> invalidOp "Stack is empty!"

     // Is the stack empty?
     member stack.EmptyStack =
         match stack with
         | MyStack(hd, _)-> false
         | Empty -> true
