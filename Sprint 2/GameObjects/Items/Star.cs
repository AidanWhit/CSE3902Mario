using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Factories;
using Sprint_2.LevelLoader;
using Sprint_2.Constants;
using System.Diagnostics;
using System.Linq.Expressions;


namespace Sprint_2.GameObjects.ItemSprites
{
    public class Star : IItem
    {
        public bool OnSpawn { get; set; }

        public float XPos { get; set; }
        public float YPos { get; set; }
        public Vector2 Velocity { get; set; }
        private ISprite sprite;

        private float XSpeed = 2f;
        private IBlock block;
        public Star(Vector2 initialPosition, IBlock sourceBlock)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            Velocity = new Vector2(1, 0); // Moving right by default

            sprite = ItemFactory.Instance.CreateStar();
            OnSpawn = true;
            block = sourceBlock;
        }

        public void Update(GameTime gameTime)
        {
            if (OnSpawn)
            {
                YPos--;
                if (GetHitBox().Bottom < block.GetHitBox().Top)
                {
                    OnSpawn = false;
                }
            }
            else
            {
                if (Velocity.Y < ItemPhysicsConstants.maxFallVelocity)
                {
                    Velocity += ItemPhysicsConstants.fallVelocity;
                }

                YPos += (float)(Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);
                Velocity *= MarioPhysicsConstants.velocityDecay;

                XPos += XSpeed;
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

        public void ChangeDirection() 
        {
            XSpeed *= -1;
        }
    }
}
