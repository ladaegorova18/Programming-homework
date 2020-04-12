module Stack

/// Потокобезопасный стек
type MyStack<'T>() =    
    let mutable stack : List<'T> = []
    
    /// Верхний элемент стека
    member this.Top = 
        lock stack (fun () ->
            match stack with
            | value :: _ ->
               value |> Some
            | [] -> None
         )

    /// Добавление элемента в стек
    member this.Push value =
      lock stack (fun () -> 
         stack <- value :: stack)

    /// Удаление элемента из стека
    member this.TryPop() =
      lock stack (fun () ->
         match stack with
         | value :: newStack ->
            stack <- newStack
            value |> Some
         | [] -> None
      )

    /// Пустой ли стек
    member this.Empty = stack.IsEmpty 
