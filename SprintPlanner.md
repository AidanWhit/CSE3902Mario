# Sprint Planner
Here is the Sprint Planner that will be used to document our plans, design changes, and so forth for the sprints within this class.

## Sprint 3 Plan

### Start Date: 09/30/24 
### End Date: 10/19/24 @ noon

| Tasks | Time(Effort) | Time Remaining | In Progress (Name) | Expected Finish Date | Finished Date |
|------:|--------------|----------------|--------------------|----------------------|---------------|
| Camera class | 2-4 hours| 0 hours | Jin Fu & Zhuoyang | 10/9 | 10/11 |
| XML/JSON files | 6 hours | 0 hours | Zhuoyang | 10/12 | 10/16 |
| LevelLoader | ~8 hours | 0 hours | Hahn | 10/12 | 10/16| |
| Collision Detection | 6 hours | 0 hours | Aidan & Christian | 10/14 | 10/14 |
| Collision Response  | 10 hours | 0 hours | Aidan & Christian | 10/14 | 10/14 |
| Game Object Manager | 6 hours | 0 hours | Jin Fu | 10/9 | 10/13 |
| Grader Meeting | 1 hour | 0 hour | Everyone that can attend | 10/14 or 10/15 | 10/17 |

### BackLog tasks from Sprint2 
| Tasks | Time(Effort) | Time Remaining | In Progress (Name) | Expected Finish Date | Finished Date |
|------:|--------------|----------------|--------------------|----------------------|---------------|
| Star Mario Decorator | 2 hours | 0 hours | Aidan | 10/7 | 10/12 |
|  Enemy Damage Functions | 2 hours | 0 hours | Zhuoyang | 10/9| 10/12 |
| Block States | 4 hours | 0 hours | Christian | 10/9 | 10/12|
| Align all of mario's sprites on the bottom of the sprite | 2 hours | 0 hours| Aidan | 10/7 | 10/2 |


## List of features to be added
Strikethrough implies the items have been completed
* ~~ICamera~~
* ~~Camera Class~~
* ~~GameObject manager class~~
    - ~~void AddObj(IGameObject)~~
    - ~~void RemoveObj(IGameObject)~~
    - ~~List <IGameObject> for enemies, items, blocks~~
    - ~~Potentially Draw(), Update()~~
* ~~IGameObject~~
* ~~Collison Handler Class(es)~~
* ~~Collison Response Class(es)~~

### Backlog of tasks for Sprint3
* Refactor how GameObjectManager stores lists of drawables so newly created items will not be drawn on top of the block they spawn from
* Fix crouching bug that sometimes occurs when the player jumps and the holds crouch while jumping. This can cause the player to move up and down extremely quickly
* Move keyboard commands out of Game and into level loader or a different class
* Have level loader (or some other class) populate the sprite factories with the data they need to create sprites
* Possibly refactor player to privatize some of its public properties
* Add a way to change between different levels while the game is running through commands

## Design Changes
* We initally designed the collision system to rely on multiple response classes but later decided that there should only be one response class. Thus, we had to refactor a lot of our existing collision system.
* The enemies needed to be refactored from the previous sprint to allow them to support the various behaviors/states they needed to show at different times/collisions.
