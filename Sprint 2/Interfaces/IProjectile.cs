using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint_2.Interfaces
{
    public interface IProjectile
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Speed { get; set; }

        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);

    }
}
