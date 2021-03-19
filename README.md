# Smol Boii
<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/title.png">

<br>
<br>

Smol Boii is an early concept for a Unity game. The overall idea of SmallBoi is to be a fun, stress free, problem solving platform game. We want to challenge our users to solve problems and cooperate with another player. That's right, another player! Our goal is to allow two players within the same game instance, allowing for double the fun! There will
be a multitude of challenges, enemies and levels to make the game feel less repetitive.

---
## The Team
Alan Hung, Ameilia Valdes, David Dicken, Jordan Kidwell, Scott Falbo, JP Jones, Michael Falk, Kjell Overholt, Krystian Francuz-Harris, Matthew Petersen.

<table>
  <tr>
    <td>
      <img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/team/alan.png" height=50>
    </td>
    <td>
      <img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/team/amielia.png" height=50>
    </td>
    <td>
       <img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/team/david.png" height=50>
    </td>
    <td>
       <img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/team/jordan.png" height=50>
    </td>
    <td>
       <img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/team/scott.png" height=50>
    </td>
  </tr>
    <tr>
    <td>
      <img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/team/jp.png" height=50>
    </td>
    <td>
      <img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/team/mike.png" height=50>
    </td>
    <td>
       <img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/team/kjell.png" height=50>
    </td>
    <td>
       <img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/team/krystian.png" height=50>
    </td>
    <td>
       <img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/team/matthew.png" height=50>
    </td>
  </tr>
</table>

---

## Tools Used


<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/cSharp.png" height=50>
<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/visualStudio.png" height=50>
<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/unity.png" height=50>
<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/illustrator.png" height=50>
<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/small_logo.png" height=50>

---


## Getting Started

- Download the executable.

or
- Play through Unity.
  - `git clone https://github.com/AmeiliaAndTheSmallBois/SmallBoi.git`
  - Play the main scene.

- ### Game Play Controls
<table>
  <tr>
    <th>
    </th>
    <th>
    Player 1
    </th>
    <th>
      Player 2
    </td>
  </tr>
    <td>
      move left:
    </td>
    <td>
      &#8592
    </td>
    <td>
      A
    </td>
  </tr>
    </tr>
      <td>
      move right:
    </td>
    <td>
      &#8594;
    </td>
    <td>
      D
    </td>
  </tr>
    </tr>
      <td>
        jump:
    </td>
    <td>
      &#8593;
    </td>
    <td>
      W
    </td>
  </tr>
    </tr>
      <td>
      throw:
    </td>
    <td>
      &#8595;
    </td>
    <td>
      S
    </td>
  </tr>
    </tr>
      <td>
      interact:
    </td>
    <td>
      right shift
    </td>
    <td>
      left shift
    </td>
  </tr>
</table>


<br>

---

## Game Play
<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/gameplay_title.png" width=500>

### Main Menu

<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/menu.png" width=500>

### Game Play Instructions

<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/howto.png" width=500>

### Game Play

<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/gameplay.png" width=500>


---

## Architecture

Small Boi was created using Unity and Visual Studio.  Our scripts are written in C#.  The multiplayer network features are handled with Photon.


<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/diagram.png" width=600>

### MulitPlayer server flow
<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/multi-flow.png" width=600>

### MultiPlayer Player Flow
<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/player-flow.png" width=600>

---

## Change Log

- *03/15/2021* 
  - Built out the basic environment and level prefabs.
  - Got basic player movement and jumping scripted.
  - Scaffolded out the game UI.
  - Set up Photon to work towards enabling multiplayer network play, two shapes are in and moving.
- *03/16/2021*
  - Created more environmental objects including waterfalls, doors and buttons.  Attached the scripts to make them all function.
  - Added more player controls including the ability to throw each other and objects, and the ability to grab and move objects around.
  - Built UI components to track players health and stars collected.  Linked up all of the game navigation and an escape button menu screen.
  - Expanded the network play to include player objects and gameplay field.  Movements are synced with exception to physics related methods.
- *03/17/2021*
  - All environmental puzzle objects are functioning and the level is playable.
  - Player objects have been finalized and are able to work through the level in a cooperative play style.
  - Implemented a bad guy baldy object that the player can pick up and use to solve puzzles.
  - Plugged the UI components into the game play elements to correctly track health and stars collected during game play.
  - Scaffolded out a couple more levels to add to later.
- *03/18/2021*
  - Polished up the appearance of the first level.
  - Added a transition to the exit door to move the players to the next level.
  - Attached Audio to the game.
  - Copied and Adapted physics related scripts into RPC scripts, to sync player interactions in multiplayer network play.
  - 

---

## Authors
- [Alan Hung](https://github.com/AlanYHung)
- [Ameilia Valdes](https://github.com/AGValdes)
- [David Dicken](https://github.com/daviddicken)
- [Jordan Kidwell](https://github.com/jordanlynk)
- [Scott Falbo](https://github.com/scottfalbo)
- [JP Jones](https://github.com/4a50)
- [Michael Falk](https://github.com/MikeyFalk)
- [Kjell Overholt](https://github.com/Overholtk)
- [Krystian Francuz-Harris](https://github.com/KrystianFH)
- [Matthew Peterson](https://github.com/Mattpet26)

---

## Attributions
+ [Code Fellows](https://www.codefellows.org/)
  + John Cokos
  + Bade Habib
  + Phil Werner
+ [Brackeys: Goto Unity Reference](https://www.youtube.com/user/Brackeys)
+ [Movement Animation](https://www.youtube.com/watch?v=rycsXRO6rpI)
+ [Jump](https://www.youtube.com/watch?v=ptvK4Fp5vRY)
+ [Camera Follow](https://www.youtube.com/watch?v=VJjD1Tp1I8U)
+ [Moving Platforms](https://www.youtube.com/watch?v=4R_AdDK25kQ)

<img src = "https://github.com/AmeiliaAndTheSmallBois/SmallBoi/blob/main/Assets/thanks.png">
