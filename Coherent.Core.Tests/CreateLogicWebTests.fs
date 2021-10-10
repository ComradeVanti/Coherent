namespace Coherent

open Coherent.ClaimGen
open FsCheck.Xunit
open CreateLogicWeb
open QueryLogicWeb

[<Properties(Arbitrary = [| typeof<ArbClaims> |])>]
module CreateLogicWebTests =

    [<Property>]
    let ``Empty logic-webs have no theses`` (BasicClaim claim) =
        claim |> makeEmptyLogicWeb |> thesisCount = 0

    [<Property>]
    let ``Empty logic-webs have no arguments`` (BasicClaim claim) =
        claim |> makeEmptyLogicWeb |> argumentCount = 0