using Microsoft.Xna.Framework;
using Sprint_0.Sprites;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.MarioPhysicsStates
{
    public class Falling : IMarioPhysicsStates
    {
        private Player mario;
        private int originalPlayerHeight;
        public Falling(Player mario, int origialPlayerHeight) 
        {
            this.mario = mario;
            this.mario.State.Fall();
            this.originalPlayerHeight = origialPlayerHeight;
        }

        public void Update(GameTime gameTime)
        {
            mario.YPos += (int)(mario.PlayerVelocity.Y * gameTime.TotalGameTime.TotalSeconds);
            mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;

            if (mario.YPos > originalPlayerHeight)
            {
                mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X, 0);
                mario.PhysicsState = new Grounded(mario);
                mario.State.Crouch();
            }


        }
    }
}
