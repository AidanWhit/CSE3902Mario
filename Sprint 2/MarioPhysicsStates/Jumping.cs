using Microsoft.Xna.Framework;
using Sprint_0.Sprites;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
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
                mario.YPos += (int)(mario.PlayerVelocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
                mario.XPos += (int)(mario.PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);
                Debug.WriteLine("Mario XVelocity: " + mario.PlayerVelocity.X);


                mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X, mario.PlayerVelocity.Y * MarioPhysicsConstants.velocityDecay);
                //mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;
                
                if (Math.Abs(mario.YPos - originalMarioY) > MarioPhysicsConstants.maxJumpHeight)
                {
                    mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X, 0);
                    mario.PhysicsState = new Falling(mario, originalMarioY);
                }
            }
            
        }
    }
}
