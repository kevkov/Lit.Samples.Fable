module Lit.Samples.IntroToLit.Four

open Browser.Types
open Lit

[<LitElement("name-tag")>]
let NameTag() =
    // This call is obligatory to initialize the web component
    let _, props =
        LitElement.init(fun init ->  init.props <- {| Name = Prop.Of(defaultValue = "") |} )
        
    let changeName (event: Event) =
        let input = event.target :?> HTMLInputElement
        props.Name.Value <- input.value
        ()
    html
        $"""
          <p>Hello, {props.Name}</p>
          <input @input={changeName} placeholder="Enter your name">
        """