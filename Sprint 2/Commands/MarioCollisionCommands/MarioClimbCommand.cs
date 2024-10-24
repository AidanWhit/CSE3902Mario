using Microsoft.Xna.Framework;
using Sprint_2.GameObjects.Misc;
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
    public class MarioClimbCommand : ICommands
    {
        private IPlayer player;
        private ICollideable collideable;
        private Rectangle collisionRect;

        

        public MarioClimbCommand(IPlayer player, ICollideable collideable, Rectangle collisionRect)
        {
            this.player = player;
            this.collideable = collideable;
            this.collisionRect = collisionRect;
        }

        public async void Execute()
        {
            /* Only need to collide with it once */
            GameObjectManager.Instance.Static.Remove(collideable);
            player.PhysicsState = new FlagState(collideable.GetHitBox().Bottom, collideable.GetHitBox().Width);
            player.Climb();
            
            

            /* Want to get the flag sprite to move down */
            Flag flag = (Flag)GameObjectManager.Instance.Drawables.Find((x => x.GetType() == typeof(Flag)));
            flag.AddToUpdateables();
        }
    }
}
