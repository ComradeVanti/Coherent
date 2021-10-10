module Coherent.LogicWebGen

open ClaimGen
open FsCheck
open ThesisGen
open CreateLogicWeb
open Coherent
open EditLogicWeb

let genLogicWeb =
    gen {
        let! claim = genClaim
        let! theses = Gen.listOf genThesis

        let addToWeb web thesis = web |> addThesis thesis

        return theses |> List.fold addToWeb (makeEmptyLogicWeb claim)
    }

type BasicLogicWeb = BasicLogicWeb of LogicWeb

type ArbLogicWebs =
    static member Basic = genLogicWeb |> asArbOf BasicLogicWeb
