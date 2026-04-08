# Hunt the Wumpus

A text-based cave exploration game written in C#, based on the classic 1973 Hunt the Wumpus design.

## Overview

Players navigate a cave system, hunt the Wumpus, avoid hazards, and collect gold. The game ships with four distinct cave topologies, each encoded as an adjacency matrix, which determines how rooms connect to one another. Hazards are placed randomly at the start of each game, ensuring replayability. A scoring system tracks performance across the session, and high scores are persisted to disk.

## Caves

Choose from four cave layouts at the start of each game:

- **Dodecahedron Cave** — the classic 20-room dodecahedron structure
- **The Mobius Strip** — a twisted loop topology
- **The String of Beads** — a linear chain of rooms
- **The Toroidal Hex** — a hex grid with wrap-around edges

## Hazards

| Hazard | Effect |
|---|---|
| Wumpus | Kills the player on contact |
| Pits | Instant death if you fall in |
| Super Bats | Picks you up and drops you in a random room |

Nearby hazards trigger environmental clues:
- "You smell a horrid stench..." — Wumpus is adjacent
- "You feel a draft..." — a pit is adjacent
- "Bats nearby!" — bats are in an adjacent room
- "You see something shiny..." — gold is adjacent

## Scoring

| Action | Points |
|---|---|
| Find gold | +200 |
| Kill the Wumpus | +100 |
| Each move | -1 |
| Bat encounter | -5 |
| Fall into a pit | -50 |
| Miss a shot | -11 |

High scores are saved to `C:\Highscores\WumpusHighScore.txt`.

## How to Run

**Prerequisites:** .NET Framework and Visual Studio (or any C# compiler).

1. Clone the repository.
2. Open `HuntTheWumpus.sln` in Visual Studio.
3. Build and run the project.

**Commands during play:**

- `move` — move to an adjacent room (enter the room number when prompted)
- `shoot` — fire an arrow into an adjacent room
- `quit` — exit the current game

## License

MIT License
