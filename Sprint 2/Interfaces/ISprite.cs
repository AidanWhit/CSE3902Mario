using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint_2.Interfaces
{
    public interface ISprite
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch, Vector2 vector2, Color color);

        public Rectangle GetHitBox(Vector2 location);

    }
}
