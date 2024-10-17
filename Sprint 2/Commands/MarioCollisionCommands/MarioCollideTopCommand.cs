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
    public class MarioCollideTopCommand : ICommands
    {
        private IPlayer mario;
        private int height;
        public MarioCollideTopCommand(IPlayer player, IBlock block, Rectangle collisionIntersection)
        {
            mario = player;
            height = collisionIntersection.Height;
        }

        public void Execute()
        {
            
            if (!mario.isJumping)
            {
                mario.YPos -= height;
                mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X, MarioPhysicsConstants.gravity);
            }
            if (mario.isFalling)
            {
                mario.YPos -= height;
                mario.Idle();
                mario.PhysicsState = new Grounded(mario);
            }
        }
    }
}
