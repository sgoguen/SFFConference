module App.View

open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fable.Core.JsInterop

importAll "./style.scss"

type Page =
  | Home
  | Speakers
  | Schedule
  | Tickets
  | Venue
  | Cfp

type Route = Blog of int | Search of string

type Model = { page : Page }

type Msg = unit
let urlUpdate loc model =
  printfn "%A" loc
  match loc with
  | Some l -> { model with page = l}, Cmd.none
  | None -> model, Cmd.none

let init loc =
  urlUpdate loc { page = Home }

let update msg model =
  model, Cmd.Empty


let navBar =
  nav [ Class "navbar is-primary topNav"; Role "navigation" ] [
    div [ Class "navbar-brand" ] [
      img [Class "chickenSandwich"; Src "sandwich.png"]
    ]
    div [ Class "navbar-start"] []
    div [ Class "navbar-menu" ] [
      a [ Class "navbar-item"; Href "#home" ] [ str "Home" ]
      a [ Class "navbar-item"; Href "#speakers" ] [ str "Speakers" ]
      a [ Class "navbar-item"; Href "#venue" ] [ str "Venue" ]
      a [ Class "navbar-item"; Href "#schedule" ] [ str "Schedule" ]
      a [ Class "navbar-item"; Href "#tickets" ] [ str "Tickets" ]
      a [ Class "navbar-item"; Href "#cfp" ] [ str "Call for Papers" ]
    ]
    div [Class "navbar-end"] [
      a [Class "button headerButton"] [ 
        i [ Class "fab fa-twitter"] [str " Share"]
      ]
      a [Class "button headerButton"] [ 
        i [ Class "fab fa-github"] [str " Contribute"]
      ]
    ]
  ]

let content page dispatch =
  match page with
  | Home -> Home.home dispatch
  | Cfp -> Cfp.view
  | _ -> div [] [str "Nothing here."]


let private view (model:Model) (dispatch:Dispatch<Msg>) =
  div [] [
    navBar
    content model.page dispatch
  ]

open Elmish.React
open Elmish.Debug
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Elmish.HMR
let parser =
  oneOf [
    map Home (s "home")
    map Speakers (s "speakers")
    map Schedule (s "schedule")
    map Tickets (s "tickets")
    map Venue (s "venue")
    map Cfp (s "cfp")
  ]


Program.mkProgram init update view
|> Program.toNavigable (parseHash parser) urlUpdate
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReact "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
