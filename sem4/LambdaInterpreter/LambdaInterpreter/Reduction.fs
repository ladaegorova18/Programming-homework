module Reduction

open System

type Term =
    | Variable of char
    | LambdaAbstraction of char * Term
    | Application of Term * Term
    