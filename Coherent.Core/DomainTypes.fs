[<AutoOpen>]
module Coherent.DomainTypes

open System

type Statement = string

type Source = Article of Uri

type Thesis = Statement

type SourceId = int

type ThesisId = int

type Conclusion = ThesisId

type Premise = ThesisId

type Grounds = Premise list

type LogicWeb =
    {
        Theses: Map<ThesisId, Thesis>
        Sources: Map<SourceId, Source>
        Arguments: Map<Conclusion, Grounds>
    }


[<Literal>]
let ClaimThesisId = 0
