using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using SprintZero.LevelLoader;

namespace Sprint_2.GameObjects.ItemSprites
{
    public class Flower : IItem
    {

        public Vector2 Position { get; set; }
        private ISprite sprite;


        public Flower(Vector2 initialPosition)
        {
            Position = initialPosition;

            sprite = ItemFactory.Instance.CreateFlower();
        }

        public void Update(GameTime gameTime)
        {
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
