using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces; 
using Sprint_2.Sprites; 

namespace Sprint_2.Sprites.EnemySprites
{
    public class Shell : IEnemy
    {
        private Texture2D shellTexture;
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        private bool isFacingLeft;

        //private float shellSpeed = 2f;

        public Shell(Texture2D shellTexture, Vector2 initialPosition)
        {
            this.shellTexture = shellTexture;
            this.Position = initialPosition;
            this.Velocity = new Vector2(-4, 0);
            //this.Velocity = new Vector2(-shellSpeed, 0); 
            this.isFacingLeft = true; 
        }


        public void Update(GameTime gameTime)
        {
 
            Position += Velocity;

 
            if (Position.X <= 0 || Position.X >= 800 - shellTexture.Width)
            {
                ReverseDirection();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {

            spriteBatch.Draw(shellTexture, Position, color);
        }

        public void TakeDamage()
        {

        }


        private void ReverseDirection()
        {
            isFacingLeft = !isFacingLeft;
            Velocity = new Vector2(-Velocity.X, Velocity.Y); // Reverse velocity to change direction
        }

        /* TODO: Implement actual hitbox */
        public Rectangle GetHitBox(Vector2 location)
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}
