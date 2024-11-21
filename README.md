# Hunt the Wumpus Game

Welcome to **Hunt the Wumpus**, a classic text-based adventure game where players navigate a cave, hunt a dangerous creature, and avoid deadly hazards. This game supports multiple cave layouts, hazards, and a scoring system. It also saves high scores for bragging rights!

---

## 🎮 Features

### 🗺️ Cave Systems
Players can select from four unique cave layouts:
1. **Dodecahedron Cave**
2. **The Mobius Strip**
3. **The String of Beads**
4. **The Toroidal Hex**

Each cave system presents unique challenges and navigation paths. 

---

### ⚠️ Hazards
While exploring the cave, watch out for:
- **Wumpus**: The target of the hunt, but beware—it can kill you if you're in the same room.
- **Pits**: Falling into a pit means instant death.
- **Super Bats**: These pesky creatures will pick you up and drop you in a random room.

---

### 🏆 Scoring System
The game includes a detailed scoring system:
- **+200 points**: Finding gold.
- **+100 points**: Killing the Wumpus.
- **-1 point**: Every move you make.
- **-5 points**: Encountering bats.
- **-50 points**: Falling into a pit.
- **-11 points**: Missing a shot at the Wumpus.

Your score is saved and can be viewed in the high score list.

---

## 📋 How to Play

1. **Start a Game**:
   - Run the program and select "New Game" from the main menu.
   - Choose a cave layout.

2. **Game Commands**:
   - **Move**: Type `move` to move to another room. You'll need to specify the room number.
   - **Shoot**: Type `shoot` to fire an arrow into another room. Specify the room number carefully!
   - **Quit**: Type `quit` to exit the game.

3. **Win Condition**:
   - Kill the Wumpus while avoiding hazards and collecting gold.

4. **Replay Maps**:
   - If enabled, players can replay the same cave layout after the game ends.

---

## 📂 Directory and High Score Management

High scores are saved in a text file located in:

C:\Highscores\WumpusHighScore.txt


To view high scores, select "View High Scores" from the main menu.

---

## 📖 Instructions

1. **Choose a cave layout.**
2. **Navigate carefully using the `move` command.**
3. **Listen for clues**:
   - *"You smell a horrid stench..."* indicates the Wumpus is nearby.
   - *"You feel a draft..."* means a pit is adjacent.
   - *"Bats nearby!"* warns that bats are close.
   - *"You see something shiny..."* hints at gold nearby.

4. **Hunt the Wumpus and collect gold!**

---

## 🛠️ Code Highlights

### Main Components
- **Cave Design**:
  The caves are represented as adjacency matrices, which determine room connections.
- **Hazard Placement**:
  Randomized placement of hazards ensures replayability.
- **Scoring System**:
  Keeps track of moves, encounters, and points.

### Game Loop
The `PlayGame()` method contains the main game loop, which:
- Prompts the user for commands.
- Validates and executes actions.
- Checks win/lose conditions.

### High Scores
High scores are stored and managed using a simple file I/O system.

---

## 🚀 Getting Started

### Prerequisites
- A Windows system (for file paths).
- A C# compiler (such as Visual Studio).

### Installation
1. Clone or download the repository.
2. Open the project in Visual Studio or your preferred IDE.
3. Build and run the program.

---

## 📜 License
This project is licensed under the MIT License. Feel free to use and modify it as needed!

---

## 👩‍💻 Contributing
Contributions are welcome! If you'd like to improve the game, submit a pull request or open an issue.

---

### Happy Hunting! 🏹
