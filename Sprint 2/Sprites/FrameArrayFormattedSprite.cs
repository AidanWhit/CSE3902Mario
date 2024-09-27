using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;


namespace Sprint_2.Sprites
{
    public class FrameArrayFormattedSprite : ISprite
    {
        private Texture2D texture;
        private float animationSpeed;
        private float initialAnimationSpeed;

        private Rectangle[] frames;
        private int currentFrame = 0;

        private Vector2 size;


        public FrameArrayFormattedSprite(Texture2D texture, Rectangle[] frames, Vector2 size)
        {
            this.texture = texture;
            this.frames = frames;
            this.size = size;

            /* TODO : move the magic number to one of the constant files */
            animationSpeed = 0.1f;
            initialAnimationSpeed = animationSpeed;
        }

        public void Update(GameTime gameTime)
        {
            float timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            animationSpeed -= timer;

            if (animationSpeed <= 0)
            {
                currentFrame++;
                currentFrame %= frames.Length;

                animationSpeed = initialAnimationSpeed;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
            spriteBatch.Draw(texture, destinationRectangle, frames[currentFrame], color);
        }
    }
}
