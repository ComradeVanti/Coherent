module Coherent.ClaimGen

open Coherent
open FsCheck
open StatementGen

let genClaim: Gen<Claim> = genStatement

type BasicClaim = BasicClaim of Claim

type ArbClaims =
    static member Basic = genClaim |> asArbOf BasicClaim
