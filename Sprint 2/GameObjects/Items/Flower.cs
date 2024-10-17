using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Constants;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using Sprint_2.LevelManager;

namespace Sprint_2.GameObjects.ItemSprites
{
    public class Flower : IItem, ICollideable
    {
        public Vector2 Velocity { get; set; }
        public bool OnSpawn { get; set; }
        public float XPos { get; set; }
        public float YPos { get; set; }
        private ISprite sprite;

        private IBlock sourceBlock;

        public Flower(Vector2 initialPosition, IBlock block)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;

            sourceBlock = block;
            OnSpawn = true;

            sprite = ItemFactory.Instance.CreateFlower();
        }

        public void Update(GameTime gameTime)
        {
            if (OnSpawn)
            {

                YPos--;
                if (GetHitBox().Bottom < sourceBlock.GetHitBox().Top)
                {
                    OnSpawn = false;
                }
            }
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), color);
        }

        public void DeleteItem() 
        {
            GameObjectManager.Instance.Movers.Remove(this);
            GameObjectManager.Instance.Updateables.Remove(this);
            GameObjectManager.Instance.Drawables.Remove(this);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public void ChangeDirection() { }

        public string GetCollisionType()
        {
            return typeof(IItem).Name;
        }

        public int GetColumn()
        {
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
