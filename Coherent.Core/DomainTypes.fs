[<AutoOpen>]
module Coherent.DomainTypes

type Statement = string

type Claim = Statement

type LogicWeb = { Claim: Claim }
