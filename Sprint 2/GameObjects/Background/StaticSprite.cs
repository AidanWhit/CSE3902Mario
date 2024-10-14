using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using Sprint_2.Sprites;
using System;
using System.Collections.Generic;

namespace Sprint_2.GameObjects
{
    public class StaticSprite : IStaticSprite
    {
        private Texture2D texture;
        private Rectangle[] sourceRectangles;
        public Vector2 Position { get; set; }  // Implement the Position property

        public StaticSprite(Texture2D texture, Rectangle[] sourceRectangles, Vector2 position)
        {
            this.texture = texture;
            this.sourceRectangles = sourceRectangles;
            this.Position = position;  // Store the position
        }

        public void Update(GameTime gameTime)
        {
            // Static background objects don't need updates
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            // Draw using the stored position
            spriteBatch.Draw(texture, Position, sourceRectangles[0], color);
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            // Static background objects don't need a hitbox
            return Rectangle.Empty;
        }
    }
}