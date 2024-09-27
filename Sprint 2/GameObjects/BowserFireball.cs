using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;

namespace Sprint_2.Sprites.EnemySprites
{
    public class BowserFireball : IProjectile
    {
        private Texture2D[] fireballSprites;
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Speed { get; set; }

        private int currentFrame;
        private int totalFrames;

        private ISprite sprite;

        public BowserFireball(Texture2D[] sprites, Vector2 initialPosition, Vector2 velocity)
        {
            fireballSprites = sprites;
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            Speed = velocity;
            currentFrame = 0;
            totalFrames = 2;
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
