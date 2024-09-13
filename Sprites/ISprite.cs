using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_0.Sprites
{
    public interface ISprite
    {
        public void Update(GameTime gameTime) { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector2);

    }
}
