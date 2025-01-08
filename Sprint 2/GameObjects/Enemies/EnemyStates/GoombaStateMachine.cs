using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.Sprites.EnemySprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.Enemies.EnemyStates
{
    public class GoombaStateMachine
    {
        private bool facingLeft = true;
        private enum GoombaHealth { Normal, Stomped, Flipped};
        private GoombaHealth health = GoombaHealth.Normal;


        private Goomba goomba;
        private ISprite sprite;

        public GoombaStateMachine(Goomba goomba)
        {
            this.goomba = goomba;

            sprite = EnemyFactory.Instance.CreateGoomba();
        }
        public void ChangeDirection()
        {
            if (health == GoombaHealth.Normal)
            {
                facingLeft = !facingLeft;
            }
        }

        public void BeStomped()
        {
            if (health != GoombaHealth.Stomped)
            {
                health = GoombaHealth.Stomped;
                int bottomPos = goomba.GetHitBox().Bottom;
                sprite = EnemyFactory.Instance.CreateStompedGoomba();
                goomba.YPos = bottomPos;
            }
        }

        public void BeFlipped()
        {
            if (health != GoombaHealth.Flipped)
            {
                health = GoombaHealth.Flipped;
                sprite = EnemyFactory.Instance.CreateFlippedGoomba();
            }
        }

        public void Move()
        {
            if (facingLeft)
            {
                goomba.Velocity = new Vector2(-EnemyConstants.moveSpeed, goomba.Velocity.Y);
            }
            else
            {
                goomba.Velocity = new Vector2(EnemyConstants.moveSpeed, goomba.Velocity.Y);
            }
            goomba.XPos += goomba.Velocity.X;
        }

        public void Update(GameTime gameTime)
        {
            /* Applies Gravity */
            if (goomba.Velocity.Y < EnemyConstants.maxFallVelocity)
            {
                goomba.Velocity += EnemyConstants.fallVelocity;
            }

            goomba.YPos += (float)(goomba.Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
            if (health == GoombaHealth.Normal)
            {
                Move();
            }
            

            goomba.Velocity = new Vector2(goomba.Velocity.X, goomba.Velocity.Y * MarioPhysicsConstants.velocityDecay);
            
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, location, color);
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            return sprite.GetHitBox(location);
        }
    }
}
