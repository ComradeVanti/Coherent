module Coherent.QueryLogicWeb

let thesesById web = web.Theses

let theses web = web |> thesesById |> values

let thesisIds web = web |> thesesById |> keys

let premisesByConclusion web = web.Arguments

let premises web = web |> premisesByConclusion |> values |> List.concat

let thesisCount web = web |> thesesById |> Map.count

let premiseCount web = web |> premises |> List.length

let hasThesisWithId id web = web |> thesesById |> Map.containsKey id
