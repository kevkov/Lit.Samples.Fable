namespace Lit.Samples.Fable.WorkingWithLists

module Seven =

    open Lit

    [<LitElement("my-element")>]
    let MyElement () =
        LitElement.init () |> ignore

        things,
        setThings = Hook.useState [| "Raindrops on roses"
                                     "Whiskers on kittens"
                                     "Bright copper kettles"
                                     "Warm woolen mittens" |]
        
        let private deleteThing(index: int) =
            things |> Array.
