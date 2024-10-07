using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Factories;
using SprintZero.LevelLoader;


namespace Sprint_2.GameObjects.ItemSprites
{
    public class Star : IItem
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        private ISprite sprite;
        public Star(Vector2 initialPosition)
        {
            Position = initialPosition;
            Velocity = new Vector2(-2, 0); // Moving left by default

            sprite = ItemFactory.Instance.CreateStar();
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity;

            if (Position.X <= 0 || Position.X >= 800)
            {
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }

            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position, Color.White);
        }

        public void DeleteItem(GameObjectManager gameObjectManager) { }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(Position);
        }

    }
}
