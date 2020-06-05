module ILazy

/// Интерфейс для ленивых вычислений
type ILazy<'a> =
    /// Возвращает результат
    abstract member Get: unit -> 'a