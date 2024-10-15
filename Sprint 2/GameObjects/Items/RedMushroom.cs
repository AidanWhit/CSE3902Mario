using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Factories;
using Sprint_2.LevelManager;
using Sprint_2.Constants;
using System.Diagnostics;
using System.Windows.Markup;

namespace Sprint_2.GameObjects.ItemSprites
{
    public class RedMushroom : IItem
    {
        public Vector2 Velocity { get; set; }

        public float XPos { get; set; }
        public float YPos { get; set; }

        private ISprite sprite;

        public bool OnSpawn { get; set; }
        private float spawnedYPosition;
        private IBlock sourceBlock;

        private float speed = 1f;

        public RedMushroom(Vector2 initialPosition, IBlock block)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            Velocity = new Vector2(1, 0); // Starts moving rigjt

            sprite = ItemFactory.Instance.CreateRedMushroom();
            OnSpawn = true;
            spawnedYPosition = initialPosition.Y;

            sourceBlock = block;
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
            else
            {
                /* Apply Gravity */
                if (Velocity.Y < ItemPhysicsConstants.maxFallVelocity)
                {
                    Velocity += ItemPhysicsConstants.fallVelocity;
                }

                YPos += (float)(Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
                Velocity *= MarioPhysicsConstants.velocityDecay;
                XPos += speed;
            }
            
            sprite.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, new Vector2(XPos, YPos), Color.White);
        }

        public void DeleteItem(GameObjectManager gameObjectManager) 
        {
            ItemFactory.Instance.RemoveFromItemsList(this);
        }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(new Vector2(XPos, YPos));
        }

        public void ChangeDirection() {
            speed *= -1;
        }
    }
}

