[<AutoOpen>]
module Coherent.DomainTypes

type Statement = string

type Thesis = Statement

type ThesisId = int

type Conclusion = ThesisId

type Premise = ThesisId

type Grounds = Premise list

type LogicWeb =
    {
        Theses: Map<ThesisId, Thesis>
        Arguments: Map<Conclusion, Grounds>
    }


[<Literal>]
let ClaimThesisId = 0
