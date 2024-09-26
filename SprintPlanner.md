# Sprint Planner
Here is the Sprint Planner that will be used to document our plans, design changes, and so forth for the sprints within this class
## Sprint 2 Plan
### Start Date: 09/09/24 
### End Date: 09/28/24 @ noon


| Tasks(Effort) | In Progress (Name) | Expected Finish Date | Finished Date |
|--------------:|--------------------|----------------------|---------------|
|Create Interfaces (30 mins)| No assigned person, each person makes what they need| 9/15 | 9/26 |
|Handle State Transitions (~ 2 hours)|Aidan Whitlatch & Jin Fu| 9/21 | 9/19|
| Create Enemy Classes (4-6) hours|Jin Fu | 9/21 | 9/20 |
| Create Item Classes (3 hours) | Hahn Choi | 9/21 | 9/22 |
| Create Block Class(es) (2 hours) | Christian Blue | 9/21 | |
|Implement Commands (1.5 hours) | Hahn Choi | 9/13 | 9/18 |
| Implement Keyboard (1.5 - 2 hours) | Zhouyang Li | 9/14 | 9/18 |
| Create README doc for the project (1.5 hours) | Zhuoyang Li | 9/22 | |
|Grader meeting 1 | Everyone that can go | 9/16 | Took us too long to get far enough in the project to schedule at this time |
|Grader meeting 2 | Everyone that can go | 9/23 | 9/26 |

## Notes
 * **Aidan's Portion:** The player took much longer than I was anticipating to finish. A major refactoring of the player code added a lot of extra time that I did not initially account for. In essence, the effort put in was much much larger than what I was expecting.

## Backlog to be finished next Sprint :
* Fix Crouching so that Mario moves down to the correct level
* Make Fireballs move diagonally all the way to the ground before they start bouncing
* Add properties/functions to enemies so that they can interact with the environment/player (e.g. health, move, take damage)

## List of Features that need Implemented for this Sprint
### Completed Features will be crossed off

Factories to make:
* ~~Player~~
*  ~~Block~~
*  ~~Enemy~~
*  ~~Item~~

Interfaces and Potential Features:
* ISprite
   - Draw, Update
* ~~IPlayer~~
*  ~~Item~~
*  ~~IBlock~~
   - ~~boolean hasItem~~
   - hasCoin
   - ~~hasBeenHit~~
 * ~~IProjectile~~
   - ~~int velocity~~
   - int lifespan
* IEnemy
  - int health
  - void move
  - void attack
  - void takeDamage
  - boolean isDead/isDefeated
## Next two were never implemented but might still need to be for future sprints
* IDrawable
* IUpdateable
## For future considerations
* ICollideable

## Design Changes
* boolean hasCoin for the block class was decided to be pointless as hasItem can be used instead.    
* IState was decided to never be implemented because we opted to use a state machine design instead which did not require the interface.    
* We did not implement all of our envisioned properties for the IEnemy interface this sprint because it would be easier to implement them once we get a working collision system. Coding these features without exactly knowing how collision would work had the possibility of being a time waster that we wanted to avoid.
* int lifespan was decided not to be needed because Mario's fireballs only despawn when they collide with something or when they go offscreen. Representing this behavior with a projectile lifespan would not make much sense so we decided to scrap the idea all together.


