using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Collision;
using Sprint_2.Commands.MarioMovementCommands;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemySprites;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class LavabubbleStateMachine
    {
        private LavaBubble lavaBubble;
        private ISprite sprite;

        private bool movingUp = true;
        private bool startBehavior = false;

        public LavabubbleStateMachine(LavaBubble lavaBubble)
        {
            this.lavaBubble = lavaBubble;

            sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LavaBubbleMovingUp.ToString());
        }

        public void ChangeDirection()
        {

            movingUp = !movingUp;
            if (movingUp)
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LavaBubbleMovingUp.ToString());
            }
            else
            {
                sprite = UniversalSpriteFactory.Instance.CreateEnemy(NamesOfSprites.SpriteNames.LavaBubbleMovingDown.ToString());
            }
        }

        public void Update(GameTime gameTime)
        {
            startBehavior = UpdateStartBehavior();
            if (startBehavior)
            {
                /* Move Position*/
                lavaBubble.YPos += (float)(lavaBubble.Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
                lavaBubble.Velocity = new Vector2(lavaBubble.Velocity.X, lavaBubble.Velocity.Y * MarioPhysicsConstants.velocityDecay);
            }
            sprite.Update(gameTime);
        }
        private bool UpdateStartBehavior()
        {
            float distToPlayer = Math.Abs(Game1.Instance.mario.XPos - lavaBubble.XPos);
            if (distToPlayer < EnemyConstants.distUntilBehaviorStarts)
            {
                startBehavior = true;
            }
            return startBehavior;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, location, color);
        }

        public void Move()
        {
            if (movingUp)
            {
                lavaBubble.Velocity = new Vector2(0, EnemyConstants.moveSpeed);
            }
            else
            {
                lavaBubble.Velocity = new Vector2(0, -EnemyConstants.moveSpeed);
            }
            lavaBubble.YPos += lavaBubble.Velocity.Y;
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            return sprite.GetHitBox(location);
        }
    }
}
