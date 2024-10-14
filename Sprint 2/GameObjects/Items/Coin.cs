using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelLoader;
using System.ComponentModel;

namespace Sprint_2.GameObjects.ItemSprites
{
    public class Coin : IItem
    {
        public Vector2 Velocity { get; set; }
        public bool OnSpawn { get; set; } = true;
        private ISprite sprite;
        public float XPos { get; set; }
        public float YPos { get; set; }


        private int heightIncrease = -2;
        private bool moveDown = false;

        private float originalHeight;

        private GameObjectManager gameObjectManager;
        public Coin(Vector2 location, GameObjectManager gameObjectManager)
        {
            sprite = ItemFactory.Instance.CreateCoin();
            XPos = location.X;
            YPos = location.Y;
            originalHeight = YPos;

            this.gameObjectManager = gameObjectManager;
        }

        public void Update(GameTime gameTime)
        {
            //Position = new Vector2(Position.X, Position.Y + heightIncrease);
            YPos += heightIncrease;
            if (YPos < originalHeight - 80)
            {
                heightIncrease *= -1;
            } 
            else if (YPos > originalHeight)
            {
                DeleteItem(gameObjectManager);
            }
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), Color.White);
        }
        public void DeleteItem(GameObjectManager gameObjectManager) 
        {
            gameObjectManager.RemoveItem(this);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public void ChangeDirection() { }
    }
}
