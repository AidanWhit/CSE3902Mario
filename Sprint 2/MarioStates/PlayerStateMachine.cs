﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.Constants;
using Sprint_2.GameObjects;
using Sprint_2.MarioPhysicsStates;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Sprint_2.MarioStates
{
    public class PlayerStateMachine
    {
        private HealthState health;
        public ISprite currentSprite { get; set; }
        private PoseState pose;
        private enum Facing { Left, Right };
        private Facing facing;

        private IPlayer mario;
        private string key;
        private ISprite oldSprite;
        public PlayerStateMachine(IPlayer mario)
        {
            this.mario = mario;

            health = new HealthState(mario);
            pose = new PoseState(mario);
            facing = Facing.Right;
            
            key = "RightMarioIdle";
            currentSprite = MarioSpriteFactory.Instance.GetMarioSprite(key);
        }

        public void Update(GameTime gameTime)
        {
            oldSprite = currentSprite;
            ChangeSprite();
            currentSprite.Update(gameTime);
            
        }
        public void PowerUp()
        {
            health.PowerUp();
        }
        public void Damage()
        {
            if (!health.GetHealth().Equals("Dead"))
            {
                health.Damage();
                if (!health.GetHealth().Equals("Dead"))
                {
                    mario.IsDamaged = true;
                }
            }
            
        }
        public void Jump()
        {
            if (!health.GetHealth().Equals("Dead"))
            {
                pose.Jump();
                mario.PhysicsState = new Jumping(mario);
            }
            
        }
        public void Fall()
        {
            pose.Fall();
        }

        public void Crouch()
        {
            if (!health.GetHealth().Equals("Mario"))
            {
                pose.Crouch();
            }

        }

        public void MoveLeft()
        {
            if (pose.GetPose().Equals("Jump") || pose.GetPose().Equals("Fall"))
            {
                if (mario.PlayerVelocity.X > -MarioPhysicsConstants.maxXVelocity)
                {
                    mario.PlayerVelocity -= MarioPhysicsConstants.marioXVelocity;
                }
            }
            else if (!pose.GetPose().Equals("Crouch") && !health.GetHealth().Equals("Dead"))
            {

                facing = Facing.Left;
                //TODO: Remove Magic Number 
                //Number currently acts as velocity in which the slide pose should be shown 
                if (mario.PlayerVelocity.X > 50f)
                {
                    pose.Slide();
                }
                else
                {
                    pose.Run();
                }
                if (mario.PlayerVelocity.X > -MarioPhysicsConstants.maxXVelocity)
                {
                    mario.PlayerVelocity -= MarioPhysicsConstants.marioXVelocity;
                }
            }

        }
        public void MoveRight()
        {
            if (pose.GetPose().Equals("Jump") || pose.GetPose().Equals("Fall"))
            {
                if (mario.PlayerVelocity.X < MarioPhysicsConstants.maxXVelocity)
                {
                    mario.PlayerVelocity += MarioPhysicsConstants.marioXVelocity;
                }
            }
            else if (!pose.GetPose().Equals("Crouch") && !health.GetHealth().Equals("Dead"))
            {
                facing = Facing.Right;
                //TODO: Remove Magic Number 
                //Number currently acts as velocity in which the slide pose should be shown 
                if (mario.PlayerVelocity.X < 50f)
                {
                    pose.Slide();
                }
                else
                {
                    pose.Run();
                }
                if (mario.PlayerVelocity.X < MarioPhysicsConstants.maxXVelocity)
                {
                    mario.PlayerVelocity += MarioPhysicsConstants.marioXVelocity;
                }
            }
        }
        public void Idle()
        {
            pose.Idle();
        }

        public FireBall ShootFireball()
        {
            FireBall fireball = null;
            if (health.GetHealth().Equals("FireMario") && !pose.GetPose().Equals("Crouch"))
            {

                if (facing.Equals(Facing.Left))
                {
                    fireball = new FireBall(mario, -FireBallConstants.moveSpeed);

                }
                else
                {
                    fireball = new FireBall(mario, FireBallConstants.moveSpeed);
                }
                pose.Shoot();
            }
            return fireball;
        }
        public void Draw(SpriteBatch spritebatch, Color color)
        {
            if (key.Contains("Shoot"))
            {
                
                currentSprite.Draw(spritebatch, new Vector2(mario.XPos, mario.YPos), color);
                currentSprite = oldSprite;
            }
            else
            {
                currentSprite.Draw(spritebatch, new Vector2(mario.XPos, mario.YPos), color);
            }


        }

        public void ChangeSprite()
        {
            string newKey = facing.ToString() + health.GetHealth() + pose.GetPose();

            if (newKey.Contains("Dead"))
            {
                key = newKey;
                currentSprite = MarioSpriteFactory.Instance.DeadMarioSprite();
            }
            else if (!key.Equals(newKey))
            {
                key = newKey;
                currentSprite = MarioSpriteFactory.Instance.GetMarioSprite(key);
                
            }
        }

        public Vector2 getSize()
        {
            return health.GetSize();
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            ChangeSprite();
            return currentSprite.GetHitBox(location);
        }

        public string GetHealth()
        {
            return health.GetHealth();
        }
    }
}
