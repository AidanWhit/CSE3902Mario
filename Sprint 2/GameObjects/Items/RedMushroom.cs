using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Factories;
using SprintZero.LevelLoader;
using Sprint_2.Constants;
using System.Diagnostics;
using System.Windows.Markup;

namespace Sprint_2.GameObjects.ItemSprites
{
    public class RedMushroom : IItem
    {
        public Vector2 Position { get => new Vector2(XPos, YPos); set =>  (XPos, YPos) = value; }
        public Vector2 Velocity { get; set; }

        private float XPos;
        private float YPos;

        private ISprite sprite;

        private bool onSpawn;
        private float spawnedYPosition;
        private IBlock sourceBlock;

        public RedMushroom(Vector2 initialPosition, IBlock block)
        {
            Position = initialPosition;
            Velocity = new Vector2(1, 0); // Starts moving rigjt

            XPos = Position.X;
            YPos = Position.Y;

            sprite = ItemFactory.Instance.CreateRedMushroom();
            onSpawn = true;
            spawnedYPosition = initialPosition.Y;

            sourceBlock = block;
        }


        public void Update(GameTime gameTime)
        {
            if (onSpawn)
            {
                //Position -= new Vector2(0, 1);
                YPos--;
                if (GetHitBox().Bottom <= sourceBlock.GetHitBox().Top)
                {
                    onSpawn = false;
                }
            }
            else
            {
                /* Apply Gravity */
                if (Velocity.Y < MarioPhysicsConstants.maxFallVelocity)
                {
                    Velocity += new Vector2(0, 1);
                }

                YPos += (float)(Velocity.Y * gameTime.ElapsedGameTime.TotalSeconds);

                Velocity *= MarioPhysicsConstants.velocityDecay;

                if (Position.X <= 0 || Position.X >= 800)
                {
                    Velocity = new Vector2(-Velocity.X, Velocity.Y); // Reverse direction
                }
            }
            
            sprite.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position, Color.White);
        }

        public void DeleteItem(GameObjectManager gameObjectManager) { }

        public Rectangle GetHitBox()
        {
            return sprite.GetHitBox(Position);
        }

    }
}

