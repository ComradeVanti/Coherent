namespace Coherent

open Coherent.LogicWebGen
open Coherent.ThesisGen
open FsCheck.Xunit
open EditLogicWeb
open QueryLogicWeb

[<Properties(Arbitrary = [| typeof<ArbTheses>; typeof<ArbLogicWebs> |])>]
module EditLogicWebTests =

    [<Property>]
    let ``Adding a thesis increases the thesis-count by one``
        (BasicLogicWeb web)
        (BasicThesis thesis)
        =
        web |> addThesis thesis |> thesisCount = (web |> thesisCount) + 1
