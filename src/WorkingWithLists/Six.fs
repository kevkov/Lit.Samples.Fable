namespace Lit.Samples.Fable.WorkingWithLists

module Six =

    open Lit
    open Lit

    [<LitElement("my-element")>]
    let MyElement () =
        LitElement.init () |> ignore

        let tasks, setTasks =
            Hook.useState [ {| id = "a"; label = "Learn Lit" |}
                            {| id = "b"; label = "Feed the cat" |}
                            {| id = "c"; label = "Go for a walk" |}
                            {| id = "d"; label = "Take a nap" |} ]

        html
            $"""
            <p>Things to do today:</p>
              <button @click={fun _ -> setTasks (tasks |> List.sortBy (fun t -> t.label))}>Sort ascending</button>
              <button @click={fun _ -> setTasks (tasks |> List.sortByDescending (fun t -> t.label))}>Sort descending</button>
              <ul>
              { tasks |> Lit.mapUnique
                             (fun t -> t.id)
                             (fun t -> html $"<li><label><input type=\"checkbox\" />{t.id}) {t.label}</label></li>") }
              </ul>
            """
