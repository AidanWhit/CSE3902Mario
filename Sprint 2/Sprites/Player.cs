using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.Constants;
using Sprint_2.GameObjects;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.MarioStates;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


namespace Sprint_2.Sprites
{
    public class Player : IPlayer
    {

        private PlayerStateMachine PlayerState;
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Vector2 PlayerVelocity { get; set; }

        public IMarioPhysicsStates PhysicsState { get; set; }

        public bool isCrouching { get; set; } = false;
        public bool isJumping { get; set; } = false;

        private int numberOfFireballsRemaining = 2;
        private List<FireBall> fireBalls = new List<FireBall>();


        public Player(Vector2 StartingLocation)
        {
            XPos = (int)StartingLocation.X;
            YPos = (int)StartingLocation.Y;
            PlayerState = new PlayerStateMachine(this);
            PhysicsState = new Grounded(this);
        }
        public void Update(GameTime gameTime)
        {
            UpdateFireballs(gameTime);
            PlayerState.Update(gameTime);
            PhysicsState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < fireBalls.Count; i++)
            {
                fireBalls[i].Draw(spriteBatch);
            }
            PlayerState.Draw(spriteBatch);
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
                FireBall fireball = PlayerState.ShootFireball();
                if (fireball != null)
                {
                    fireBalls.Add(fireball);
                    numberOfFireballsRemaining--;
                }

            }
        }
        public void MoveLeft()
        {
            PlayerState.MoveLeft();
        }

        public void MoveRight()
        {
            PlayerState.MoveRight();
        }
        public void Jump()
        {
            if (!isJumping)
            {
                PlayerState.Jump();
                isJumping = true;
            }
            
        }
        public void Fall()
        {
            PlayerState.Fall();
        }
        public void Idle()
        {
            PlayerState.Idle();
        }

        public void Crouch()
        {
            PlayerState.Crouch();
        }

        public void Damage()
        {
            PlayerState.Damage();
        }
        public void PowerUp()
        {
            PlayerState.PowerUp();
        }
    }
}
