using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using Sprint_0.Sprites.MarioStates.LeftFacing.FireMario;
using Sprint_0.Sprites.MarioStates.LeftFacing.Mario;
using Sprint_0.Sprites.MarioStates.RightFacing.FireMario;
using Sprint_0.Sprites.MarioStates.RightFacing.Mario;
using Sprint_2.Constants;
using Sprint_2.GameObjects;
using Sprint_2.Interfaces;
using Sprint_2.MarioPhysicsStates;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


namespace Sprint_0.Sprites
{
    public class Player : IPlayer, ISprite
    {

        public IMarioState State { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Vector2 PlayerVelocity { get; set; }

        public IMarioPhysicsStates PhysicsState { get; set; }

        private bool isCrouching = false;
        public bool isJumping = false;

        private int numberOfFireballsRemaining = 2;
        private List<FireBall> fireBalls = new List<FireBall>();
        
        
        public Player(Vector2 StartingLocation) 
        {
            XPos = (int)StartingLocation.X;
            YPos = (int)StartingLocation.Y;
            State = new RightFireMarioIdleState(this);
            PhysicsState = new Grounded(this);
        }
        public void Update(GameTime gameTime)
        {
            UpdateFireballs(gameTime);
            State.Update(gameTime);
            PhysicsState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            for(int i = 0; i < fireBalls.Count; i++)
            {
                fireBalls[i].Draw(spriteBatch);
            }
            State.Draw(spriteBatch, new Vector2(XPos, YPos));
        }

        public void UpdateFireballs(GameTime gameTime)
        {
            for (int i = 0; i < fireBalls.Count; i++)
            {
                if (fireBalls[i].isExploded())
                {
                    fireBalls.Remove(fireBalls[i]);
                    numberOfFireballsRemaining++;
                }
                else
                {
                    fireBalls[i].Update(gameTime);
                }
            }

        }
        public void ShootFireball()
        {
            string stateName = State.ToString();
            if (stateName.Contains("Fire") && numberOfFireballsRemaining > 0 && !stateName.Contains("Crouching"))
            {
                if (stateName.Contains("Left"))
                {
                    fireBalls.Add(new FireBall(this, -FireBallConstants.moveSpeed));
                }
                else //Shoot FireBall Right
                {
                    fireBalls.Add(new FireBall(this, FireBallConstants.moveSpeed));
                }
                numberOfFireballsRemaining--;
            }
        }
        public void MoveLeft()
        {
            if (!isCrouching)
            {
                if (PlayerVelocity.X >  -MarioPhysicsConstants.maxXVelocity)
                {
                    PlayerVelocity -= MarioPhysicsConstants.marioXVelocity;
                }

            }
        }
            
        public void MoveRight()
        {
            if (!isCrouching)
            {
                if (PlayerVelocity.X < MarioPhysicsConstants.maxXVelocity)
                {
                    PlayerVelocity += MarioPhysicsConstants.marioXVelocity;
                }
            }
        }
        public void Jump()
        {
            isJumping = true;
            if (PlayerVelocity.Y > MarioPhysicsConstants.maxJumpVelocity)
            {
                PlayerVelocity += MarioPhysicsConstants.marioJumpVelocity;
            }
        }
        public void Fall()
        {
            if (PlayerVelocity.Y < MarioPhysicsConstants.maxFallVelocity)
            {
                PlayerVelocity += MarioPhysicsConstants.marioFallVelocity;
            }
        }


        public void Crouch()
        {
            //Player can not crouch when jumping
            if (!isJumping)
            {
                State.Crouch();
            }
            
        }

        public void Damage()
        {
            State.Damage();
        }
        public void PowerUp()
        {
            State.PowerUp();
        }
    }
}
