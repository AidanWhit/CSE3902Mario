using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using Sprint_0.Sprites;
using Sprint_2.Constants;
using Sprint_2.GameObjects;
using Sprint_2.Interfaces;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.MarioStates;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


namespace Sprint_2.Sprites
{
    public class Player : IPlayer, ISprite
    {

        public PlayerStateMachine playerState { get; set; }
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
            playerState = new PlayerStateMachine(this);
            PhysicsState = new Grounded(this);
        }
        public void Update(GameTime gameTime)
        {
            UpdateFireballs(gameTime);
            playerState.Update(gameTime);
            PhysicsState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            for (int i = 0; i < fireBalls.Count; i++)
            {
                fireBalls[i].Draw(spriteBatch);
            }
            playerState.Draw(spriteBatch);
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
            if (numberOfFireballsRemaining > 0)
            {
                FireBall fireball = playerState.ShootFireball();
                if (fireball != null)
                {
                    fireBalls.Add(fireball);
                    numberOfFireballsRemaining--;
                }

            }
        }
        public void MoveLeft()
        {
            playerState.MoveLeft();
        }

        public void MoveRight()
        {
            playerState.MoveRight();
        }
        public void Jump()
        {
            if (!isJumping)
            {
                playerState.Jump();
            }
            isJumping = true;
        }
        public void Fall()
        {
            if (PlayerVelocity.Y < MarioPhysicsConstants.maxFallVelocity)
            {
                PlayerVelocity += MarioPhysicsConstants.marioFallVelocity;
            }
        }
        public void Idle()
        {
            playerState.Idle();
        }

        public void Crouch()
        {
            playerState.Crouch();

        }

        public void Damage()
        {
            playerState.Damage();
        }
        public void PowerUp()
        {
            playerState.PowerUp();
        }
    }
}
