using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint_0.Sprites.MarioSprites
{
    public class StaticMarioSprite : ISprite
    {
        private Texture2D texture;
        private Rectangle[] frames;
        private Vector2 size;

        public StaticMarioSprite(Texture2D texture, Rectangle[] frames, Vector2 size)
        {
            this.texture = texture;
            this.frames = frames;
            this.size = size;
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destRect = new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
            spriteBatch.Draw(texture, destRect, frames[0], Color.White);
        }
    }
}
