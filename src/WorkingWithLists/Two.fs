namespace Lit.Samples.WorkingWithLists

module Two =

    open Lit
    
    let map (items: seq<'t>) f =
        Seq.map f items

    [<LitElement("my-element")>]
    let MyElement () =
        LitElement.init () |> ignore

        let items, _ = Hook.useState(Set(["Apple"; "Banana"; "Grape"; "Orange"; "Lime"]))
        html
            $"""
            <p>My unique fruits</p>
      <ul>
        {map items (fun item -> html $"<li>{item}</li>")}
      </ul>
      """
