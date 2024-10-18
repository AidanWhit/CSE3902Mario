using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Microsoft.Xna.Framework.Input;
using Sprint_2.Factories;
using Sprint_2.LevelManager;
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

        private float XSpeed = 1f;
        private IBlock block;

        private int topOfSourceBlock;
        public Star(Vector2 initialPosition, int topOfSourceBlock)
        {
            XPos = initialPosition.X;
            YPos = initialPosition.Y;
            Velocity = Vector2.Zero; 

            sprite = ItemFactory.Instance.CreateStar();
            OnSpawn = true;
            this.topOfSourceBlock = topOfSourceBlock;
        }

        public void Update(GameTime gameTime)
        {
            if (OnSpawn)
            {
                YPos--;
                if (GetHitBox().Bottom < topOfSourceBlock)
                {
                    OnSpawn = false;
                    GameObjectManager.Instance.Movers.Add(this);
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

        public void ChangeDirection() 
        {
            XSpeed *= -1;
        }
        public string GetCollisionType()
        {
            return typeof(Star).Name;
        }

        public int GetColumn()
        {
            if (OnSpawn)
            {
                return -1;
            }
            return (int)(XPos / CollisionConstants.blockWidth);
        }
    }
}
