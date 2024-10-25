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
using Sprint_2.LevelManager;
using Sprint_2.Commands.ProgramCommands;


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

        /* Need to find a better way to disable input from the keyboard during the sliding down the flag animation besides adding
         an additional if clause inside of pretty much every movement function 
        
         Could possibly disable user input through the use of game states. Like on transition/win state the keyboard controller is updated
        and while in the win state the keyboard controller is not updated. */
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
            /* Quick and easy way to reset player after falling out of bounds. Will be changed next sprint to be more robust */
            if (YPos > EnemyConstants.despawnHeight)
            {
                ICommands reset = new ResetCommand();
                reset.Execute();
            }
            UpdateFireballs(gameTime);
            PlayerState.Update(gameTime);
            PhysicsState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            for (int i = 0; i < fireballs.Count; i++)
            {
                fireballs[i].Draw(spriteBatch, Color.White);
            }
            PlayerState.Draw(spriteBatch, color);
        }

        public void UpdateFireballs(GameTime gameTime)
        {
            for (int i = 0; i < fireballs.Count; i++)
            {
                if (fireballs[i].isExploded())
                {
                    GameObjectManager.Instance.Movers.Remove(fireballs[i]);
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
                    GameObjectManager.Instance.Movers.Add(fireball);
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
            PlayerState.Idle();
            isCrouching = false;
            isJumping = false;
            isFalling = false;
            
        }

        public void Crouch()
        {
            PlayerState.Crouch();
        }

        public void OnCrouch()
        {
            if (!isCrouching && !isJumping && !isFalling)
            {
                isCrouching = true;
            }
        }

        public void ReleaseCrouch()
        {
            if (isCrouching)
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
        public void Climb()
        {
            PlayerState.Climb();
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

        public PlayerStateMachine.Facing GetFacing()
        {
            return PlayerState.GetFacing();
        }
    }
}
