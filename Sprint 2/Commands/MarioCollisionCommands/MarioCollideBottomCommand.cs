using Sprint_2.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Constants;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.Sprites;

namespace Sprint_2.Commands.MarioCollisionCommands
{
    public class MarioCollideBottomCommand : ICommands
    {
        private IPlayer mario;
        private int height;
        public MarioCollideBottomCommand(IPlayer player, IBlock block, Rectangle collisionIntersection)
        {
            mario = player;
            height = collisionIntersection.Height;
        }

        public void Execute()
        {
            if (!mario.isFalling)
            {
                mario.YPos += height;
                mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X, 0);
                mario.Fall();
                mario.PhysicsState = new Falling(mario);
            }
            
        }
    }
}
