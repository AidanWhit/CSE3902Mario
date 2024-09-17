using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Sprint_0.Interfaces;
using Sprint_0.Sprites; 

namespace Sprint_0.Sprites.EnemySprites
{
    public class Goomba : IEnemy
    {
        private Texture2D walkingTexture1;
        private Texture2D walkingTexture2;
        private Texture2D dyingTexture;
        private Vector2 position;
        private Vector2 velocity; 
        private int currentFrame;
        private int totalFrames;
        private bool isDead;

        public Goomba(Texture2D walking1, Texture2D walking2, Texture2D dying, Vector2 initialPosition)
        {
            this.walkingTexture1 = walking1;
            this.walkingTexture2 = walking2;
            this.dyingTexture = dying;
            this.position = initialPosition;
            this.velocity = new Vector2(-1, 0); // Starts moving left
            this.currentFrame = 0;
            this.totalFrames = 2; // Goomba has 2 walking frames
            this.isDead = false;
        }


        public void Update(GameTime gameTime)
        {
            if (!isDead)
            {

                position += velocity;

                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;

                // Sprint0: Reverse direction if Goomba hits the screen edges
                if (position.X <= 0 || position.X >= 800 - walkingTexture1.Width)
                {
                    velocity.X *= -1; // Reverse direction
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            // Select the texture to draw based on currentFrame and isDead
            Texture2D currentTexture = isDead ? dyingTexture : (currentFrame == 0 ? walkingTexture1 : walkingTexture2);
            spriteBatch.Draw(currentTexture, position, Color.White);
        }

        
        public void TakeDamage()
        {
            //isDead = true; 
        }
    }
}

