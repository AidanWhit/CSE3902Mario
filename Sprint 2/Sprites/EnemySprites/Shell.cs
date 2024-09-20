using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces; 
using Sprint_0.Sprites; 

namespace Sprint_0.Sprites.EnemySprites
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
            this.Velocity = new Vector2(-3, 0);
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

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            spriteBatch.Draw(shellTexture, Position, Color.White);
        }

        public void TakeDamage()
        {

        }


        private void ReverseDirection()
        {
            isFacingLeft = !isFacingLeft;
            Velocity = new Vector2(-Velocity.X, Velocity.Y); // Reverse velocity to change direction
        }
    }
}
