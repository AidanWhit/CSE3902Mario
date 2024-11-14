# Sprint Planner
Here is the Sprint Planner that will be used to document our plans, design changes, and so forth for the sprints within this class.

## Sprint 5 Plan

### Start Date: 11/09/24 
### End Date: 11/30/24 @ noon

| Tasks | Time(Effort) | Time Remaining | In Progress (Name) | Expected Finish Date | Finished Date |
|------:|--------------|----------------|--------------------|----------------------|---------------|
| Gun Powerup | 10 hrs | 10 hrs | Aidan Whitlatch | 11/23 | |
| Boss Level (XML file) | 5 hrs | 5 hrs | Jingyu Fu | 11/23
| Bowser (we already have sprites and class for bowser, but further features need to be implemented)| 4 hrs | 4 hrs | Zhuoyang Li + Aidan Whitlatch | 11/25 |
| Bowser Fireball Attack (we already have sprites and class for bowser fireball, but further features need to be implemented)| 2 hrs | 2 hrs| Hahn Choi + Christian Blue |11/25 |
| Bowser Hammer Attack | 4 hrs | 4 hrs | Zhouyang Li + Aidan Whitlatch| 11/25 |
| New Blocks | 2hrs | 2 hrs | Christian Blue | 11/17 |
| Moveable Platform | 2 hrs | 2 hrs | Christian Blue | 11/17 |
| New Enemy (Can be simple, maybe bullet bill?)| 4 hrs | 4 hrs | Hahn Choi | 11/23 |
| New Levels (XMLFiles, aim for 2-3)| 6 hrs | 6 hrs | Zhuoyang Li | 11/25 |
| Podoboos (fireballs that jump out of lava, used in castle level) | 3 hrs | 3 hrs | Hahn Choi | 11/25 |
| Main Menu |5 hrs | 5 hrs | Jingyu Fu  | 11/13
| Spawner(teleporter) |5 hrs | 5 hrs | Jingyu Fu  | 11/13
| Level transition |5 hrs | 5 hrs | Jingyu Fu  | 11/13
| Fall detection |5 hrs | 5 hrs | Jingyu Fu  | 11/13

## BackLog tasks from Sprint4
### Not required for this sprint but would improve the quality of our code

| Tasks | Time(Effort) | Time Remaining | In Progress (Name) | Expected Finish Date | Finished Date |
|------:|--------------|----------------|--------------------|----------------------|---------------|
| Privatize public variables within GameObject classes | 8 hrs | 8 hrs| Will only be done if there is time | 11/27 |

## List of new Features (classes)
Strikethrough implies that the item has been completed
* Gun Powerup decorater
  - Handle shooting
  - Handle drawing the gun
  - Removing the Powerup
* Mouse Controller
  - Used to keep track of the mouse's position
  - On click command execution
 * Bowser Class
   - Various behaviors that will detail the execution of his attacks (Could be their own separate classes)
      * Jump Behavior
      * Fireball Behavior
      * Hammer Attack Behavior
* New Block classes (new block states in the context of our project)
  - Includes a moveable platform

* Main Menu
   - Play
   - Credits
   - Quit
* Spawner
   - Fall detection(reset Mario's location when he fell)
   - a "from-to" spawner/teleporter (from 1-1 to underworld, from 1-1 to 1-2, from main menu to 1-1), setting Mario's location after a specific trigger event
   - has a method like teleport(x,y){}. setting Mario to any location in the current game world for testing
* Level transition
  - Gameworld manager: keeps track of the current gameworld(1-1,1-1under ...) so that it can work with pipes
  - intermediate state: similar to "win" but not exactly win, just "stage-clear" and then move to the next level
  - Rewrite how the level is loaded so that transition can work smoothly
