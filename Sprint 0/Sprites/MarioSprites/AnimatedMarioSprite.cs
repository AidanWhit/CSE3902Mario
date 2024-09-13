using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;


namespace Sprint_0.Sprites.MarioSprites
{
    public class AnimatedMarioSprite : ISprite
    {
        private Texture2D texture;
        private Rectangle[] frames;
        private Vector2 size;
        private float animationSpeed;
        private float initialAnimationSpeed;

        private int currentFrame = 0;

        public AnimatedMarioSprite(Texture2D texture, Rectangle[] frames, Vector2 size, float animationSpeed)
        {
            this.texture = texture;
            this.frames = frames;
            this.size = size;
            this.animationSpeed = animationSpeed;
            initialAnimationSpeed = animationSpeed; ;
        }

        public void Update(GameTime gameTime)
        {
            float timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            animationSpeed -= timer;
            if (animationSpeed < 0)
            {
                animationSpeed = initialAnimationSpeed;

                currentFrame++;
                currentFrame %= frames.Length;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destRect = new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
            spriteBatch.Draw(texture, destRect, frames[currentFrame], Color.White);
        }
        
    }
}
