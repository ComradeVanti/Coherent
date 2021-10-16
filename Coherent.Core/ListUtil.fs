[<AutoOpen>]
module Coherent.ListUtil

let appendSingle item list = List.append list [ item ]

let ifEmptySet replacement list =
    match list with
    | [] -> replacement
    | _ -> list
