// This file was auto-generated based on version 1.2.0 of the canonical data.

module YachtTest

open FsUnit.Xunit
open Xunit

open Yacht

[<Fact>]
let Yacht() = score Yacht [ Five; Five; Five; Five; Five ] |> should equal 50

[<Fact>]
let ``Not Yacht``() = score Category.Yacht [ One; Three; Three; Two; Five ] |> should equal 0

[<Fact>]
let Ones() = score Ones [ One; One; One; Three; Five ] |> should equal 3

[<Fact>]
let ``Ones, out of order``() = score Category.Ones [ Three; One; One; Five; One ] |> should equal 3

[<Fact>]
let ``No ones``() = score Category.Ones [ Four; Three; Six; Five; Five ] |> should equal 0

[<Fact>]
let Twos() = score Twos [ Two; Three; Four; Five; Six ] |> should equal 2

[<Fact>]
let Fours() = score Fours [ One; Four; One; Four; One ] |> should equal 8

[<Fact>]
let ``Yacht counted as threes``() = score Threes [ Three; Three; Three; Three; Three ] |> should equal 15

[<Fact>]
let ``Yacht of 3s counted as fives``() = score Fives [ Three; Three; Three; Three; Three ] |> should equal 0

[<Fact>]
let Sixes() = score Sixes [ Two; Three; Four; Five; Six ] |> should equal 6

[<Fact>]
let ``Full house two small, three big``() = score FullHouse [ Two; Two; Four; Four; Four ] |> should equal 16

[<Fact>]
let ``Full house three small, two big``() = score FullHouse [ Five; Three; Three; Five; Three ] |> should equal 19

[<Fact>]
let ``Two pair is not a full house``() = score FullHouse [ Two; Two; Four; Four; Five ] |> should equal 0

[<Fact>]
let ``Four of a kind is not a full house``() = score FullHouse [ One; Four; Four; Four; Four ] |> should equal 0

[<Fact>]
let ``Yacht is not a full house``() = score FullHouse [ Two; Two; Two; Two; Two ] |> should equal 0

[<Fact>]
let ``Four of a Kind``() = score FourOfAKind [ Six; Six; Four; Six; Six ] |> should equal 24

[<Fact>]
let ``Yacht can be scored as Four of a Kind``() =
    score FourOfAKind [ Three; Three; Three; Three; Three ] |> should equal 12

[<Fact>]
let ``Full house is not Four of a Kind``() = score FourOfAKind [ Three; Three; Three; Five; Five ] |> should equal 0

[<Fact>]
let ``Little Straight``() = score LittleStraight [ Three; Five; Four; One; Two ] |> should equal 30

[<Fact>]
let ``Little Straight as Big Straight``() = score BigStraight [ One; Two; Three; Four; Five ] |> should equal 0

[<Fact>]
let ``Four in order but not a little straight``() =
    score LittleStraight [ One; One; Two; Three; Four ] |> should equal 0

[<Fact>]
let ``No pairs but not a little straight``() = score LittleStraight [ One; Two; Three; Four; Six ] |> should equal 0

[<Fact>]
let ``Minimum is 1, maximum is 5, but not a little straight``() =
    score LittleStraight [ One; One; Three; Four; Five ] |> should equal 0

[<Fact>]
let ``Big Straight``() = score BigStraight [ Four; Six; Two; Five; Three ] |> should equal 30

[<Fact>]
let ``Big Straight as little straight``() = score LittleStraight [ Six; Five; Four; Three; Two ] |> should equal 0

[<Fact>]
let ``No pairs but not a big straight``() = score BigStraight [ Six; Five; Four; Three; One ] |> should equal 0

[<Fact>]
let Choice() = score Choice [ Three; Three; Five; Six; Six ] |> should equal 23

[<Fact>]
let ``Yacht as choice``() = score Category.Choice [ Two; Two; Two; Two; Two ] |> should equal 10
