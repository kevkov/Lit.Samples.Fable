module Lit.Samples.IntroToLit.Three

open Lit

[<LitElement("my-element")>]
let MyElement() =
    // This call is obligatory to initialize the web component
    let _, props =
        LitElement.init(fun init ->  init.props <- {| message = Prop.Of(defaultValue = "Hello again.") |} )
        
    html
        $"""
            <p>{props.message}</p>
        """