module Coherent.QueryLogicWeb

let theses web =
    web.Theses
    
let thesisCount web =
    web |> theses |> Map.count