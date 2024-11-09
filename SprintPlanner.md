# Sprint Planner
Here is the Sprint Planner that will be used to document our plans, design changes, and so forth for the sprints within this class.

## Sprint 4 Plan

### Start Date: 10/21/24 
### End Date: 11/9/24 @ noon

| Tasks | Time(Effort) | Time Remaining | In Progress (Name) | Expected Finish Date | Finished Date |
|------:|--------------|----------------|--------------------|----------------------|---------------|
| HUD | 8hrs |0hrs|Zhuoyang Li| 10/30| 11/04|
| Sounds |8hrs|0hrs| Jingyu Fu| 10/27| 10/24 |
| Flag Collison + Animation | 3-4 hours | 0 hours | Chirstian + Aidan | 10/26 | 10/24 |
| Underground XML | 1-2 hours | 0 hours | Zhuoyang Li| 10/28 | 10/29|
| Collision on entering/leaving underground  | 2 hours | 0 hours | Aidan | 10/28 | 10/30|
| Score points appear on screen | 1-2 hrs| 0hrs | Zhuoyang Li | 10/28| 11/04 |
| Remove magic numbers/strings | 6 hrs| 0 hrs | Everyone | 11/4 | 11/9 |
| Create stationary coin for underground | 2 hours |  0 hours | Christian | 10/30 | 10/23 |
| Pausing the Game |2hrs|0hrs | Jingyu Fu|10/27| 10/24 |
| Win State | 2hrs| 0hrs |Jinguy Fu|10/27| 10/27 |
| Game Over state | 2hrs|0hrs  |Jingyu Fu|10/27|10/27 |
| Grader Meeting | 1 hour | 0 hour | Everyone | Sometime during the last week | 11/6 & 11/8

### BackLog tasks from Sprint3
| Tasks | Time(Effort) | Time Remaining | In Progress (Name) | Expected Finish Date | Finished Date |
|------:|--------------|----------------|--------------------|----------------------|---------------|
| Move Keyboard instantiation to a different class | 2hours | 0hrs | Hahn | 10/28 | 10/25 |
| Brick break effect | 2 hours| 0hours | Aidan | 10/28 | 10/25 |
| Refactor GameObjectManager | 2hrs | 0hrs | Hahn | 10/28| 10/26 |
| Figure out to enter underground via different levels or teleportation | 4hrs | 0hrs | Hahn | 10/30| 10/30|
| Add the ability to add sprite data to factories through a file | 2hrs| 0hrs| Hahn | 10/30| 11/04 |
| Possibly refactor the player class | 4 hours | 0 hours | Aidan | 11/4 | 11/08 |


## List of features(classes)
Strikethrough implies the items have been completed
* ~~HUD~~
  - Text Class
  - ~~Timer~~
  - ~~Lives~~
  - ~~Score~~
  - ~~Coin Counter~~
* ~~Sound Manager~~
  - ~~ISound interface~~
  - ~~SoundEffectWrapper~~
  - ~~SoundManager~~
  - ~~SFX~~
  - ~~BGM~~
* ~~State Manager~~
  - ~~Update Game based on current~~
  - ~~Pause state(command)~~
  - ~~Win state~~
  - ~~Game over state~~
## Backlog tasks for next sprint
* If there is time, a lot of the GameObject classes should have their XPos, YPos variables privatized to improve code quality. This would take a lot of time as accesses to these variables are strewn out everywhere in the code
## Design Changes
* The idea of a state manager was scrapped and instead the states were broken up into distinct classes that would update the game based on its
  respective state. Game1 has a gameState object that is constantly updating based on whatever IGameState is assigned to it.
* The text class was never implemented, instead spriteBatch.DrawString() was used to have text displayed on the screen for the HUD as well as the GameOver/Win screens
* The Player class was not able to be refactored as much as we would have liked during this sprint but it is still something that can be done next sprint if need be.
