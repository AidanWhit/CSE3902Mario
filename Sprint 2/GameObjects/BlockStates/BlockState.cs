﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Sprint_2.GameObjects.BlockStates
{
    public abstract class BlockState : IBlockState
    {

        public ISprite sprite { get; set; }
        private IBlock block;
        public bool Hit { get; set; }
        private int heightChange = -2;
        private float originalBlockY;

        private int heightChangeIterations;


        protected BlockState(IBlock block)
        {
            Hit = false;
            this.block = block;
            originalBlockY = this.block.Position.Y;
            
        }
        public virtual void Update(GameTime gameTime)
        {

            if (Hit && heightChange < 0)
            {
                
                block.Position = new Vector2(block.Position.X, block.Position.Y + heightChange);
                if (block.Position.Y < originalBlockY - 6)
                {
                   
                    heightChange *= -1;
                }
            }
            else if (heightChange > 0)
            {
                Hit = false;
                block.Position = new Vector2(block.Position.X, block.Position.Y + heightChange);
                if (block.Position.Y > originalBlockY)
                {
                    heightChange *= -1;
                    block.Position = new Vector2(block.Position.X, originalBlockY);
                    
                }
            }
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, location, color);
        }
        
        public Rectangle GetHitBox(Vector2 location)
        {
            return sprite.GetHitBox(location);
        }

        public abstract void BeHit(IPlayer player);
    }
}
