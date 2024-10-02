using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Factories;

namespace Sprint_2.Sprites.EnemySprites
{
    public class Goomba : IEnemy
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        private bool isDead;

        /* TODO: Need to add a goomba state machine */
        private ISprite goombaSprite;


        public Goomba(Vector2 initialPosition)
        { 
            Position = initialPosition;
            Velocity = new Vector2(-2, 0); // Starts moving left
            this.isDead = false;

            goombaSprite = EnemyFactory.Instance.CreateGoomba();
        }


        public void Update(GameTime gameTime)
        {
            if (!isDead)
            {
                goombaSprite.Update(gameTime);

                Position += Velocity;

                // Sprint0: Reverse direction if Goomba hits the screen edges
                if (Position.X <= 0 || Position.X >= 800)
                {
                    Velocity = new Vector2(-Velocity.X, Velocity.Y); // Reverse direction
                }
            }
            
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            goombaSprite.Draw(spriteBatch, Position, color);
        }

        
        public void TakeDamage()
        {
            isDead = true;
            goombaSprite = EnemyFactory.Instance.CreateDeadGoomba();
        }

        /* TODO: Implement actual hitbox */
        public Rectangle GetHitBox(Vector2 location)
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}

