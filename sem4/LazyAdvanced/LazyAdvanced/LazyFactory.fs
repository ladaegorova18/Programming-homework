module LazyFactory

open ILazy
open Lazy
open MultiThreadedLazy
open LockFreeLazy

/// Создаёт Lazy-объект одного из трёх типов для выполнения ленивых вычислений
type LazyFactory<'a>(supplier: ('a -> 'a)) =
    static member CreateSingleThreadedLazy supplier = new Lazy<'a>(supplier) :> ILazy<'a>

    static member CreateMultiThreadedLazy supplier = new MultiThreadedLazy<'a>(supplier) :> ILazy<'a>

    static member CreateLockFreeLazy supplier = new LockFreeLazy<'a>(supplier) :> ILazy<'a>