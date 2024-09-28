# Super Mario
### Course: CSE 3902 AU24
### Instructor: Neil Kirby
### Team: Five-Guys
- Christian Blue
- Hahn Choi
- Jingyu Fu
- Zhuoyang Li
- Aidan Whitlatch

## Game Introduction

Super Mario is a classic platform adventure game that takes players on an exciting journey through the Mushroom
Kingdom. Join Mario, the courageous plumber, as he embarks on a quest to rescue Princess Peach from the clutches of
the evil Bowser. Leap over obstacles, stomp on enemies, and navigate treacherous landscapes filled with hidden 
secrets and power-ups. Whether you’re dodging fire-breathing plants or exploring underwater realms, each level offers
a new challenge and surprise. With iconic music, vibrant graphics, and timeless gameplay, Super Mario is a thrilling
adventure that brings joy to gamers of all ages. Get ready to jump, run, and save the day!

## How to play the game
#### Player control:
- W: jump
- A: move left
- D: move right
- S: crouch
- Z: throw the fireball
- N: special attack
- 1, 2: chanage Mario state
- 3:
- E: Mario gets hurt
- T: CycleBlockLeft
- Y: CycleBlockRight
- U: CycleItemLeft
- I: CycleItemRight
- O: CycleEnemyLeft
- P: CycleEnemyRight
- Q: Quit the game
- R: Reset


## Game Elements
- **Player:** Mario
- **Enemies:**
  - Goomba
  - Koopa
  - Koopa Shell
  - Bowser
- **Items:**
  - Red Mushroom
  - Green Mushroom
  - Flower
  - Coin
  - Star
- **Blocks:**
  - Chiseled Block
  - Brick Block
  - Hit Block
  - Ground Block
  - Question Block

## Tools and Processes Used

1. **Command Pattern:**
   - The project implements the Command pattern for handling user inputs. Each command is encapsulated in its own
    class, making the codebase modular and easier to manage.

2. **Cycling Mechanism:**
   - The project uses custom cycler classes (`EnemyCycler`, `ItemCycler`, `BlockCycler`) to manage the cycling of
    different game elements, enabling easy switching between different game objects for testing and gameplay.

3. **Factories:**
   - The Factory pattern is used for creating various game objects like enemies, items, and blocks. This helps in
   maintaining the code by centralizing the object creation logic.

4. **Sprite Management:**
   - A centralized SpriteFactory is used to load and manage all sprite assets, ensuring efficient memory usage and
   organization.

