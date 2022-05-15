module Lit.Samples.Fable.IntroToLit.Six

open Lit

[<LitElement("todo-list")>]
let TodoList() =
    let listItems, setListItems =
        LitElement.init(fun init -> () ) |> ignore
        Hook.useState
            [
              {| text = "Start Lit Tutorial"; completed = true |}
              {| text = "Make to-do list"; completed = false |}
            ]
            
    let addToDo _ =
        ()
        
    html
        $"""
          <h2>To Do</h2>
          <ul>
             <!-- TODO: Render list items. -->
          </ul>
          <input id="newitem" aria-label="New item">
          <button @click={addToDo}>Add</button>
        """