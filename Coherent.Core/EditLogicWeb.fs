module Coherent.EditLogicWeb

open Coherent
open QueryLogicWeb

let addThesis thesis web =

    let id =
        match web |> theses |> keys with
        | [] -> 1
        | keys -> (keys |> List.max) + 1
        
    { web with Theses = web.Theses |> Map.add id thesis }
