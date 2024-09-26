using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites; 

namespace Sprint_2.Sprites.EnemySprites
{
    public class Goomba : IEnemy
    {
        private Texture2D walkingTexture1;
        private Texture2D walkingTexture2;
        private Texture2D dyingTexture;
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        private int currentFrame;
        private int totalFrames;
        private bool isDead;

        public Goomba(Texture2D walking1, Texture2D walking2, Texture2D dying, Vector2 initialPosition)
        {
            this.walkingTexture1 = walking1;
            this.walkingTexture2 = walking2;
            this.dyingTexture = dying;
            this.Position = initialPosition;
            this.Velocity = new Vector2(-2, 0); // Starts moving left
            this.currentFrame = 0;
            this.totalFrames = 2; // Goomba has 2 walking frames
            this.isDead = false;
        }


        public void Update(GameTime gameTime)
        {
            if (!isDead)
            {

                Position += Velocity;

                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;

                // Sprint0: Reverse direction if Goomba hits the screen edges
                if (Position.X <= 0 || Position.X >= 800 - walkingTexture1.Width)
                {
                    Velocity = new Vector2(-Velocity.X, Velocity.Y); // Reverse direction
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            // Draw based on currentFrame and isDead
            Texture2D currentTexture = isDead ? dyingTexture : (currentFrame == 0 ? walkingTexture1 : walkingTexture2);
            spriteBatch.Draw(currentTexture, Position, color);
        }

        
        public void TakeDamage()
        {
            //isDead = true; 
        }
    }
}

