module Lit.Samples.Fable.IntroToLit.Six

open Browser.Types
open Lit

[<LitElement("todo-list")>]
let TodoList() =
    let css = Lit.css 
                $"""
                  .completed {{
                        text-decoration-line: line-through;
                        color: #777;
                  }}
                """
    LitElement.init(fun init -> init.styles <- [css] ) |> ignore
    let listItems, setListItems =
        Hook.useState
            [
              {| text = "Start Lit Tutorial"; completed = true |}
              {| text = "Make to-do list"; completed = false |}
            ]
            
    let inputRef = Hook.useRef<HTMLInputElement>()
    let addToDo _ =
        inputRef.Value
        |> Option.iter
               (fun el ->
                    setListItems (listItems @ [{| text = el.value; completed = false |}])
                    el.value <- ""
                )
       
    // don't panic
    let todoText (todo: {| text: string; completed: bool |}) =
        let classes = Lit.classes [
                        "completed", todo.completed
                      ]
        html $"""<li class={classes}>{todo.text}</li>"""
        
    html
        $"""
        <h2>To Do</h2>
        <ul>
            {listItems |> List.map todoText}
          </ul>
        <input id="newitem" {Lit.refValue inputRef} aria-label="New item">
        <button @click={addToDo}>Add</button>
        """