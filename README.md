# Battleship

## Table of contents
* [General info](#general-info)
* [Main assumptions](#main-assumptions)
* [Technologies](#technologies)

## General info
Simple Battleship simulation app that generates the course of the game for 2 players.
Simulator have no any improvements just randomly hit points of enemy area.

Api with 2 endpoints: 
1. Generate a simulation of a game and return the game id.
2. Get the generated game simulation by id.
	
## Main assumptions
Game simulation.
2 players.
Area 10x10 points.
Ships are randomly set on area.
When a player hit the ship so he will make another move.
The player win game when all ships of second player are sink.

## Technologies
Project is created with:
- .NET6 web api
	
