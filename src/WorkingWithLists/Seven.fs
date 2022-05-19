namespace Lit.Samples.Fable.WorkingWithLists

module Seven =

    open Lit

    [<LitElement("my-element")>]
    let MyElement () =
        LitElement.init () |> ignore

        let things, setThings =
            Hook.useState [| "Raindrops on roses"
                             "Whiskers on kittens"
                             "Bright copper kettles"
                             "Warm woolen mittens" |]

        let deleteThing (index: int) =
            setThings (
                things
                |> Array.indexed
                |> Array.filter (fun (i, t) -> i <> index)
                |> Array.map snd
            )

        html
            $"""
      <p>A few of my favorite things</p>
      <ul>
        {things
         |> Array.mapi (fun i t -> html $"<li>{t}
                        <button @click={fun () -> deleteThing (i)}>Delete</button></li>")}
      </ul>
        """
