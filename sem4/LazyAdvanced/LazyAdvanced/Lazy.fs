module Lazy

open ILazy

/// Lazy — интерфейс, предоставляющий ленивое вычисление
/// Корректно работает в однопоточном режиме
type Lazy<'a>(supplier: (unit -> 'a)) =
    let mutable result = None
    interface ILazy<'a> with

        /// Возвращает результат, если он уже был вычислен
        /// Вычисляет результат, если он ещё не был вычислен
        member l.Get() =
            match result with 
            | Some x -> x
            | None -> 
                result <- Some(supplier())
                result.Value