﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.GameObjects;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.MarioStates;
using Sprint_2.Sound;
using System.Collections.Generic;
using System.Diagnostics;
using Sprint_2.Constants;
using System;
using Sprint_2.LevelManager;
using Sprint_2.Commands.ProgramCommands;
using System.Threading;


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

        private int numberOfFireballsRemaining = MarioPhysicsConstants.maxNumOfFireballs;
        public List<IProjectile> fireballs { get; set; } = new List<IProjectile>();

        public int RemainingLives { get; set; }

        private int[] score = new int[] { 100, 200, 400, 500, 800, 1000, 2000, 4000, 5000, 8000 };
        private int scoreIndex = 0;
        public Player(Vector2 StartingLocation, int lives)
        {
            XPos = (int)StartingLocation.X;
            YPos = (int)StartingLocation.Y;

            PlayerState = new PlayerStateMachine(this);

            PhysicsState = new Grounded(this);
            RemainingLives = lives;
        }
        public void Update(GameTime gameTime)
        {
            /* Quick and easy way to reset player after falling out of bounds. Will be changed next sprint to be more robust */
            if (YPos > EnemyConstants.despawnHeight)
            {
                SoundManager.Instance.StopBackgroundMusic();
                //SoundManager.Instance.PlayBackgroundMusic("youAreDead");
                SoundManager.Instance.PlaySoundEffect("marioDie");


                ICommands reset = new ResetCommand();
                reset.Execute();

            }

            UpdateFireballs(gameTime);
            PlayerState.Update(gameTime);
            PhysicsState.Update(gameTime);

            //Debug.WriteLine("isJumping: " + isJumping);
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

                    SoundManager.Instance.PlaySoundEffect("fireball");

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
                SoundManager.Instance.PlaySoundEffect("jumpSmall");
            } 
            
        }
        public void Fall()
        {
            isFalling = true;
            isJumping = false;
            PhysicsState = new Falling(this);
            PlayerState.Fall();
        }
        public void Idle()
        {
            PlayerState.Idle();
            isCrouching = false;
            isJumping = false;
            isFalling = false;
            scoreIndex = 0; 
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
                //SoundManager.Instance.StopBackgroundMusic();
                //SoundManager.Instance.PlaySoundEffect("marioDie");
            }
        }
        public void PowerUp()
        {
            PlayerState.PowerUp();
            SoundManager.Instance.PlaySoundEffect("powerUp");
        }
        public void Climb()
        {
            PlayerState.Climb();
            SoundManager.Instance.StopBackgroundMusic();
            SoundManager.Instance.PlaySoundEffect("flagpole");
            SoundManager.Instance.PlaySoundEffect("stageClear");
            
        }

        public void Die()
        {
            PlayerState.Die();
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

        public int GetScore()
        {
            return score[scoreIndex++];
        }
    }
}
