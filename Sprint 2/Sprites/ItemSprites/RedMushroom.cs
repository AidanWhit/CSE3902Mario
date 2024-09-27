using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using Sprint_2.Factories;

namespace Sprint_2.Sprites.ItemSprites
{
    public class RedMushroom : IItem
    { 
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        private ISprite sprite;

        public RedMushroom(Vector2 initialPosition)
        {
            this.Position = initialPosition;
            this.Velocity = new Vector2(-1, 0); // Starts moving left

            sprite = ItemFactory.Instance.CreateRedMushroom();
        }


        public void Update(GameTime gameTime)
        {
                Position += Velocity;

                if (Position.X <= 0 || Position.X >= 800)
                {
                    Velocity = new Vector2(-Velocity.X, Velocity.Y); // Reverse direction
                }
                sprite.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position, Color.White);
        }

        public void DeleteItem() { }

    }
}

