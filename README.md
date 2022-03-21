# Project AOTF

Gotta Get Back is a topdown dungeon crawler roguelike that provides gamers, who are fans of the roguelike genre, a captivating roguelike experience that also immerses the user in a charming story. Or at least, that would be our final goal in terms of delivering a value. Of course, while we have yet to implement most of the features to deliver such a value, the features in our current system are as follows. Currently, our game loop consists of a white square with a gun, controlled by the player, fending off red enemy squares, controlled by the enemy AI system, that periodically spawn as waves attempting to defeat the player. Moreover, our system has multiplayer capabilities that allow players to host or join a game session, all through a simple menu.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

You will need the Unity Framework, version f1, as well as the MLAPI package from Unity.

### Installing

Install the Unity Framework

```
https://unity.com/download
```

Install the Gotta Get Back folder from the directory 
```
https://github.com/CS386-S22-Group1/cs386-project/tree/main/GottaGetBack
```
Move the folders into the Unity Framework to implement them, and then compile to see and play the game.

## Running the tests

Unity has a built in unit testing system called test runner that we are using to make our unit tests.
https://github.com/CS386-S22-Group1/cs386-project/tree/main/GottaGetBack/Assets/Tests
We have a unit test to test that our starting positons for the player should be zeroed out as well as the intial x and y input are zeroed out

## Built With

* Unity Framework: The Unity frameowrk is a popular game-building platform that allows users to easily create games using the C# programming language. We chose Unity because several of our team members have experience programming in C#, so we thought this was out best option to reduce the learning curve among our team.

* Unity Netcode: Unity Netcode is an extension to the Unity framework that assists developers in adding multiplayer functionality to their games. Netcode handles all of the network and transporation layers and allows the developer to interect with the library using C# objects.

* C#/Microsoft .NET: Microsoft .NET better known as the C# programming language is used by the Unity framework. All the code for Unity games is written in C# and Unity integrates closely with the Microsoft .NET platform.

## Versioning
This is an initial build, so we are currently on Version 1.0

## Authors

* **Zachary Bryant** - *Art* 
* **Asa Henry** - *Game Mechanics*
* **Sam Gerstner** - *Game Mechanics*
* **Lenin Valdivia** - *Game Mechanics*
* **Brian Ruiz** - *Art*
* **Noah Nannen** - *Story*

See also the list of [contributors](https://github.com/CS386-S22-Group1/cs386-project/graphs/contributors) who participated in this project.
