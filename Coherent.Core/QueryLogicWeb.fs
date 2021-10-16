module Coherent.QueryLogicWeb

let thesesById web = web.Theses

let theses web = web |> thesesById |> values

let thesisIds web = web |> thesesById |> keys

let premisesByConclusion web = web.Arguments

let premises web = web |> premisesByConclusion |> values |> List.concat

let conclusions web = web |> premisesByConclusion |> keys

let thesisCount web = web |> thesesById |> Map.count

let premiseCount web = web |> premises |> List.length

let conclusionCount web = web |> conclusions |> List.length

let sourcesById web = web.Sources

let sourceCount web = web |> sourcesById |> Map.count

let hasThesisWithId id web = web |> thesesById |> Map.containsKey id

let tryFindGroundsFor conclusionId web =
    web
    |> premisesByConclusion
    |> Map.tryFind conclusionId
    |> Option.defaultValue []

let rec findAllPremisesFor conclusionId web =
    seq {
        let grounds = web |> tryFindGroundsFor conclusionId
        yield! grounds

        yield!
            grounds
            |> List.map (fun premiseId -> web |> findAllPremisesFor premiseId)
            |> Seq.concat
    }

let isPremiseOf conclusionId web premiseId =
    conclusionId = premiseId
    || (web
        |> findAllPremisesFor conclusionId
        |> Seq.contains premiseId)
