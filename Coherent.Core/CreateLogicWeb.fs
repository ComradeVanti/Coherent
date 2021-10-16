module Coherent.CreateLogicWeb

let makeEmptyLogicWeb claim =
    {
        Theses = Map.empty |> Map.add ClaimThesisId claim
        Arguments = Map.empty
        Sources = Map.empty
    }
