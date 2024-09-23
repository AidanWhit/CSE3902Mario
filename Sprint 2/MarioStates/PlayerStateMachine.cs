﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Factories;
using Sprint_0.Interfaces;
using Sprint_0.Sprites;
using Sprint_2.Constants;
using Sprint_2.GameObjects;
using Sprint_2.MarioPhysicsStates;
using Sprint_2.Sprites;
using System.Diagnostics;
using System.Drawing;

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

            health = new HealthState();
            pose = new PoseState();
            facing = Facing.Right;
            currentSprite = MarioSpriteFactory.Instance.RightMarioIdleSprite();
            key = "RightMarioIdle";
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
            health.Damage();
        }
        public void Jump()
        {
            pose.Jump();
            mario.PhysicsState = new Jumping(mario);
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
            else if (!pose.GetPose().Equals("Crouch"))
            {

                facing = Facing.Left;
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
            else if (!pose.GetPose().Equals("Crouch"))
            {
                facing = Facing.Right;
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
            PoseState oldPose = new PoseState();
            oldPose.Jump();
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
        public void Draw(SpriteBatch spritebatch)
        {
            if (key.Contains("Shoot"))
            {
                currentSprite.Draw(spritebatch, new Vector2(mario.XPos, mario.YPos));
                currentSprite = oldSprite;
            }
            else
            {
                currentSprite.Draw(spritebatch, new Vector2(mario.XPos, mario.YPos));
            }


        }

        public void ChangeSprite()
        {
            Vector2 size = health.GetSize();
            string newKey = facing.ToString() + health.GetHealth() + pose.GetPose();
            if (newKey.Contains("Dead"))
            {
                currentSprite = MarioSpriteFactory.Instance.DeadMarioSprite();
            }
            else if (!key.Equals(newKey))
            {
                key = newKey;
                currentSprite = MarioSpriteFactory.Instance.GetMarioSprite(key, size);
            }
        }
    }
}
