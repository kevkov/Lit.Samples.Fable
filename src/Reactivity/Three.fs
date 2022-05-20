namespace Lit.Samples.Fable.Reactivity

open Fable.Core.JS

module Three =

    open Lit

    type List<'t> with
        static member filteri f (l: List<'t>) = l |> List.indexed |> List.filter f

    [<LitElement("my-element")>]
    let MyElement () =
        let _, props =
            LitElement.init (fun init ->
                init.props <-
                    {| groceries =
                        Prop.Of [ "tea"
                                  "milk"
                                  "honey"
                                  "chocolate" ] |})

        let removeItem (item: string) =
            let indexToRemove =
                props.groceries.Value
                |> List.findIndex (fun g -> g = item)

            printfn $"{indexToRemove}"

            props.groceries.Value <-
                props.groceries.Value
                |> List.filteri (fun (i, g) -> i <> indexToRemove)
                |> List.map snd

        html
            $"""
              {props.groceries.Value
               |> List.map (fun item -> html $"<button @click={fun _ -> removeItem (item)}>x</button>  ${item}<br>")}"""
