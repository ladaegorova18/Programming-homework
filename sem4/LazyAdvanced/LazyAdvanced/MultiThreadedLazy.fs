module MultiThreadedLazy

open ILazy

/// Мультипоточный Lazy с блокировками
type MultiThreadedLazy<'a>(supplier: (unit -> 'a)) =
    [<VolatileField>]
    let mutable result = None
    let locker = new obj()
    interface ILazy<'a> with

        /// Вычисление производится не больше одного раза
        member l.Get() =
            match result with
            | Some x -> x
            | None -> 
                lock (locker) <| fun unit -> match result with
                | Some x -> x
                | None ->
                    result <- Some(supplier())
                    result.Value
                