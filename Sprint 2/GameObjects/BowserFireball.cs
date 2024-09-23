using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Interfaces;
using Sprint_2.Interfaces; 

namespace Sprint_0.Sprites.EnemySprites
{
    public class BowserFireball : IProjectile
    {
        private Texture2D[] fireballSprites;
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Speed { get; set; }

        private int currentFrame;
        private int totalFrames;

        public BowserFireball(Texture2D[] sprites, Vector2 initialPosition, Vector2 velocity)
        {
            this.fireballSprites = sprites;
            this.XPos = initialPosition.X;
            this.YPos = initialPosition.Y;
            this.Speed = velocity;
            this.currentFrame = 0;
            this.totalFrames = 2; 
        }

        public void Update(GameTime gameTime)
        {
            
            XPos += Speed.X;
            YPos += Speed.Y;

            
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fireballSprites[currentFrame], new Vector2(XPos, YPos), Color.White);
        }
    }
}
