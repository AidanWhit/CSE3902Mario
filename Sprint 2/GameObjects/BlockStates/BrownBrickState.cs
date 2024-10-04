using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System.Diagnostics;


namespace Sprint_2.GameObjects.BlockStates
{
    public class BrownBrickState : IBlockState
    {
        private ISprite sprite;
        private bool destroyed = false;
        private bool bumped = false;
        private bool hit = false;
        private IBlock block;

        private int originalBlockY;
        private float animationSpeed = 0.05f;
        public BrownBrickState(IBlock block)
        {
            this.block = block;
            sprite = BlockFactory.Instance.GetBlock("BrownBrick");
        }

        public void Update(GameTime gameTime)
        {
            float timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!destroyed)
            {
                BumpBlock(gameTime, originalBlockY);
                sprite.Update(gameTime);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            if (!destroyed)
            {
                sprite.Draw(spriteBatch, location, color);
            }
            
        }

        public void BeHit(IPlayer player)
        {
            Debug.WriteLine("Hit block");
            hit = true;
            /* Little mario hit the block */
            if (player.GetHealth().Equals("Mario"))
            {
                /* Make the block move up and then down */
                Debug.WriteLine("Little mario hit the block");
                bumped = true;
                originalBlockY = (int)block.Position.Y;

            }
            /* SuperMario/Fire Mario hit the block*/
            else
            {
                /* Call remove object on gameobject manager to remove the block from being able to be drawn/updated */
                destroyed = true;

            }
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            return sprite.GetHitBox(location);
        }

        public void BumpBlock(GameTime gameTime, int originalBlockY)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (bumped && hit)
            {
                
                animationSpeed -= elapsedTime;
                if (animationSpeed < 0)
                {
                    block.Position = new Vector2(block.Position.X, block.Position.Y - 2);
                    animationSpeed = 0.05f;
                    if (block.Position.Y < originalBlockY - 5)
                    {
                        bumped = false;
                    }
                }
            } else if (!bumped && hit)
            {
               
                animationSpeed -= elapsedTime;
                if (animationSpeed < 0)
                {
                    block.Position = new Vector2(block.Position.X, block.Position.Y + 2);
                    animationSpeed = 0.05f;
                    if (block.Position.Y == originalBlockY)
                    {
                        hit = false;
                    }
                }
            }
            
        }
    }
}
