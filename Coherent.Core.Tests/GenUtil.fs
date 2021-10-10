[<AutoOpen>]
module Coherent.GenUtil

open FsCheck

let asArbOf mapper gen = gen |> Gen.map mapper |> Arb.fromGen
