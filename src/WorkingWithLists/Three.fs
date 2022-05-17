namespace Lit.Samples.WorkingWithLists

module Extensions =
    
    type 'T ``[]`` with
        member __.map(f) =
            Array.map f __
            
        member __.filter(f) =
            Array.filter f __            

module Three =

    open Lit
    open Extensions

    [<LitElement("my-element")>]
    let MyElement () =
        LitElement.init () |> ignore

        let items, _ = Hook.useState([|"Chandler"; "Phoebe"; "Joey"; "Monica"; "Rachel"; "Ross"|])
        html
            $"""
            <p>A list of names that include the letter "e"</p>
      <ul>
        {items
            .filter(fun item -> item.Contains("e"))
            .map(fun item -> html $"<li>{item}</li>")}
      </ul>
      """
