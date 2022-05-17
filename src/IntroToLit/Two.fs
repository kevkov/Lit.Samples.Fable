namespace Lit.Samples.IntroToLit

module Two =

    open Lit

    [<LitElement("my-element")>]
    let MyElement () =
        // This call is obligatory to initialize the web component
        LitElement.init (fun _ -> ()) |> ignore

        html
            $"""
            <p>Hello world! From my-element.</p>
        """
