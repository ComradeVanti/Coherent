namespace Coherent

open Coherent.ClaimGen
open FsCheck.Xunit
open CreateLogicWeb
open QueryLogicWeb

[<Properties(Arbitrary = [| typeof<ArbClaims> |])>]
module CreateLogicTests =

    [<Property>]
    let ``Empty logic-webs have no theses`` (BasicClaim claim) =
        claim |> makeEmptyLogicWeb |> thesisCount = 0
