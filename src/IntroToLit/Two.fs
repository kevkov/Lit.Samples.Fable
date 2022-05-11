module Lit.TodoMVC.IntroToLit.Two

open Lit

[<LitElement("my-element")>]
let MyElement() =
    // This call is obligatory to initialize the web component
    let _, props =
        LitElement.init(fun init -> () )
        
    html
        $"""
            <p>Hello world! From my-element.</p>
        """