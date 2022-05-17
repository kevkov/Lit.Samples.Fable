namespace Lit.Samples.IntroToLit

module Five =

    open Browser.Types
    open Lit

    [<LitElement("more-expressions")>]
    let MoreExpressions () =
        // This call is obligatory to initialize the web component
        let _, props =
            LitElement.init (fun init -> init.props <- {| checked = Prop.Of(defaultValue = false) |})

        let setChecked (ev: Event) =
            props.checked.Value <- (ev.target :?> HTMLInputElement).checked

        html
            $"""
         <div>
             <!-- TODO: Add expression to input. -->
                <input type="text" ?disabled={not (props.checked.Value)} value="Hello there.">
             </div>
         <label><input type="checkbox" @change={fun ev -> setChecked ev}> Enable editing</label>
        """
