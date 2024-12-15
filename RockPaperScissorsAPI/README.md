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

## Further implementations

- The application does not implement any kind of ***logging*** as it is. This is a feature that would be desirable in order to collect information about usage, make troubleshooting and understanding errors easier along with detecting breaches and security threats.
- There are currently no ***unit tests*** incorporated in the project. This is important to implement further on in order to validate the code and make sure it works as intended and secure the code when making changes.
- As of now there is no use of ***async/await*** features, which would be benificial when there might be a database involved. It would improve the performance and responsiveness of the application by letting it handle more requests simultaneously.