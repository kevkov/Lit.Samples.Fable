namespace Lit.Samples.IntroToLit

module Seven =

    open Browser.Types
    open Lit

    type ToDoItem = { text: string; completed: bool }

    [<LitElement("todo-list")>]
    let TodoList () =
        let css =
            Lit.css
                $"""
                  .completed {{
                        text-decoration-line: line-through;
                        color: #777;
                  }}
                """

        LitElement.init (fun init -> init.styles <- [ css ])
        |> ignore

        let listItems, setListItems =
            Hook.useState [ { text = "Start Lit Tutorial"
                              completed = true }
                            { text = "Make to-do list"
                              completed = false } ]

        let inputRef =
            Hook.useRef<HTMLInputElement> ()

        let addToDo _ =
            inputRef.Value
            |> Option.iter (fun el ->
                setListItems (
                    listItems
                    @ [ { text = el.value; completed = false } ]
                )

                el.value <- "")

        let todoText (todo: ToDoItem) =
            html
                $"""<li class={if todo.completed then
                                   "completed"
                               else
                                   ""}>{todo.text}</li>"""

        html
            $"""
        <h2>To Do</h2>
        <ul>
            {listItems |> List.map todoText}
          </ul>
        <input id="newitem" {Lit.refValue inputRef} aria-label="New item">
        <button @click={addToDo}>Add</button>
        """
