﻿using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System.Diagnostics;
using System;

namespace Sprint_2.MarioPhysicsStates
{
    public class Grounded : IMarioPhysicsStates
    {
        private IPlayer mario;
        private int originalYPos;
        public Grounded(IPlayer mario)
        {
            this.mario = mario;
            this.mario.PlayerVelocity = new Vector2(this.mario.PlayerVelocity.X, MarioPhysicsConstants.gravity);
            originalYPos = this.mario.YPos;
        }

        public void Update(GameTime gameTime)
        {
            
            if (mario.PlayerVelocity.X > -50f && mario.PlayerVelocity.X < 50f)
            {
                if (!mario.isCrouching)
                {
                    mario.Idle();
                }
                
            }

            if (mario.PlayerVelocity.Y < MarioPhysicsConstants.maxFallVelocity)
            {
                mario.PlayerVelocity += MarioPhysicsConstants.marioFallVelocity;
            }

            mario.XPos += (int)(mario.PlayerVelocity.X * gameTime.ElapsedGameTime.TotalSeconds);
            mario.YPos += (int)(mario.PlayerVelocity.Y * gameTime.ElapsedGameTime.TotalSeconds);

            //mario.PlayerVelocity = new Vector2(mario.PlayerVelocity.X * MarioPhysicsConstants.velocityDecay, mario.PlayerVelocity.Y);
            mario.PlayerVelocity *= MarioPhysicsConstants.velocityDecay;

            if (mario.PlayerVelocity.Y > MarioPhysicsConstants.fallRange)
            {
                Debug.WriteLine("Entered if");
                mario.PhysicsState = new Falling(mario);
                mario.Fall();

            }
            
            
        }
    }
}
