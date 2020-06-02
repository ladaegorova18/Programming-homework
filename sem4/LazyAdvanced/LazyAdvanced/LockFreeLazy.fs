module LockFreeLazy

open ILazy
open System.Threading

/// Мультипоточный Lazy без блокировок
type LockFreeLazy<'a>(supplier: (unit -> 'a)) =
    [<VolatileField>]
    let mutable startVal = None
    let mutable desiredVal = None
    let mutable currentVal = None
    let mutable counted = false

    /// При вычислении более одного раза результаты "лишних" вычислений теряются
    interface ILazy<'a> with
        member l.Get() =
            if (not counted) then
                startVal <- currentVal
                desiredVal <- Some(supplier())
                Interlocked.CompareExchange(ref currentVal, desiredVal, None) |> ignore
                counted <- true
            desiredVal.Value
                    