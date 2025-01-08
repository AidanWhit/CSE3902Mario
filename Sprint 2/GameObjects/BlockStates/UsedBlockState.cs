using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Factories;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects.BlockStates
{
    public class UsedBlockState : BlockState
    {
        private ISprite sprite;
        private IBlock block;
        public UsedBlockState(IBlock block) : base(block)
        {
           
            this.block = block;
            base.sprite = BlockFactory.Instance.GetBlock("Hit");
            Debug.WriteLine("Original BLock Height: " + block.Position.Y);

            Hit = true;
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //base.sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, location, color);
        }

        public override void BeHit(IPlayer player)
        {
            Debug.WriteLine("Block Pos: " + block.Position);
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            return sprite.GetHitBox(location);
        }
    }
}
