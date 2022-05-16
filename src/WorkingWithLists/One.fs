namespace Lit.Samples.Fable.WorkingWithLists

module One =

  open Lit

  [<LitElement("my-element")>]
  let MyElement() =
      LitElement.init() |> ignore
      html $"""
      <h1>Rendering lists with Lit</h1>
        <p>Lit has built-in support for any iterables!</p>
        <h2>Array</h2>
        <p>
          {["✨"; "🔥"; "❤️"]}
        </p>

      """