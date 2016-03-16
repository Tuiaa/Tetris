# Tetris
Tetris made with Unity 3D

Basic features:
- Single player
- 7 different blocks
- Grid size can be changed
- Game ends when new block can't be spawned
- Current and best scores
- Best score is saved into a file

Controls:
RIGHT ARROW - Move block right
LEFT ARROW  - Move block left
DOWN ARROW  - Instantly move block down
UP ARROW    - Rotate block

Components:

Main menu scene:
- Canvas
  - Start button
  - Input fields for grid dimensions
- GlobalObject
  - Moves data from main menu to game scene

GameScene:
- Canvas
  - Restart button
  - Current score and best score
  - Game over text
  - Time since starting a game
- Grid
  - Background for game
  - Blocks are spawned to grid
  - When block can't go down anymore, it is moved to StuckBlocks
  - Updates block positions
  - Removes rows
- BlockSpawner
  - Spawns new block
  - Randomizes blocks to be spawned
  - Checks if new block can be spawned (if game ends)
- GameContoller
  - Updates blocks positions
  - Rotates blocks
  - Ends game
- GlobalObject
  - Same as in Main menu
  - Gives user inputs to change grid size
