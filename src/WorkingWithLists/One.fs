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
          {[|"✨"; "🔥"; "❤️"|]}
        </p>
      <h2>Set</h2>
      <p>
        {Set(['A', 'B', 'C'])}
      </p>
        <h2>Generator</h2>
      <p>
        {seq { for i in 1 .. 4 -> i }}
      </p>
      """