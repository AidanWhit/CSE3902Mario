using Microsoft.Xna.Framework;
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
        public enum Facing { Left, Right };
        private Facing facing;

        private IPlayer mario;
        private string key;
        private ISprite oldSprite;

        private float damagedTime = MarioPhysicsConstants.damagedTime;
        private float flashSpeed = MarioPhysicsConstants.flashSpeed;
        private int opacity = 1;
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
            UpdateFlashingTime(gameTime);
            currentSprite.Update(gameTime);
            
        }

        private void UpdateFlashingTime(GameTime gameTime)
        {
            if (mario.IsDamaged)
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
                    mario.IsDamaged = false;
                }

            }
        }
        public void PowerUp()
        {
            health.PowerUp();
        }
        public void Damage()
        {
            if (!health.GetHealth().Equals("Dead"))
            {
                if (pose.GetPose().Equals("Shoot"))
                {
                    Idle();
                }
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
        public void Climb()
        {
            pose.Climb();
        }

        public FireBall ShootFireball()
        {
            FireBall fireball = null;
            if (health.GetHealth().Equals("FireMario") && !pose.GetPose().Equals("Crouch"))
            {

                if (facing.Equals(Facing.Left))
                {
                    fireball = new FireBall(mario, new Vector2(-FireBallConstants.XSpeed, FireBallConstants.fallSpeed.Y));

                }
                else
                {
                    fireball = new FireBall(mario, new Vector2(FireBallConstants.XSpeed, FireBallConstants.fallSpeed.Y));
                }
                pose.Shoot();
            }
            return fireball;
        }
        public void Draw(SpriteBatch spritebatch, Color color)
        {
            if (key.Contains("Shoot"))
            {
                
                currentSprite.Draw(spritebatch, new Vector2(mario.XPos, mario.YPos), color * opacity);
                currentSprite = oldSprite;
            }
            else
            {
                currentSprite.Draw(spritebatch, new Vector2(mario.XPos, mario.YPos), color * opacity);
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

        public Facing GetFacing()
        {
            return facing;
        }
    }
}
