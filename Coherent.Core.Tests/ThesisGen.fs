module Coherent.ThesisGen

open FsCheck
open StatementGen

let genThesis: Gen<Thesis> = genStatement

type BasicThesis = BasicThesis of Thesis

type ArbTheses =
    static member Basic = genThesis |> asArbOf BasicThesis
