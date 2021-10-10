[<AutoOpen>]
module Coherent.DomainTypes

type Statement = string

type Claim = Statement

type Thesis = Statement

type ThesisId = int

type Argument = { ConclusionId: ThesisId; PremiseIds: ThesisId list }

type LogicWeb =
    {
        Claim: Claim
        Theses: Map<ThesisId, Thesis>
        Arguments: Argument list
    }
