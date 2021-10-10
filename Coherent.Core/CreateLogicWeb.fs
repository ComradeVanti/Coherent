module Coherent.CreateLogicWeb

let makeEmptyLogicWeb claim =
    { Claim = claim; Theses = Map.empty; Arguments = [] }
