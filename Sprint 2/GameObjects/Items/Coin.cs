using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using SprintZero.LevelLoader;
using System.ComponentModel;

namespace Sprint_2.GameObjects.ItemSprites
{
    public class Coin : IItem
    {
        private ISprite sprite;
        public Vector2 Position { get; set; }

        private float animationSpeed = 0.1f;
        private float originalAnimationSpeed;

        private int heightIncrease = -2;
        private bool moveDown = false;

        private float originalHeight;

        private GameObjectManager gameObjectManager;
        public Coin(Vector2 location, GameObjectManager gameObjectManager)
        {
            sprite = ItemFactory.Instance.CreateCoin();
            Position = location;
            originalHeight = Position.Y;

            originalAnimationSpeed = animationSpeed;

            this.gameObjectManager = gameObjectManager;
        }

        public void Update(GameTime gameTime)
        {
            Position = new Vector2(Position.X, Position.Y + heightIncrease);
            if (Position.Y < originalHeight - 80)
            {
                heightIncrease *= -1;
            } 
            else if (Position.Y > originalHeight)
            {
                DeleteItem(gameObjectManager);
            }
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position, Color.White);
        }

        public void MoveUpAndDown(GameTime gameTime, int height)
        {

        }
        public void DeleteItem(GameObjectManager gameObjectManager) 
        {
            gameObjectManager.RemoveItem(this);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(Position);
        }
    }
}
