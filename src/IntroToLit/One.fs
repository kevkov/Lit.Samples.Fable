module Lit.Samples.IntroToLit.One

open Lit

[<LitElement("my-element")>]
let MyElement() =
    // This call is obligatory to initialize the web component
    let _, props =
        LitElement.init(fun init ->
            init.props <- {| version = Prop.Of(defaultValue = 0) |})
        
    html
        $"""
            <p>Welcome to the Lit tutorial!</p>
            <p>This is the {props.version} code.</p>
        """