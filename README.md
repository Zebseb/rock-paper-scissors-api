# RockPaperScissorsAPI

A Rock-Paper-Scissors application where the game is being played using solely the API endpoints. The game is always played between **two players** where a *Player Name* and a *Move* is to be made by both in order to complete it. The project is based on ASP.NET Core and written in C#. This is a work sample for Cygni (part of Accenture).

## Installation

1. Extract the files of this zip and save it to a desired destination on your computer.
2. Open the project by opening the **RockPaperScissorsAPI** folder in your IDE of choice (e.g. Visual Studio). Alternatively double-click `RockPaperScissorsAPI.sln` to automatically open the project.
3. Start the server by running a "**New Instance**", with or without debugging (shortcuts: **F5** / **Ctrl + F5**).

## Usage & features

#### **The game can be played using Swagger, Postman or another API Client Tool of your choice.**

- Start the game by using the **POST** endpoint. Enter a *Player Name* to get the *Game ID* in return.
- Use the **PUT** endpoint to join the *Game*, also by entering the *Game ID* and a *Player Name*.
- The **PATCH** endpoint is used when a *Player* wants to make a *Move*. This is done by entering the *Game ID*, your *Player Name* and a *Move* (only Rock, Paper or Scissors is valid).
- There are two **GET** endpoints ("*/status*" and "*/result*") that can be used at any time, but with different output depending on how far the *Game* process has gone. Only the *Game ID* is needed as input here.
