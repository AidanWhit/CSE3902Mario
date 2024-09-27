using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces; 
using Sprint_2.Sprites; 

namespace Sprint_2.Sprites.ItemSprites
{
    public class Coin : IItem
    {
        private ISprite sprite;
        public Vector2 Position { get; set; }

        public Coin(Vector2 location)
        {
            sprite = ItemFactory.Instance.CreateCoin();
            Position = location;
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
