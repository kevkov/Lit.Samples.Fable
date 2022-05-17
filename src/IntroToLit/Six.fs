namespace Lit.Samples.IntroToLit

module Six =

    open Browser.Types
    open Lit

    [<LitElement("todo-list")>]
    let TodoList () =
        LitElement.init (fun _ -> ()) |> ignore

        let listItems, setListItems =
            Hook.useState [ {| text = "Start Lit Tutorial"
                               completed = true |}
                            {| text = "Make to-do list"
                               completed = false |} ]

        let inputRef =
            Hook.useRef<HTMLInputElement> ()

        let addToDo _ =
            inputRef.Value
            |> Option.iter (fun el ->
                setListItems (
                    listItems
                    @ [ {| text = el.value; completed = false |} ]
                )

                el.value <- "")

        // don't panic
        let todoText (todo: {| text: string; completed: bool |}) = html $"""<li>{todo.text}</li>"""

        html
            $"""
        <h2>To Do</h2>
        <ul>
            {listItems |> List.map todoText}
          </ul>
        <input id="newitem" {Lit.refValue inputRef} aria-label="New item">
        <button @click={addToDo}>Add</button>
        """
