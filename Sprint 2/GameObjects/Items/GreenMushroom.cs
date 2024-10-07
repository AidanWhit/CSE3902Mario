using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Factories;
using SprintZero.LevelLoader;

namespace Sprint_2.GameObjects.ItemSprites
{
    public class GreenMushroom : IItem
    {
        public bool OnSpawn { get; set; }
        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Velocity { get; set; }

        private ISprite sprite;


        public GreenMushroom(Vector2 initialPosition)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            Velocity = new Vector2(-1, 0); // Starts moving left

            sprite = ItemFactory.Instance.CreateGreenMushroom();
        }


        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), Color.White);
        }

        public void DeleteItem(GameObjectManager gameObjectManager) { }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public void ChangeDirection() { }

    }
}

