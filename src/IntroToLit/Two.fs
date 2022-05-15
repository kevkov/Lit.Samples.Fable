﻿module Lit.Samples.IntroToLit.Two

open Lit

[<LitElement("my-element")>]
let MyElement() =
    // This call is obligatory to initialize the web component
    LitElement.init(fun init -> () ) |> ignore
        
    html
        $"""
            <p>Hello world! From my-element.</p>
        """