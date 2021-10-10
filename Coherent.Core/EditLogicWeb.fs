module Coherent.EditLogicWeb

open Coherent
open QueryLogicWeb

let private mapTheses mapper web = { web with Theses = web.Theses |> mapper }

let private mapArguments mapper web =
    { web with Arguments = web.Arguments |> mapper }

let private addThesis thesis web =
    let maxId = web |> thesisIds |> List.max
    let id = maxId + 1

    web |> mapTheses (Map.add id thesis), id

let private addArgument conclusionId premiseId web =
    web |> mapArguments (addToMapList conclusionId premiseId)

let tryLinkPremise conclusionId premiseId web =
    let canLink =
        web |> hasThesisWithId conclusionId
        && web |> hasThesisWithId premiseId

    if canLink then
        web |> addArgument conclusionId premiseId
    else
        web

let tryAddPremise conclusionId premise web =
    let canAdd = web |> hasThesisWithId conclusionId

    if canAdd then
        let newWeb, premiseId = web |> addThesis premise
        newWeb |> tryLinkPremise conclusionId premiseId
    else
        web
