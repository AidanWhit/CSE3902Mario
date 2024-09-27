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
        public Vector2 position { get; set; }
        public bool containsItem { get; set; }
        public bool breakable { get; set; }

        private ISprite blockSprite;

        public Block(ISprite initialSprite)
        {
            blockSprite = initialSprite;
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            blockSprite.Draw(spriteBatch, location, color);
        }

        public void Update(GameTime gameTime)
        {
            blockSprite.Update(gameTime);
        }

        public void ChangeSprite(ISprite newSprite)
        {
            blockSprite = newSprite;
        }
    }
}
