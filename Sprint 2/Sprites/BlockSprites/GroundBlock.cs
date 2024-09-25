﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_0.Sprites;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Sprites.BlockSprites
{
    public class GroundBlock : IBlock, ISprite
    {
        private Texture2D blockTexture;
        public Vector2 position { get; set; }
        public bool containsItem { get; set; }
        public bool breakable { get; set; }

        public GroundBlock(Texture2D texture, Vector2 initalPosition)
        {
            this.blockTexture = texture;
            this.position = initalPosition;
            this.containsItem = false;
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
