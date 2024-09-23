using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint_2.Sprites;
using System.Diagnostics;
using Sprint_2.GameObjects;

namespace Sprint_2.Sprites
{
    public class FireballExplosionSprite : ISprite
    {
        private Texture2D texture;
        private float animationDelay;
        private float initalAnimationDelay;
        private int rows;
        private int columns;

        private int currentFrame;
        private int totalFrames;
        private int scale;

        private bool drawable = true;
        public FireballExplosionSprite(Texture2D texture, float animationDelay, int rows, int columns, int scale)
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
            if (drawable)
            {
                float timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
                animationDelay -= timer;

                if (animationDelay <= 0)
                {
                    currentFrame++;
                    if (currentFrame >= totalFrames)
                    {
                        //Do something so it doesn't draw on the screen anymore
                        drawable = false;
                        
                    }

                    animationDelay = initalAnimationDelay;
                }

            }

            
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (drawable)
            {
                int width = texture.Width / columns;
                int height = texture.Height / rows;

                int row = currentFrame / columns;
                int column = currentFrame % columns;

                Rectangle sourceRect = new Rectangle(width * column, height * row, width, height);
                Rectangle destRect = new Rectangle((int)location.X, (int)location.Y, scale * width, scale * height);

                spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
            }

        }
    }
}
