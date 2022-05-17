namespace Lit.Samples.WorkingWithLists

module Two =

    open Lit

    [<LitElement("my-element")>]
    let MyElement () =
        LitElement.init () |> ignore

        let friends, _ =
            Hook.useState [ "Harry"
                            "Ron"
                            "Hermione" ]

        let pets, _ =
            Hook.useState [ {| name = "Hedwig"; species = "Owl" |}
                            {| name = "Scabbers"; species = "Rat" |}
                            {| name = "Crookshanks"
                               species = "Cat" |} ]

        let includePets, setIncludePets =
            Hook.useState false

        let togglePetVisibility _ = setIncludePets (not includePets)

        let listItems =
            seq {
                yield!
                    friends
                    |> List.map (fun item -> html $"<li>{item}</li>")

                if includePets then
                    yield!
                        pets
                        |> List.map (fun item -> html $"<li>{item.name} ({item.species})</li>")
            }

        html
            $"""
              <button @click={togglePetVisibility}>
                 {if includePets then "Hide" else "Show"} pets
              </button>
              <p>My magical friends</p>
              <ul>
                {listItems}
              </ul>
            """
