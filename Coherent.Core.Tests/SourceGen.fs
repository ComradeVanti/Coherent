module Coherent.SourceGen

open System
open FsCheck

let private sources = [ Uri("http://the.internet.com") ]

let genArticle = Gen.elements sources |> Gen.map Article

let genSource = Gen.oneof [ genArticle ]

type ValidSource = ValidSource of Source

type ArbSources =
    static member Valid = genSource |> asArbOf ValidSource
