using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.Misc;
using Sprint_2.GameStates;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.MarioStates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioFlagPoleCommand : ICommands
    {
        private IPlayer player;
        private ICollideable collideable;
        private Rectangle collisionRect;

        

        public MarioFlagPoleCommand(IPlayer player, ICollideable collideable, Rectangle collisionRect)
        {
            this.player = player;
            this.collideable = collideable;
            this.collisionRect = collisionRect;
        }

        public void Execute()
        {
            
            CalculatePointsEarned(collisionRect.Bottom, collideable.GetHitBox().Top);

            
            Game1.Instance.gameState = new WinState(Game1.Instance.GetKeyboardControl());
            /* Only need to collide with it once */
            GameObjectManager.Instance.Static.Remove(collideable);

            player.Climb();
            player.PhysicsState = new FlagState(collideable.GetHitBox().Bottom, collideable.GetHitBox().Width);
            
            
            /* Want to get the flag sprite to move down */
            Flag flag = (Flag)GameObjectManager.Instance.BackDrawables.Find((x => x.GetType() == typeof(Flag)));
            GameObjectManager.Instance.Updateables.Add(flag);
        }

        private void CalculatePointsEarned(int bottomOfCollision, int YPosOfFlagPole)
        {
            int locationRelativeToFlagPole = bottomOfCollision - YPosOfFlagPole;
            int score;

            /* Use a data table that has the range with its respective score. Based on location determine what range it falls into
             * Lower Bound | Upper Bound | Score */
            if (locationRelativeToFlagPole == 1)
            {
                score = 5000;
            } 
            else if (1 < locationRelativeToFlagPole && locationRelativeToFlagPole <= 26)
            {
                score = 4000;
            }
            else if (26 < locationRelativeToFlagPole && locationRelativeToFlagPole <= 71)
            {
                score = 2000;
            }
            else if (71 < locationRelativeToFlagPole && locationRelativeToFlagPole <= 94)
            {
                score = 800;
            }
            else if (94 < locationRelativeToFlagPole && locationRelativeToFlagPole <= 133)
            {
                score = 400;
            }
            else
            {
                score = 100;
            }

            HUD.Instance.AddScore(score);
        }
    }
}
