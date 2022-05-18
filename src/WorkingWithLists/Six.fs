namespace Lit.Samples.Fable.WorkingWithLists

module Six =

    open Lit
    open Lit

    [<LitElement("my-element")>]
    let MyElement () =
        let el, _ = LitElement.init (fun _ -> ())

        let tasks, setTasks =
            Hook.useState [| {| id = "a"; label = "Learn Lit" |}
                             {| id = "b"; label = "Feed the cat" |}
                             {| id = "c"; label = "Go for a walk" |}
                             {| id = "d"; label = "Take a nap" |} |]
            
        let sort dir =
            tasks |> Array.sortInPlaceWith (fun t1 t2 -> t1.label.CompareTo(t2.label) * dir); el.requestUpdate()

        html
            $"""
            <p>Things to do today:</p>
              <button @click={fun _ -> sort 1 }>Sort ascending</button>
              <button @click={fun _ -> sort -1 }>Sort descending</button>
              <ul>
              { tasks |> Lit.mapUnique
                             (fun t -> t.id)
                             (fun t -> html $"<li><label><input type=\"checkbox\" />{t.id}) {t.label}</label></li>") }
              </ul>
            """
