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

- W/Up Arrow: jump
- A/Down Arrow: move left
- D/Right Arrow: move right
- S/Left Arrow: crouch
- Z: throw the fireball
- 3: power up
- Q: Quit the game
- R: Reset
- E: Force the Player to take damage

## Sprint3 Content

- **Camera:** Camera will manages the player’s view by smoothly following their horizontal movement while keeping the vertical position fixed. It uses interpolation for smooth transitions, clamps movement within level boundaries, and applies scaling to ensure the game world is rendered correctly on the screen.
- **Background:** Backgrounds can be drawn in two ways: by giving the similar data as other blocks and items, given their sprite location; or by directly generating a background image for the entire level.
- **XML files:** We have 2 XML files for testing level and SMB 1-1, the xml files contain all the properties of the objects in the level.
- **LevelLoader:** Given an xml file of object data, the level loader reads through all of these items and then creates objects from that data based on what the data represents. These created objects are then added into specific lists in GameObjectManager based on what kind of object they are. 
- **Game Object Manager:** GameObjectManager categorizes all the objects needed in the game and stores them as collections.
- **Collision Detection:** Collision Detection uses a list of all moveable collideables and static collideables from GameObjectManager to detect collisions. If two items are intersecting, the ResolveCollision from the CollisionResponse class is called to deal with that specific collision
- **Collision Response:** Using a dictionary of keys and their associted commands, commands are instantiated and then executed during runtime to resolve collisions. The key consists of the collision type of the source object, the collision type of the receiver object, as well as the side that the collison was detected on in reference to the source. 


## How to Load Different Levels

In this sprint, we have created two levels, and the data are stored in two XML files, and we need to let LevelLoader read the two files separately to enter different levels.
The test level be loaded instead of level 1-1 by commenting out line 123 in Game1.cs and the uncommenting line 124. This will then have level loader load the xml file associated with the test level.

## Team Management

We reflected on our experience in implementing last Sprint and worked to do a better job of teamwork and project management this time:
First, we implemented most of the features a week before the deadline, and we identified and solved problems in the code during each class discussion.
Secondly, we made appointments with instructors and TAs for Code Review and Group Meeting in advance, which left us enough time for Debugging and Refactoring.
The project progress management was also better than last time, we created different channels on the Discord server for us to implement different functionalities in smaller groups; we had different branches in the Github repository to implement and test the code, which accelerated our progress.

## Tools and Processes Used

1. **Command Pattern:**

   - The project implements the Command pattern for handling user inputs. Each command is encapsulated in its own
     class, making the codebase modular and easier to manage.
2. **Object Manager:**

   - The **GameObjectManager** is a central class(Singleton)  responsible for managing all the game objects in game, such as player, enemies, items, background elements, and blocks.
3. **XML Files:**

   - First we used Microsoft Excel to fill in the level data, the reason we used Excel is that it's easy to modify and generate whole rows and columns of data with it and most of the blocks in the levels have some of the same attributes such as height, name etc. We then wrote an external program in python to read the data from the Excel sheet and use it to generate XML files.
4. **.NET Type system**
   - This allows us to use Reflections to create new ICommands objects during runtime that are then executed to resolve detected collisions. 

## Known Bugs

* Sometimes when holding crouch during a jump and then landing, mario will move up and down really quickly
* xml file from the XMLgenerator might generates a file start with:
  ```xml
   line1: <?xml version="1.0" encoding="utf-8" ?>
   line2: <?xml version="1.0" ?>"
  Manually delete the line2 before using this file
