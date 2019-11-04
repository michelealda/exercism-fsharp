module Poker

open System
// TODO: implement this module
type Suit =
    | Heart
    | Spade
    | Club
    | Diamond

type Value =
    | Number of int
    | Jack
    | Queen
    | King
    | Ace

type Card =
    { value: Value
      suit: Suit }

type Hand = Card list

let bestHands xs = xs
