using Microsoft.Xna.Framework;
using Sprint_0.Sprites;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.MarioPhysicsStates
{
    public class Jumping : IMarioPhysicsStates
    {
        private Player mario;
        private int originalMarioY;
        private bool isFalling;

        public Jumping(Player mario)
        {
            this.mario = mario;
            originalMarioY = mario.YPos;
        }

        public void Update(GameTime gameTime)
        {
            if (!isFalling)
            {
                /* Makes mario move upwards until the max jump velocity is achieved */
                if (mario.PlayerVelocity.Y > MarioPhysicsConstants.maxJumpVelocity)
                {
                    mario.PlayerVelocity += MarioPhysicsConstants.marioJumpVelocity;
                }
                mario.YPos += (int)(mario.PlayerVelocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
                mario.XPos += (int)(mario.PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);

                /* Decide which form of jumping we would want to use */

                //mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X, mario.PlayerVelocity.Y * MarioPhysicsConstants.velocityDecay);
                mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;

                /* If max Jump height is reached, make mario fall */
                if (Math.Abs(mario.YPos - originalMarioY) > MarioPhysicsConstants.maxJumpHeight)
                {
                    mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X, 0);
                    mario.playerState.Fall();
                    mario.PhysicsState = new Falling(mario, originalMarioY);
                }
            }

        }
    }
}
