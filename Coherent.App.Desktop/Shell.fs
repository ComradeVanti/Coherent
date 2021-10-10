namespace Coherent.App.Desktop

open Elmish
open Avalonia.FuncUI
open Avalonia.FuncUI.Components.Hosts
open Avalonia.FuncUI.DSL
open Avalonia.FuncUI.Elmish

module Shell =


    type State = unit

    type Msg = unit

    let init = (), Cmd.none

    let update (msg: Msg) (state: State) : State * Cmd<_> = (), Cmd.none

    let view (state: State) (dispatch) = DockPanel.create []

    type MainWindow() as this =
        inherit HostWindow()

        do
            base.Title <- "Coherent"
            base.Width <- 800.0
            base.Height <- 600.0
            base.MinWidth <- 800.0
            base.MinHeight <- 600.0

            Elmish.Program.mkProgram (fun () -> init) update view
            |> Program.withHost this
            |> Program.run
