[<AutoOpen>]
module Coherent.MapUtil

let keys map =
    map |> Map.toList |> List.map fst