using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2.Sprites
{
    public class RowsColumnsFormattedSprite : ISprite
    {
        private Texture2D texture;
        private float animationSpeed;
        private float initialAnimationSpeed;
        private int rows;
        private int columns;

        private int currentFrame;
        private int totalFrames;
        private int scale;

        public RowsColumnsFormattedSprite(Texture2D texture, int rows, int columns, int scale)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            this.scale = scale;

            currentFrame = 0;
            totalFrames = rows * columns;

            animationSpeed = 0.1f;
            initialAnimationSpeed = animationSpeed;
        }

        public void Update(GameTime gameTime)
        {
            float timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            animationSpeed -= timer;

            if (animationSpeed < 0) 
            {
                animationSpeed = initialAnimationSpeed;

                currentFrame++;
                currentFrame %= totalFrames;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;

            int row = currentFrame / columns;
            int column = currentFrame % columns;

            Rectangle sourceRect = new Rectangle(width * column, height * row, width, height);
            Rectangle destRect = new Rectangle((int)location.X, (int)location.Y, scale * width, scale * height);

            spriteBatch.Draw(texture, destRect, sourceRect, color);
        }

        public Rectangle GetHitBox(Vector2 location)
        {
            return new Rectangle(0, 0, 0, 0);
        }
    }
}
