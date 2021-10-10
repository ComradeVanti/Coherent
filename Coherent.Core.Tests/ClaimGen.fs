module Coherent.ClaimGen

open Coherent
open FsCheck
open StatementGen

let claimGen: Gen<Claim> = genStatement

type BasicClaim = BasicClaim of Claim

type ArbClaims =
    static member Basic = genStatement |> asArbOf BasicClaim
