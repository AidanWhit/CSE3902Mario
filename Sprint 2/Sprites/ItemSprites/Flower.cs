using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces; 
using Sprint_2.Sprites; 

namespace Sprint_2.Sprites.ItemSprites
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

        public void DeleteItem() { }
    }
}
