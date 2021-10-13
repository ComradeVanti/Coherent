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

    [<Property>]
    let ``Trying to link the same theses multiple times, does nothing``
        (SmallLogicWeb web)
        =
        let linked = web |> tryLinkPremise 1 0
        linked = (linked |> tryLinkPremise 1 0)

    [<Property>]
    let ``Trying to link theses in a circular way, does nothing``
        (SmallLogicWeb web)
        =
        web |> tryLinkPremise 1 0 = web

    [<Property>]
    let ``Trying to link a thesis to itself, does nothing``
        (SmallLogicWeb web)
        =
        web |> tryLinkPremise 0 0 = web

    [<Property>]
    let ``Successfully adding a conclusion, increases the thesis-count by one``
        (SmallLogicWeb web)
        (BasicThesis conclusion)
        =
        web
        |> tryAddConclusion ClaimThesisId conclusion
        |> thesisCount = (web |> thesisCount) + 1

    [<Property>]
    let ``Successfully adding a conclusion, increases the conclusion-count by one``
        (SmallLogicWeb web)
        (BasicThesis conclusion)
        =
        web
        |> tryAddConclusion ClaimThesisId conclusion
        |> conclusionCount = (web |> conclusionCount) + 1

    [<Property>]
    let ``Adding a conclusion to a premise that does not exist, does nothing``
        (SmallLogicWeb web)
        (BasicThesis conclusion)
        =
        web |> tryAddConclusion -1 conclusion = web
