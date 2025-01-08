using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;


namespace Sprint_2.GameObjects
{
    public class Collider : ICollideable, Interfaces.IDrawable
    {
        private Rectangle collider;
        private Vector2 location;
        public Collider(Vector2 location, Vector2 size)
        {
            this.location = location;
            collider = new Rectangle((int)location.X, (int)location.Y, (int)size.X, (int)size.Y);
            
        }
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            HitBoxRectangle.DrawRectangle(spriteBatch, collider, Color.White, 1);
        }
        public string GetCollisionType()
        {
            return typeof(Collider).Name;
        }

        public Rectangle GetHitBox()
        {
            return collider;
        }

        public int GetColumn()
        {
            return (int)location.X / CollisionConstants.blockWidth;
        }
    }
}
