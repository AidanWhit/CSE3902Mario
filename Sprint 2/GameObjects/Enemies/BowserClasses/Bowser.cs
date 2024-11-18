using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Timers;

namespace Sprint_2.GameObjects.Enemies.BowserClasses
{
    public class Bowser : IEnemy
    {
        private ISprite sprite;
        private IPlayer mario;
        private bool facingLeft = true;
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Velocity { get; set; }
        public bool Flipped { get; set; }

        private float leftMostXPos;
        private float rightMostXPos;
        private const int patrolRange = 32;
        private bool movingLeft = true;


        private bool isJumping = false;
        public Bowser(Vector2 location)
        {
            XPos = location.X;
            YPos = location.Y;
            leftMostXPos = XPos - patrolRange;
            rightMostXPos = XPos + patrolRange;

            Velocity = new Vector2(-20f, 0f);
            mario = Game1.Instance.mario;
            //Assume bowser starts facing left
            sprite = UniversalSpriteFactory.Instance.CreateEnemy("LeftBowser");

            Timer timer = new Timer(5000);
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += (source, e) => OnTimerEvent(source, e);
        }
        private void OnTimerEvent(Object source, ElapsedEventArgs e)
        {
            CreateFireball();
        }
        public void Update(GameTime gameTime)
        {
            ChangeDirection();
            Patrol();
            JumpBehavior();

            XPos += (float)(Velocity.X * gameTime.ElapsedGameTime.TotalSeconds);
            if (Velocity.Y < EnemyConstants.maxFallVelocity)
            {
                Velocity += EnemyConstants.fallVelocity;
            }
            YPos += (float)(Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }
        private void Patrol()
        {
            //if(XPos > leftMostXPos && movingLeft)
            //{
            //    //XPos -= Velocity.X;
            //}
            //else if (XPos < rightMostXPos && !movingLeft)
            //{
            //    //XPos += Velocity.X;
            //}
            UpdateMovingLeft();
        }
        private void UpdateMovingLeft()
        {
            if (XPos <= leftMostXPos)
            {
                XPos = leftMostXPos;
                movingLeft = false;
                Velocity *= new Vector2(-1, 1);
            }
            else if (XPos >= rightMostXPos)
            {
                XPos = rightMostXPos;
                movingLeft = true;
                Velocity *= new Vector2(-1, 1);
            }
        }
        private void CreateFireball()
        {
            BowserFireball fireball = new BowserFireball(new Vector2(XPos, YPos), mario.GetHitBox().Bottom, facingLeft);

            GameObjectManager.Instance.Updateables.Add(fireball);
            GameObjectManager.Instance.ForeDrawables.Add(fireball);
            GameObjectManager.Instance.Movers.Add(fireball);
        }
        private void JumpBehavior()
        {
            if (!isJumping)
            {
                Velocity = new Vector2(Velocity.X, ItemPhysicsConstants.bounceVelocity);
                isJumping = true;
            }
        }
        public void TakeFireballDamage()
        {
            /* Subtract health by 1 */
        }

        public void TakeStompDamage()
        {
            //Bowser can not take stomp damage
        }

        public void ChangeDirection()
        {
            /* Always needs to look at mario */
            if (mario.XPos > XPos && facingLeft)
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy("RightBowser");
                facingLeft = !facingLeft;
            }
            else if (XPos > mario.XPos && !facingLeft)
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy("LeftBowser");
                facingLeft = !facingLeft;
            }
        }

        public string GetCollisionType()
        {
            return nameof(Bowser);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }
        public int GetColumn()
        {
            return (int)XPos / CollisionConstants.blockWidth;
        }

        public void SetIsJumping(bool jumping)
        {
            isJumping = jumping;
        }

    }
}
