module Coherent.ThesisGen

open FsCheck
open ClaimGen

let genThesis: Gen<Thesis> = genClaim

type BasicThesis = BasicThesis of Thesis

type ArbTheses =
    static member Basic = genThesis |> asArbOf BasicThesis