module Coherent.LogicWebGen

open FsCheck
open ThesisGen
open CreateLogicWeb
open EditLogicWeb
open QueryLogicWeb

let private genRandomThesisId web = Gen.elements (web |> thesisIds)

let private genExpandedWeb web =
    gen {
        let! id = web |> genRandomThesisId
        let! premise = genThesis
        return web |> tryAddPremise id premise
    }

let rec private genExpandedWebTimes expansionCount web =
    gen {
        if expansionCount = 0 then
            return web
        else
            let! expanded = web |> genExpandedWeb
            return! expanded |> genExpandedWebTimes (expansionCount - 1)
    }


let genLogicWebOfSize thesisCount =
    gen {
        let! claim = genThesis
        let web = claim |> makeEmptyLogicWeb
        return! genExpandedWebTimes (thesisCount - 1) web
    }

type SmallLogicWeb = SmallLogicWeb of LogicWeb

type ArbLogicWebs =
    static member Small = genLogicWebOfSize 5 |> asArbOf SmallLogicWeb
