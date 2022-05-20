namespace Lit.Samples.Fable.Reactivity

open System

module One =

    open Lit

    [<LitElement("my-element")>]
    let MyElement () =
        let _, props =
            LitElement.init (fun init -> init.props <- {| result = Prop.Of(defaultValue = "") |})

        let flipCoin _ =
            if Random().NextDouble () < 0.5 then
                props.result.Value <- "Heads"
            else
                props.result.Value <- "Tails"

        html
            $"""
            <button @click={flipCoin}>Flip a coin!</button>
            <p>Result: {props.result}</p>
            """
