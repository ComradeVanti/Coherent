namespace Coherent

open Coherent.LogicWebGen
open Coherent.ThesisGen
open FsCheck.Xunit
open EditLogicWeb
open QueryLogicWeb

[<Properties(Arbitrary = [| typeof<ArbTheses>; typeof<ArbLogicWebs> |])>]
module EditLogicWebTests =

    [<Property>]
    let ``Successfully adding a premise, increases the thesis-count by one``
        (SmallLogicWeb web)
        (BasicThesis premise)
        =
        web |> tryAddPremise ClaimThesisId premise |> thesisCount = (web
                                                                     |> thesisCount)
                                                                    + 1

    [<Property>]
    let ``Successfully adding a premise, increases the premise-count by one``
        (SmallLogicWeb web)
        (BasicThesis premise)
        =
        web |> tryAddPremise ClaimThesisId premise |> premiseCount = (web
                                                                      |> premiseCount)
                                                                     + 1

    [<Property>]
    let ``Adding a premise to a conclusion that does not exist, does nothing``
        (SmallLogicWeb web)
        (BasicThesis premise)
        =
        web |> tryAddPremise -1 premise = web

    [<Property>]
    let ``Successfully linking a premise, does not change the thesis-count``
        (SmallLogicWeb web)
        =
        web
        |> tryLinkPremise ClaimThesisId (ClaimThesisId + 1)
        |> thesisCount = (web |> thesisCount)

    [<Property>]
    let ``Successfully linking a premise, increases the premise-count by one``
        (SmallLogicWeb web)
        =
        web
        |> tryLinkPremise ClaimThesisId (ClaimThesisId + 1)
        |> premiseCount = (web |> premiseCount) + 1

    [<Property>]
    let ``Linking a premise to a conclusion that does not exist, does nothing``
        (SmallLogicWeb web)
        =
        web |> tryLinkPremise -1 1 = web

    [<Property>]
    let ``Linking a premise that does not exist to a conclusion, does nothing``
        (SmallLogicWeb web)
        =
        web |> tryLinkPremise 0 -1 = web