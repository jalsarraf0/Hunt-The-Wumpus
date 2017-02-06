using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HuntTheWumpus
{
    class Program
    {
        static int[,] adjacentRooms; // adjacentRooms rectangular array. See CreateCave() for initialization.
        static int numRooms, currentRoom; // currentRoom is an integer variable that stores the room the player is currently in (between 0-20)
        static int wumpusRoom, batRoom1, batRoom2, pitRoom1, pitRoom2, goldroom1; // Stores the room numbers of the respective hazards
        static bool playerAlive, wumpusAlive; // Are the player and wumpus still alive? True or false.
        static Random random = new Random(); // Our random number generator
        static bool canReplay = false;
        static int score = 0;
        static int total; //Score Total
        

        // Score Variables
        static bool gold1Found = false;
        static int numMoves = 0;
        static int numBats = 0;
        static int numMissed = 0;
         





        // This method creates or builds the cave network, mainly initalizing the adjacentRooms array.
        // This is where you will add support for new types of caves.
        static void CreateCave()
        {
            // The adjacentRooms rectangular array is the core of the Dodecahedron cave. 
            // It is a 2D array that lists each room and which rooms are adjacent to that room.
            // It essentially encodes the design of the cave into an array.
            // For example, the first element of adjacentRooms states that room 0 is adjacent to rooms 1, 4, 7. Next room 1 is adjacent to rooms 0, 2, and 9.
            // If you look at the dodecahedron cave design picture in the instructions you will see how those numbers map to that design.
            int choice;
            Console.WriteLine("Please select cave: ");
            Console.WriteLine("1) Dodecahedron Cave");
            Console.WriteLine("2) The Mobius Strip");
            Console.WriteLine("3) The String of Beads");
            Console.WriteLine("4) The Toroidal Hex");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: // Dodecahedron Cave layout
                        adjacentRooms = new int[,]
                        {
                           {1, 4, 7},   {0, 2, 9},   {1, 3, 11},   {2, 4, 13},    {0, 3, 5},
                          {4, 6, 14},  {5, 7, 16},    {0, 6, 8},   {7, 9, 17},   {1, 8, 10},
                         {9, 11, 18}, {2, 10, 12}, {11, 13, 19},  {3, 12, 14},  {5, 13, 15},
                        {14, 16, 19}, {6, 15, 17},  {8, 16, 18}, {10, 17, 19}, {12, 15, 18}
                        };
                        break;
                    case 2: // The Mobius Strip layout
                        adjacentRooms = new int[,]
                        {
                        {1, 2, 19},   // Room 0
                        {0, 3, 18},   // Room 1
                        {0, 3, 4},    // Room 2
                        {1, 2, 5},    // Room 3
                        {2, 5, 6},    // Room 4
                        {3, 4, 7},    // Room 5
                        {4, 7, 8},    // Room 6
                        {5, 6, 9},    // Room 7
                        {6, 9, 10},   // Room 8
                        {7, 8, 11},   // Room 9
                        {8, 11, 12},  // Room 10
                        {9, 10, 13},  // Room 11
                        {10, 13, 14}, // Room 12
                        {11, 12, 15}, // Room 13
                        {12, 15, 16}, // Room 14
                        {13, 14, 17}, // Room 15
                        {14, 17, 18}, // Room 16
                        {15, 16, 19}, // Room 17
                        {1, 16, 19},  // Room 18
                        {0, 17, 18},  // Room 19
                        };
                        break;
                    case 3: // The String of Beads layout
                        adjacentRooms = new int[,]
                        {
                        {1, 2, 19},   // Room 0
                        {0, 2, 3},    // Room 1
                        {0, 1, 3},    // Room 2
                        {1, 2, 4},    // Room 3
                        {3, 5, 6},    // Room 4
                        {4, 6, 7},    // Room 5
                        {4, 5, 7},    // Room 6
                        {5, 6, 8},    // Room 7
                        {7, 9, 10},   // Room 8
                        {8, 10, 11},  // Room 9
                        {8, 9, 11},   // Room 10
                        {9, 10, 12},  // Room 11
                        {11, 13, 14}, // Room 12
                        {12, 14, 15}, // Room 13
                        {12, 13, 15}, // Room 14
                        {13, 14, 16}, // Room 15
                        {15, 17, 18}, // Room 16
                        {16, 18, 19}, // Room 17
                        {16, 17, 19}, // Room 18
                        {0, 17, 18},  // Room 19
                        };
                        break;
                    case 4: // The Toroidal Hex layout
                        adjacentRooms = new int[,]
                        {
                        {5, 9, 15},   // Room 0
                        {5, 6, 16},   // Room 1
                        {6, 7, 17},   // Room 2
                        {7, 8, 18},   // Room 3
                        {8, 9, 19},   // Room 4
                        {0, 1, 14},   // Room 5
                        {1, 2, 10},   // Room 6
                        {2, 3, 11},   // Room 7
                        {3, 4, 12},   // Room 8
                        {0, 4, 13},   // Room 9
                        {6, 15, 19},  // Room 10
                        {7, 15, 16},  // Room 11
                        {8, 16, 17},  // Room 12
                        {9, 17, 18},  // Room 13
                        {5, 18, 19},  // Room 14
                        {0, 10, 11},  // Room 15
                        {1, 11, 12},  // Room 16
                        {2, 12, 13},  // Room 17
                        {3, 13, 14},  // Room 18
                        {4, 10, 14},  // Room 19
                        };
                        break;
                    default:
                        adjacentRooms = new int[,]
                        {
                           {1, 4, 7},   {0, 2, 9},   {1, 3, 11},   {2, 4, 13},    {0, 3, 5},
                          {4, 6, 14},  {5, 7, 16},    {0, 6, 8},   {7, 9, 17},   {1, 8, 10},
                         {9, 11, 18}, {2, 10, 12}, {11, 13, 19},  {3, 12, 14},  {5, 13, 15},
                        {14, 16, 19}, {6, 15, 17},  {8, 16, 18}, {10, 17, 19}, {12, 15, 18}
                        };
                        break;
                }
            }
            catch (FormatException)
            {
            }

            // Save the total number of rooms in a more user-friendly variable name
            numRooms = adjacentRooms.GetLength(0);
        }

        // This method places the wumpus in the cave
        // It randomly picks a room (except room 0) and sets wumpusRoom to that value.
        static void PlaceWumpus()
        {
            wumpusRoom = random.Next(1, numRooms);
        }

        static void MoveWumpus() // This moves the wumpus if he is shot at and the player misses.
        {
            int newWumpusRoom = random.Next(1, numRooms);
            while (newWumpusRoom == wumpusRoom)
                newWumpusRoom = random.Next(1, numRooms);
            wumpusRoom = newWumpusRoom;
        }


        // This method places bats in the cave
        // It randomly picks a (except room 0) and sets the bats to that value.
        static void PlaceBats()
        {
            batRoom1 = random.Next(1, numRooms);
            while (batRoom1 == wumpusRoom)
            {
                batRoom1 = random.Next(1, numRooms);
            }
            batRoom2 = random.Next(2, numRooms);
            while (batRoom2 == batRoom1 || batRoom2 == wumpusRoom)
            {
                batRoom2 = random.Next(2, numRooms);
            }
            
        }

        // This method places pits in the cave
        // It randomly picks a (except room 0) and sets the pits to that value.
        static void PlacePits()
        {
            pitRoom1 = random.Next(1, numRooms);
            pitRoom2 = random.Next(2, numRooms);
        }

        // This method places gold in the cave
        // It randomly picks a (except room 0) and sets the gold to that value.
        static void PlaceGold()
        {
            goldroom1 = random.Next(1, numRooms);

        }
        // This method returns true if roomB is adjacent to roomA, otherwise returns false.
        // It is a helper method that loops through the adjacentRooms array to check. 
        // It will be used throughout the app to check if we are next to the wumpus, bats, or pits
        // as well as check if we can make a valid move.
        static bool IsRoomAdjacent(int roomA, int roomB)
        {
            for (int j = 0; j < adjacentRooms.GetLength(1); j++)
            {
                if (adjacentRooms[roomA, j] == roomB) return true;
            }
            return false;
        }

        // This is a  method that checks if the user inputted a valid room to move to or not.
        // The room number has to be between 0 and 20, but also must be adjacent to the current room.
        static bool IsValidMove(int roomID)
        {
            if (roomID < 0) return false;
            if (roomID > numRooms) return false;
            if (!IsRoomAdjacent(currentRoom, roomID)) return false;

            return true;
        }

        // This is the method to check if the room is valid to shoot into. 
        // The room number has to be between 0 and 20 but must also be adjacent to the current room.
        static bool IsValidShoot(int roomID)
        {
            if (roomID < 0) return false;
            if (roomID >= numRooms) return false;
            if (!IsRoomAdjacent(currentRoom, roomID)) return false;

            return true;
        }

        // This method moves the player to a new room and returns the new room. It performs no checks on its own.
        static int Move(int newRoom)
        {
            return newRoom;
        }

        // This method allows the player to shoot into a room. It performs no checks on its own.
        static int Shoot(int newRoom)
        {
            if (newRoom == wumpusRoom)
                wumpusAlive = false;
            else
            {
                Console.WriteLine("Miss! But you startled the Wumpus");
                numMissed++;
                MoveWumpus();
                PrintScore();
            }
            return newRoom;
        }

        // Inspects the current room. 
        // This method should check for Hazards such as being in the same room as the wumpus, bats, or pits
        // It must also check if you are adjacent to a hazard and handle those cases
        // Finally it will just print out the room description
        static void InspectCurrentRoom()
        {
            if (currentRoom == wumpusRoom)
            {
                Console.WriteLine("The Wumpus ate you!!!"); 
                playerAlive = false;
                PrintScore();
            }
            if (currentRoom == pitRoom1)
            {
                Console.WriteLine("YYIIIIEEEE...fell in a pit.");
                playerAlive = false;
                PrintScore();
            }
            if (currentRoom == pitRoom2)
            {
                Console.WriteLine("YYIIIIEEEE...fell in a pit.");
                playerAlive = false;
                PrintScore();
            }
            if (currentRoom == batRoom1)
            {
                numBats++;
                Console.WriteLine("Snatched by superbats!!!");
                playerAlive = true;
                currentRoom = Move(random.Next(1, numRooms));
                PrintScore();
            }
            if (currentRoom == batRoom2)
            {
                numBats++;
                Console.WriteLine("Snatched by superbats!!!");
                playerAlive = true;
                currentRoom = Move(random.Next(2, numRooms));
                PrintScore();
            }
            if (currentRoom == goldroom1)
            {
                if (!gold1Found)
                {
                    Console.WriteLine("You found GOLD!!!");
                    playerAlive = true;
                    gold1Found = true;
                    PrintScore();
                }
            }
            if (wumpusAlive == false)
            {
                Console.WriteLine("ARGH...Splat!");
                Console.WriteLine("Congratulations. You killed the Wumpus! You Win.");
                PrintScore();
            }

            if ((currentRoom == wumpusRoom) && (currentRoom == goldroom1))
            {
                Console.WriteLine("The Wumpus ate you but at least you found some gold!");
                playerAlive = false;
                gold1Found = true;
                PrintScore();
            }
            {

            
                // The code below tests to see what is nearby the current room the player is in.
                Console.WriteLine();
                Console.WriteLine("You are in room {0}", currentRoom);
                if (IsRoomAdjacent(currentRoom, wumpusRoom)) Console.WriteLine("You smell a horrid stench...");
                if (IsRoomAdjacent(currentRoom, batRoom1)) Console.WriteLine("Bats nearby!");
                if (IsRoomAdjacent(currentRoom, batRoom2)) Console.WriteLine("Bats nearby!");
                if (IsRoomAdjacent(currentRoom, pitRoom1)) Console.WriteLine("You feel a draft...");
                if (IsRoomAdjacent(currentRoom, pitRoom2)) Console.WriteLine("You feel a draft...");
                if (IsRoomAdjacent(currentRoom, goldroom1)) Console.WriteLine("You see something shiny in the distance...");
                Console.Write("Tunnels lead to rooms ");
                for (int j = 0; j < adjacentRooms.GetLength(1); j++)
                {
                    Console.Write("{0} ", adjacentRooms[currentRoom, j]);
                }
                Console.WriteLine();

            }
            Console.WriteLine();
        }


        // Method accepts a text string which is the command the user inputted.
        // This method performs the action of the command or prints out an error.
        static void PerformAction(string cmd)
        {
            int newRoom;
            switch (cmd.ToLower())
            {
                case "move":
                    Console.Write("Which room? ");
                    try
                    {
                        newRoom = Convert.ToInt32(Console.ReadLine());
                        // Check if the user inputted a valid room id, then simply tell the player to move there.
                        if (IsValidMove(newRoom))
                        {
                            currentRoom = Move(newRoom);
                            numMoves++;
                            InspectCurrentRoom();
                        }
                        else
                        {
                            Console.WriteLine("You cannot move there.");
                        }
                    }
                    catch (FormatException) // Try...Catch block will catch if the user inputs text instead of a number.
                    {
                        Console.WriteLine("You cannot move there.");
                    }
                    break;

                default:
                    Console.WriteLine("You cannot do that. You can move, shoot, or quit.");
                    break;

                case "shoot": // This input shoots at the wumpus and tells the user if they cannot shoot in a certain room.
                    Console.Write("Where to? ");
                    try
                    {
                        newRoom = Convert.ToInt32(Console.ReadLine());

                        if (IsValidShoot(newRoom))
                        {
                            Shoot(newRoom);
                            InspectCurrentRoom();
                        }

                        else
                        {
                            Console.WriteLine("You cannot shoot there.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("You cannot shoot in that room.");
                    }
                    break;
                case "quit": // This input allows the user to quit at any time within the game.
                    Console.Write("Quitting ");
                    try
                    {
                        Environment.Exit(0);

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error. Type: Move, Shoot or quit.");
                    }
                    break;

            }
        }
        // PlayGame() method starts up the game.
        // It houses the main game loop and when PlayGame() quits the game has ended.
        static void PlayGame(bool init)
        {
            // We are about to start the game. 
            string cmd;

            Console.WriteLine("Running the game...");

            // Perform initialization tasks at the beginning of every game
            if (init)
            {
                CreateCave();   // Create the cave network.
                PlaceWumpus();  // Place the wumpus in a room
                PlaceBats();    // Places bats in a room
                PlacePits();    // Places pits in a room
                PlaceGold();    // Places gold in a room
                CreateSave();   // Creates the high score folder
            }
            // Place the player in room 0 and inspect that room to get started.
            playerAlive = true;
            wumpusAlive = true;
            gold1Found = false;
            numMoves = 0;
            numBats = 0;
            numMissed = 0;

            currentRoom = Move(0);
            InspectCurrentRoom();

            // Main game loop.
            // 1) Prompt the user for some input
            // 2) Perform the action the user inputted
            // 3) Check if the game is over or not and keep looping.
            while (playerAlive && wumpusAlive)
            {
                Console.Write(">>> ");
                cmd = Console.ReadLine();
                PerformAction(cmd);
                Write();
            }
        }

        static void PrintInstructions() // Teaches the player how to play.
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Here is how to play:");
            Console.WriteLine("First pick a map you would like to play by pressing the number listed on the map you want.");
            Console.WriteLine("Then you start in room 0. To move your player type move.");
            Console.WriteLine("After typing move, you will need to choose the room number that you want to move to and press ENTER.");
            Console.WriteLine("If you think is the wumpus is nearby type shoot then the room number which you want to shoot into and press ENTER.");
            Console.WriteLine("If you shoot the Wumpus you win!");
            Console.WriteLine("However, if the Wumpus is not in the room you shot into it will move to another room and you will lose points.");
            Console.WriteLine("Also, beware of superbats that can move you to a random room and pits which can kill you!");
            Console.WriteLine("If you move into a room with a pit and superbats you are safe but you will still be moved into another room");
            Console.WriteLine("A Wumpus can be in a room with a pit. Just make sure you do not move in there or you will die!");
            Console.WriteLine("If you want to replay the same exact map again press 5.");
            Console.WriteLine();
            Console.WriteLine("Here's how scoring works:");
            Console.WriteLine("For every move you make you lose 1 point. Try not to move too much!");
            Console.WriteLine("If a bat catches snatches you you will lose 1 point.");
            Console.WriteLine("If you fall in a pit you will lose 50 points.");
            Console.WriteLine("If you try to shoot the wumpus and miss you will lose 10 points. Shoot carefully!");
            Console.WriteLine("If you shoot the wumpus and hit it you will earn 100 points.");
            Console.WriteLine("If you find the room with gold you will earn 200 points.");
            Console.WriteLine("Have fun and make sure to get a high score!");
            Console.WriteLine();
            Console.WriteLine();
        }

        // Creates the directory for the WumpusHighscore.txt
        // This was challenging because I could not get the scores to display correctly or in order.
        static void CreateSave()
        {
            Directory.CreateDirectory("C:\\Highscores");  
        }

        // Write () Saving High Scores. Assumes the path C:\Highscores\WumpusHighScore.txt exists.
        static void Write()
        {
            string highscores = total.ToString();
            string[] allScores = { highscores };
            System.IO.File.AppendAllLines(@"C:\Highscores\WumpusHighScore.txt", allScores);
        }

        // ViewHighScores(). This method should read the high score file from disk and display its contents.
        static void ViewHighScores()
        {
            string[] allScores = System.IO.File.ReadAllLines(@"C:\Highscores\WumpusHighScore.txt");
            Console.WriteLine("Highest Scores:");
            foreach (string line in allScores)
            {
                // Use a new line  
                Console.WriteLine("\n" + line);
            }

        }

        // Scoring System
        static void PrintScore()
        {
            int moveBuffer = 1; // Adds 1 point for each move including shooting
            int batBuffer = 5; // Number deducted per Bats hit
            score = moveBuffer - numMoves; // deducts 1 point for each move
            if (currentRoom == batRoom1) // deducts 5 points if a player runs into bats
                score -= 5;
            if (currentRoom == batRoom2) // deducts 5 points if a player runs into bats
                score -= 5;
            if (gold1Found)
                score += 200;  // Bonus for finding gold
            if (!wumpusAlive)
                score += 100; // Bonus for killing wumpus
            score -= numBats * batBuffer;
            if (currentRoom == pitRoom1) // deducts points for falling into a pit
                score -= 50;
            else if (currentRoom == pitRoom2) // deducts points for falling into a pit
                score -= 50;
            score -= numMissed * 11; // Deducts 11 points for missing to create an even score.
            

            Console.WriteLine("The Score is: {0}", score);

            total = score;
        }




        static void Main(string[] args)
        {
            int choice;
            bool validChoice;
            bool keepPlaying;
            

            // The purpose of the outer do...while loop is when the game ends, we will bring the user back
            // to the main menu, so they can start a new game, view scores, view instructions, or really quit.
            do
            {
                keepPlaying = true;
                Console.WriteLine("Welcome to Hunt The Wumpus.");
                Console.WriteLine("1) New Game");
                Console.WriteLine("2) Print Instructions");
                Console.WriteLine("3) View High Scores");
                Console.WriteLine("4) Quit");
                Console.WriteLine("5) Replay Previous Map");

                do // inner do...while loop is to keep looping until the user picks a valid menu selection
                {
                    validChoice = true;
                    Console.Write("Please make a selection: ");
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1: // User selected New Game
                                PlayGame(true);
                                canReplay = true;
                                break;
                            case 2: // User selected Print Instructions
                                PrintInstructions();
                                break;
                            case 3: // User selected View High Score List
                                ViewHighScores();
                                break;
                            case 4: // User selected Quit
                                Console.WriteLine("Quitting.");
                                keepPlaying = false;
                                break;
                            case 5: // Replay
                                if (canReplay)
                                    PlayGame(false);
                                else
                                    Console.WriteLine("Invalid choice. Must start game first.");
                                break;

                            default:
                                validChoice = false;
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        // This try...catch block catches the FormatException that Convert.ToInt32 will throw 
                        // if the user inputs text or something that cannot be converted to an integer.
                        validChoice = false;
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                } while (validChoice == false); // Inner loop ends when validChoice is true
            } while (keepPlaying); // Outer loop ends when the user selects quit.
        }
    }
}