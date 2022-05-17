namespace Lit.Samples.IntroToLit

module Eight =

    open Browser.Types
    open Fable.Core.JS
    open Lit

    type ToDoItem =
        { text: string
          mutable completed: bool }

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

        let el, props =
            LitElement.init (fun init ->
                init.props <- {| hideCompleted = Prop.Of(defaultValue = false) |}
                init.styles <- [ css ])

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

        let toggleCompleted (item: ToDoItem) =
            console.log "toggling"
            item.completed <- not item.completed
            el.requestUpdate ()

        let todoItem (todo: ToDoItem) =
            html
                $"""
        <li
          class={if todo.completed then
                     "completed"
                 else
                     ""}
          @click={(fun _ -> toggleCompleted (todo))}>
          {todo.text}
        </li>"""

        let setHideCompleted (e: Event) =
            props.hideCompleted.Value <- (e.target :?> HTMLInputElement).``checked``

        let items =
            if props.hideCompleted.Value then
                listItems
                |> List.filter (fun i -> not i.completed)
            else
                listItems

        let todos =
            html
                $"""
                    <ul>
                        {items |> List.map todoItem}
                    </ul>"""

        let caughtUpMessage =
            html
                $"""
                  <p>
                  You're all caught up!
                  </p>
                  """

        let todosOrMessage =
            if items |> List.length > 0 then
                todos
            else
                caughtUpMessage

        html
            $"""
        <h2>To Do</h2>
        {todosOrMessage}
        <input id="newitem" {Lit.refValue inputRef} aria-label="New item">
        <button @click={addToDo}>Add</button>
        <br>
        <label>
          <input type="checkbox"
            @change={setHideCompleted}
            ?checked={props.hideCompleted}>
          Hide completed
        </label>
        """
