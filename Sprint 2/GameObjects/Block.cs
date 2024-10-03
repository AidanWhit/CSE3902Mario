using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.GameObjects
{
    public class Block : IBlock
    {
        public Vector2 Position { get; set; }
        public bool containsItem { get; set; }
        public bool breakable { get; set; }

        private ISprite blockSprite;

        /* TODO : Add a blockstate that holds the sprite for the current block, the state will dictate how the block will interact with mario.
         e.g. what block is created when it is hit, if it has an item, etc. */
        public Block(ISprite initialSprite, Vector2 position)
        {
            blockSprite = initialSprite;
            Position = position;
        }


        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            blockSprite.Draw(spriteBatch, Position, color);
        }

        public void Update(GameTime gameTime)
        {
            blockSprite.Update(gameTime);
        }

        public void ChangeSprite(ISprite newSprite)
        {
            blockSprite = newSprite;
        }

        /* TODO: Implement actual hitbox */
        public Rectangle GetHitBox()
        {
            return blockSprite.GetHitBox(Position);
        }
    }
}
