using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Sprint_2.Sprites
{
    public class AnimatedSprite : ISprite
    {
        private Texture2D texture;
        private float animationDelay;
        private float initalAnimationDelay;
        private int rows;
        private int columns;

        private int currentFrame;
        private int totalFrames;
        private int scale;
        public AnimatedSprite(Texture2D texture, float animationDelay, int rows, int columns, int scale) 
        {
            this.scale = scale;
            this.texture = texture;
            this.animationDelay = animationDelay;
            this.rows = rows;
            this.columns = columns;
            totalFrames = rows * columns;
            currentFrame = 0;

            initalAnimationDelay = animationDelay;
        }

        public void Update(GameTime gameTime)
        {
            float timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            animationDelay -= timer;

            if (animationDelay <= 0)
            {
                currentFrame++;
                currentFrame %= totalFrames;

                animationDelay = initalAnimationDelay;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;

            int row = currentFrame / columns;
            int column = currentFrame % columns;

            Rectangle sourceRect = new Rectangle(width * column, height * row, width, height);
            Rectangle destRect = new Rectangle((int)location.X, (int)location.Y, scale*width, scale*height);

            spriteBatch.Draw(texture, destRect, sourceRect, color);

        }
    }
}
