module Coherent.QueryLogicWeb

let theses web =
    web.Theses
    
let arguments web =
    web.Arguments
    
let thesisCount web =
    web |> theses |> Map.count
    
let argumentCount web =
    web |> arguments |> List.length