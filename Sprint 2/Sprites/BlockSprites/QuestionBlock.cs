using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Sprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Sprites.BlockSprites
{
    public class QuestionBlock : IBlock, ISprite
    {
        private Texture2D blockTexture;
        private Rectangle[] frames;
        private int currentFrame;
        public Vector2 position { get; set; }
        public bool containsItem { get; set; }
        public bool breakable { get; set; }

        public QuestionBlock(Texture2D texture, Vector2 initalPosition)
        {
            this.blockTexture = texture;
            this.currentFrame = 0;
            this.position = initalPosition;
            this.containsItem = true;
            this.breakable = false;
            
        }

        public void Update(GameTime gameTime)
        {
            // TODO: update when block is hit by player
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(blockTexture, position, Color.White);
        }
    }
}
