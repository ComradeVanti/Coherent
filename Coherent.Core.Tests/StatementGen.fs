module Coherent.StatementGen

open FsCheck

let private colors =
    [
        "red"
        "green"
        "blue"
        "yellow"
        "purple"
        "black"
        "white"
    ]

let genStatement: Gen<Statement> =
    Gen.elements colors
    |> Gen.map (fun color -> $"The sky is {color}.")
