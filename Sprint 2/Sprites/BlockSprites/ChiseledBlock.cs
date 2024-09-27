using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Factories;

namespace Sprint_2.Sprites.BlockSprites
{
    public class ChiseledBlock : IBlock
    {
        public Vector2 position { get; set; }
        public bool containsItem { get; set; }
        public bool breakable { get; set; }

        private ISprite sprite;

        public ChiseledBlock(Vector2 initalPosition)
        {
            position = initalPosition;
            containsItem = false;
            breakable = true;

            sprite = BlockFactory.Instance.CreateChiseledBlock();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            sprite.Draw(spriteBatch, position, color);
        }
    }
}
