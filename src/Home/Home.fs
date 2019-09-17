module Home
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma



let home dispatch = 
  div [] [
    Hero.hero [] [ 
      Hero.body [] [
        // Columns.columns [Columns.IsCentered ] [
        //   Column.column [Column.Width (Screen.All , Column.IsOneQuarter)]
        //     [Image.image [  ] [img [ Src "capitol-logo.png";]]]
        // ]   
        Container.container [ Container.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ] [ 
          Heading.h1 [ ]
            [ str "February 29th" ]
          Heading.h2 [ Heading.IsSubtitle ]
            [ str "Washington, DC" ] 
          p[] 
            [str "Capitol F# is a free, full-day conference full of talks"]
          p[] 
            [str "Keep checking here for updates, and check out the site code on github"]

          
        ]
      ]    
    ]
    div [ Class "call-for-speakers"] [
      h2 [] [str "Call for Speakers"]
      img [Src "i-want-you.jpg";]
    ]
  ]