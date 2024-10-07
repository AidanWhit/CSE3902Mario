using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.GameObjects.BlockStates;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;

namespace Sprint_2.GameObjects
{
    public class Block : IBlock
    {
        public Vector2 Position { get; set; }
        public bool containsItem { get; set; }
        public bool breakable { get; set; }

        private IBlockState blockState;


        /* TODO : Add a blockstate that holds the sprite for the current block, the state will dictate how the block will interact with mario.
         e.g. what block is created when it is hit, if it has an item, etc. */

        /* Needs to take in something representing a blockState without it being the actual block state. */
        public Block(string name, Vector2 position)
        {
            Position = position;
            blockState = GetBlockState(name);
            BlockFactory.Instance.AddBlockToBlocksList(this);
        }


        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            blockState.Draw(spriteBatch, Position, color);
        }

        public void Update(GameTime gameTime)
        {
            blockState.Update(gameTime);
        }

        public void ChangeState(IBlockState newBlockState)
        {
            blockState = newBlockState;
        }

        /* TODO: Implement actual hitbox */
        public Rectangle GetHitBox()
        {
            return blockState.GetHitBox(Position);
        }

        public void BeHit(IPlayer player)
        {
            blockState.BeHit(player);
        }

        private IBlockState GetBlockState(string name)
        {
            Dictionary<string, IBlockState> blockStates = new Dictionary<string, IBlockState>()
            {
                {"BrownBrick", new BrownBrickState(this) },
                {"BrownBrickWithCoins", new BrownBrickWithCoins(this, 2) },
                {"ItemWithCoin", new ItemBlockWithCoin(this) },
                {"ItemWithPowerUp", new ItemBlockWithPowerUp(this) }
            };


            blockStates.TryGetValue(name, out IBlockState blockState);

            return blockState;
        }
    }
}
