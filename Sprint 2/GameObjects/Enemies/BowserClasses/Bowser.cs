using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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

        private int health = 1;
        private bool isJumping = false;

        private Interfaces.IUpdateable bowserBehavior;
        private Random rand;
        private Timer attackTimer;
        private bool startBehavior = false;
        private SpriteEffects spriteEffect = SpriteEffects.None;
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

            bowserBehavior = new BowserPatrolBehavior(this);

            rand = new Random();
            attackTimer = new Timer(1000);
            attackTimer.Enabled = true;
            attackTimer.Elapsed += (source, e) => OnTimedEvent(source, e);
            attackTimer.AutoReset = true;
        }
        private void OnTimedEvent(Object source, EventArgs e)
        {
            int randInt = rand.Next(7);
            //Debug.WriteLine("RandomInt: " + randInt);
            if (randInt == 0)
            {
                bowserBehavior = new BowserJumpBehavior(this);
            }
            else if (randInt == 1)
            {
                bowserBehavior = new BowserStandingFireball(this, facingLeft, mario);
            }
            else if (randInt == 2)
            {
                bowserBehavior = new BowserJumpingFireball(this, facingLeft, mario);
            }
            else if (randInt == 3)
            {
                bowserBehavior = new BowserHammerAttack(this, facingLeft);
            }
            else
            {
                bowserBehavior = new BowserPatrolBehavior(this);
            }
        }
        public void Update(GameTime gameTime)
        {
            startBehavior = UpdateStartBehavior();
            if (startBehavior)
            {
                bowserBehavior.Update(gameTime);
                ChangeDirection();

                sprite.Update(gameTime);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color, 0f, Vector2.Zero, spriteEffect);
        }
        public void TakeFireballDamage()
        {
            /* Subtract health by 1 */
            health--;
            if (health == 0)
            {
                attackTimer.Dispose();
                bowserBehavior = new BowserFlippedBehavior(this);
                spriteEffect = SpriteEffects.FlipVertically;

                HUD.Instance.AddScorePopUp(5000, new Vector2(XPos, YPos));
            }
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
        public void SetSprite(ISprite newSprite)
        {
            sprite = newSprite;
        }
        public ISprite GetSprite()
        {
            return sprite;
        }
        public (float, float) GetMaxPatrolBounds()
        {
            return (leftMostXPos, rightMostXPos);
        }
        private bool UpdateStartBehavior()
        {
            float distToPlayer = Math.Abs(Game1.Instance.mario.XPos - XPos);
            if (distToPlayer < EnemyConstants.distUntilBehaviorStarts)
            {
                startBehavior = true;
            }
            return startBehavior;
        }
    }
}
