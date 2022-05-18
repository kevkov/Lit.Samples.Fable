namespace Lit.Samples.Fable.WorkingWithLists

module Five =

    open Lit

    [<LitElement("my-element")>]
    let MyElement () =
        let css =
            Lit.css
                $"""
                :host {{
                  display: block;
                  width: 400px;
                  height: 400px;
                }}
                #board {{
                  display: grid;
                  grid-template-columns: repeat(8, 1fr);
                  grid-template-rows: repeat(8, 1fr);
                  border: 2px solid #404040;
                  box-sizing: border-box;
                  height: 100%%;
                }}
                #board > div {{
                  padding: 2px;
                }}
                .black {{
                  color: #ddd;
                  background: black;
                }}
                .white {{
                  color: gray;
                  background: white;
                }}
              """

        let _ =
            LitElement.init (fun init -> init.styles <- [ css ])

        let getColor row col =
            if (row + col) % 2 = 0 then
                "white"
            else
                "black"

        let getLabel row col = $"{(char) (65 + col)}{8 - row}"

        html
            $"""
        <div id="board">
        {[ for row in 0..7 do
               [ for col in 0..7 do
                     yield html $"<div class=\"{getColor row col}\">{getLabel row col}</div>" ] ]}
        </div>
      """
