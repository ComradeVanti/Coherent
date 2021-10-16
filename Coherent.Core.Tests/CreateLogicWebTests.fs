namespace Coherent

open Coherent.ThesisGen
open FsCheck.Xunit
open CreateLogicWeb
open QueryLogicWeb

[<Properties(Arbitrary = [| typeof<ArbTheses> |])>]
module CreateLogicWebTests =

    [<Property>]
    let ``Empty logic-webs have the claim as its single thesis``
        (BasicThesis claim)
        =
        claim |> makeEmptyLogicWeb |> theses = [ claim ]

    [<Property>]
    let ``Empty logic-webs have no arguments`` (BasicThesis claim) =
        claim |> makeEmptyLogicWeb |> premiseCount = 0

    [<Property>]
    let ``Empty logic-webs have no sources`` (BasicThesis claim) =
        claim |> makeEmptyLogicWeb |> sourceCount = 0
