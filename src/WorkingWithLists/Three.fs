namespace Lit.Samples.WorkingWithLists

module Extensions =
    
    type List<'t> with
        member __.map(f) =
            List.map f __
            
        member __.filter(f) =
            List.filter f __            

module Two =

    open Lit
    open Extensions

    [<LitElement("my-element")>]
    let MyElement () =
        LitElement.init () |> ignore

        let items, _ = Hook.useState(["Chandler"; "Phoebe"; "Joey"; "Monica"; "Rachel"; "Ross"])
        html
            $"""
            <p>A list of names that include the letter "e"</p>
      <ul>
        {items
            .filter(fun item -> item.Contains("e"))
            .map(fun item -> html $"<li>{item}</li>")}
      </ul>
      """
