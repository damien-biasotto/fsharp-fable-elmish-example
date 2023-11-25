﻿module Pages.Counter

open Fable.React
open Fable.React.Props
open Elmish


type Model = { count: int }

type Msg =
    | Increment
    | Decrement
    | Random

let init (initialCount: int) = { count = initialCount }, Cmd.none

let update (msg: Msg) (model: Model) =
    match msg with
    | Increment -> { model with count = model.count + 1 }, Cmd.none
    | Decrement -> { model with count = model.count - 1 }, Cmd.none
    | Random ->
        {
            model with
                count = System.Random().Next(100)
        },
        Cmd.none

let subscriptions (model: Model) : Sub<Msg> = []

let view (model: Model) (dispatch: Msg -> unit) =
    div [] [
        h2 [] [ str "Counter" ]
        p [] [
            button [ OnClick(fun _ -> dispatch Decrement) ] [ str "-" ]
            str (sprintf "%A" model.count)
            button [ OnClick(fun _ -> dispatch Increment) ] [ str "+" ]
        ]
        p [] [ button [ OnClick(fun _ -> dispatch Random) ] [ str "Random" ] ]
    ]
