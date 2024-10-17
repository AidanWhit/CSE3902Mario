using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.GameObjects;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.MarioStates;
using System.Collections.Generic;
using System.Diagnostics;
using Sprint_2.Constants;
using System;


namespace Sprint_2.Sprites
{
    public class Player : IPlayer
    {

        private PlayerStateMachine PlayerState;
        public int XPos { get; set; }
        public int YPos { get; set; }

        public bool IsDamaged { get; set; } = false;
        public Vector2 PlayerVelocity { get; set; }

        public IMarioPhysicsStates PhysicsState { get; set; }

        public bool isCrouching { get; set; } = false;
        public bool isJumping { get; set; } = false;
        public bool isFalling { get; set; } = false;

        private int numberOfFireballsRemaining = 2;
        public List<IProjectile> fireballs { get; set; } = new List<IProjectile>();

        public int RemainingLives { get; set; }

        private float opacity = 1f;
        private float flashSpeed = MarioPhysicsConstants.flashSpeed;
        private float damagedTime = MarioPhysicsConstants.damagedTime;
        

        public Player(Vector2 StartingLocation)
        {
            XPos = (int)StartingLocation.X;
            YPos = (int)StartingLocation.Y;

            PlayerState = new PlayerStateMachine(this);

            PhysicsState = new Grounded(this);

            RemainingLives = MarioPhysicsConstants.startingLives;
        }
        public void Update(GameTime gameTime)
        {
            if (IsDamaged)
            {
                damagedTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                flashSpeed -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (flashSpeed < 0)
                {
                    opacity = (opacity + 1) % 2;
                    flashSpeed = MarioPhysicsConstants.flashSpeed;
                }
                if (damagedTime < 0)
                {
                    damagedTime = MarioPhysicsConstants.damagedTime;
                    IsDamaged = false;
                }
               
            }
            UpdateFireballs(gameTime);
            PlayerState.Update(gameTime);
            PhysicsState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            for (int i = 0; i < fireballs.Count; i++)
            {
                fireballs[i].Draw(spriteBatch, color);
            }
            PlayerState.Draw(spriteBatch, color * opacity);
        }

        public void UpdateFireballs(GameTime gameTime)
        {
            for (int i = 0; i < fireballs.Count; i++)
            {
                if (fireballs[i].isExploded())
                {
                    fireballs.Remove(fireballs[i]);
                    numberOfFireballsRemaining++;
                }
                else
                {
                    fireballs[i].Update(gameTime);
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
                    fireballs.Add(fireball);
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
            
            if (!isJumping && !isFalling)
            {
                PlayerState.Jump();
                isJumping = true;
            } 
            
        }
        public void Fall()
        {
            PlayerState.Fall();
            isFalling = true;
            PhysicsState = new Falling(this);
        }
        public void Idle()
        {
            isCrouching = false;
            isJumping = false;
            isFalling = false;
            PlayerState.Idle();
        }

        public void Crouch()
        {
            PlayerState.Crouch();
        }

        public void OnCrouch()
        {
            Vector2 playerSize = PlayerState.getSize();
            if (!isCrouching && !playerSize.Equals(new Vector2(16 *4, 16 *4)) && !isJumping)
            {
                isCrouching = true;
               
            }
        }

        public void ReleaseCrouch()
        {
            Vector2 playerSize = PlayerState.getSize();
            if (isCrouching && !playerSize.Equals(new Vector2(16 * 4, 16 * 4)))
            {
                int bottomOfSprite = GetHitBox().Bottom;
                Idle();
                YPos = bottomOfSprite - GetHitBox().Height;

            }
        }

        public void Damage()
        {
            if (!IsDamaged)
            {
                PlayerState.Damage();
            }
        }
        public void PowerUp()
        {
            PlayerState.PowerUp();
        }
        public Rectangle GetHitBox()
        {
            return PlayerState.GetHitBox(new Vector2(XPos, YPos));
        }

        public string GetHealth()
        {
            return PlayerState.GetHealth();
        }

        public string GetCollisionType()
        {
            return typeof(IPlayer).Name;
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
