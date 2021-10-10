[<AutoOpen>]
module Coherent.MapUtil

let keys map = map |> Map.toList |> List.map fst

let values map = map |> Map.toList |> List.map snd

let mapAtKey key mapper map =
    map
    |> Map.map
        (fun currentKey value ->
            if currentKey = key then value |> mapper else value)

let addToMapList key item map =
    if map |> Map.containsKey key then
        map |> mapAtKey key (appendSingle item)
    else
        map |> Map.add key [ item ]
