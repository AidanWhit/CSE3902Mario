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
        public MarioCollideTopCommand(IPlayer player, Rectangle collisionIntersection)
        {
            mario = player;
            height = collisionIntersection.Height;
        }

        public void Execute()
        {
            mario.YPos -= height;
            if (!mario.isJumping)
            {
                mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X, MarioPhysicsConstants.gravity);
            }
            if (mario.isFalling)
            {
                mario.Idle();
                mario.PhysicsState = new Grounded(mario);
            }
        }
    }
}
