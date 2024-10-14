using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;

namespace Sprint_2.GameObjects
{
    public class StaticSprite : ISprite
    {
        private Texture2D texture;
        private Rectangle[] sourceRectangles;
        private Vector2 position;

        public StaticSprite(Texture2D texture, Rectangle[] sourceRectangles)
        {
            this.texture = texture;
            this.sourceRectangles = sourceRectangles;
            //this.size = size;
        }

        public void Update(GameTime gameTime)
        {
            // 
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(texture, position, sourceRectangles[0], color);
        }


        public Rectangle GetHitBox(Vector2 location)
        {
            // Background objects do not have hitboxes, return an empty Rectangle
            return Rectangle.Empty;
        }
    }
}
