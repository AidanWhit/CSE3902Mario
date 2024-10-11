using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.GameObjects.Enemies.EnemyStates;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;

namespace Sprint_2.GameObjects.Enemies.EnemySprites
{
    public class Shell : IEnemy
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public bool Flipped { get; set; }
        public bool Kicked { get; set; }
        public Vector2 Velocity { get; set; }
        private ISprite sprite;

        private float timeUntilShellBecomesKoopa = 5f;

        public Shell(Vector2 initialPosition)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;

            sprite = EnemyFactory.Instance.CreateKoopaShell();
            Velocity = Vector2.Zero;
        }


        public void Update(GameTime gameTime)
        {
            if (Flipped)
            {
                if (YPos > EnemyConstants.despawnHeight)
                {
                    EnemyFactory.Instance.RemoveEnemyFromObjectList(this);
                }
            }
            else
            {
                //timeUntilShellBecomesKoopa -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timeUntilShellBecomesKoopa < 0)
                {
                    EnemyFactory.Instance.AddKoopa(new Vector2(XPos, YPos - GetHitBox().Height));
                    EnemyFactory.Instance.RemoveEnemyFromObjectList(this);
                }

               
            }
            if (Velocity.Y < EnemyConstants.maxFallVelocity)
            {
                Velocity += EnemyConstants.fallVelocity;
            }

            Velocity = new Vector2(Velocity.X, Velocity.Y * MarioPhysicsConstants.velocityDecay);

            XPos += (float)(Velocity.X * gameTime.ElapsedGameTime.TotalSeconds);
            YPos += (float)(Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);

            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
            HitBoxRectangle.DrawRectangle(spriteBatch, GetHitBox(), color, 1);
        }

        /* TODO: Implement actual hitbox */
        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public void TakeFireballDamage()
        {
            sprite = EnemyFactory.Instance.CreateFlippedKoopaShell();
            Flipped = true;
            Velocity = EnemyConstants.flippedVelocity;
        }

        public void TakeStompDamage()
        {

        }

        public void ChangeDirection()
        {
            Velocity = new Vector2(Velocity.X * -1, Velocity.Y);
        }
    }
}
